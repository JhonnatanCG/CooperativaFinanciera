using CooperativaFinanciera.Domain;
using CooperativaFinanciera.Domain.Dtos;
using CooperativaFinanciera.Infrastructure.Contexts;
using CooperativaFinanciera.Infrastructure.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CooperativaFinanciera.Infrastructure.Repository
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly dbCooperativaContext _dbCooperativaContext;
        public ClienteRepository(dbCooperativaContext dbCooperativaContext)
        {
            _dbCooperativaContext = dbCooperativaContext;
        }
        public async Task<bool> ExisteClienteConDocumentoAsync(string tipoDocumento, long numeroDocumento)
        {
            var validarCliente = await _dbCooperativaContext.Clientes
             .AnyAsync(c => c.TipoDocumento == tipoDocumento && c.NumeroDocumento == numeroDocumento);

            if (validarCliente)
            {
                return true;
            }

            return false;
        }

        public async Task<List<Cliente>> ObtenerClientePorIdAsync(int codigo)
        {
            return await (from c in _dbCooperativaContext.Clientes
                          where c.Codigo == codigo
                          select c).ToListAsync();

        }

        public async Task<bool> InsertCliente(Cliente cliente)
        {

            _dbCooperativaContext.Clientes.Add(cliente);

            if (cliente.Direcciones != null && cliente.Direcciones.Count > 0)
            {
                _dbCooperativaContext.Direcciones.AddRange(cliente.Direcciones);
            }

            var result = await _dbCooperativaContext.SaveChangesAsync();

            if (result >= 1) { return true; }
            return false;
        }

        public async Task<bool> UpdatCliente(Cliente cliente)
        {
            var update = await _dbCooperativaContext.Clientes.Where(e => e.Codigo == cliente.Codigo)
                .ExecuteUpdateAsync(setters => setters
                .SetProperty(e => e.TipoDocumento, cliente.TipoDocumento)
                .SetProperty(e => e.NumeroDocumento, cliente.NumeroDocumento)
                .SetProperty(e => e.Nombres, cliente.Nombres)
                .SetProperty(e => e.Apellido1, cliente.Apellido1)
                .SetProperty(e => e.Apellido2, cliente.Apellido2)
                .SetProperty(e => e.Genero, cliente.Genero)
                .SetProperty(e => e.FechaNacimiento, cliente.FechaNacimiento)
                .SetProperty(e => e.Email, cliente.Email));

            foreach (var direccion in cliente.Direcciones)
            {
                if (direccion.DireccionID != 0)
                {

                    await _dbCooperativaContext.Direcciones
                        .Where(d => d.DireccionID == direccion.DireccionID)
                        .ExecuteUpdateAsync(setters => setters
                            .SetProperty(d => d.Direccion, direccion.Direccion)
                            .SetProperty(d => d.Tipo, direccion.Tipo));

                }
                else
                {

                    await _dbCooperativaContext.Direcciones.AddAsync(direccion);
                }
            }

            foreach (var telefono in cliente.Telefonos)
            {
                if (telefono.TelefonoID != 0)
                {

                    await _dbCooperativaContext.Telefonos
                        .Where(t => t.TelefonoID == telefono.TelefonoID)
                        .ExecuteUpdateAsync(setters => setters
                            .SetProperty(t => t.Numero, telefono.Numero)
                            .SetProperty(t => t.Tipo, telefono.Tipo));
                }
                else
                {

                    await _dbCooperativaContext.Telefonos.AddAsync(telefono);
                }
            }

            await _dbCooperativaContext.SaveChangesAsync();

            return update > 0;
        }

        public async Task<bool> DeleteCliente(int codigo)
        {
            
            var result = await _dbCooperativaContext.Database
                .ExecuteSqlRawAsync("EXEC sp_DeleteCliente @Codigo = {0}", codigo);

           
            return result < 0;
        }


        public async Task<IEnumerable<ClienteDto>> ConsultarClientesPorFiltro(ConsultaClienteFiltro filtro)
        {
            var consulta = _dbCooperativaContext.Clientes.AsQueryable();


            if (!string.IsNullOrEmpty(filtro.Nombre))
            {
                consulta = consulta
                    .Where(c => (c.Nombres + " " + c.Apellido1 + " " + c.Apellido2).Contains(filtro.Nombre))
                    .OrderBy(c => c.Nombres);
            }


            if (filtro.NumeroDocumento.HasValue)
            {
                consulta = consulta
                    .Where(c => c.NumeroDocumento == filtro.NumeroDocumento)
                    .OrderByDescending(c => c.NumeroDocumento);
            }


            if (filtro.FechaInicio.HasValue && filtro.FechaFin.HasValue)
            {
                consulta = consulta
                    .Where(c => c.FechaNacimiento >= filtro.FechaInicio && c.FechaNacimiento <= filtro.FechaFin)
                    .OrderBy(c => c.FechaNacimiento);
            }


            if (filtro.MasDeUnTelefono)
            {
                consulta = consulta
                    .Where(c => c.Telefonos.Count > 1);
            }


            if (filtro.MasDeUnaDireccion)
            {
                consulta = consulta
                    .Where(c => c.Direcciones.Count > 1);
            }


            return await consulta.Select(c => new ClienteDto
            {
                Codigo = c.Codigo,
                TipoDocumento = c.TipoDocumento,
                NumeroDocumento = c.NumeroDocumento,
                NombreCompleto = $"{c.Nombres} {c.Apellido1} {c.Apellido2}",
                FechaNacimiento = c.FechaNacimiento,
                NumeroTelefonos = c.Telefonos.Count,
                PrimeraDireccion = c.Direcciones.FirstOrDefault()!.Direccion
            }).ToListAsync();




        }
    }
}
