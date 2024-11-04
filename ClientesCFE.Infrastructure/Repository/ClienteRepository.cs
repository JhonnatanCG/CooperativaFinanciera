using CooperativaFinanciera.Domain;
using CooperativaFinanciera.Infrastructure.Contexts;
using CooperativaFinanciera.Infrastructure.Domain;
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

        public async Task<bool> InsertCliente(Cliente cliente)
        {
            var validarCliente = await _dbCooperativaContext.Clientes
              .AnyAsync(c => c.TipoDocumentoId == cliente.TipoDocumentoId && c.NumeroDocumento == cliente.NumeroDocumento);

            if (validarCliente)
            {
                return false;
            }

            _dbCooperativaContext.Clientes.Add(cliente);

            var result = await _dbCooperativaContext.SaveChangesAsync();

            if (result == 1) { return true; }
            return false;
        }
    }
}
