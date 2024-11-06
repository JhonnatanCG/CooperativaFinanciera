using CooperativaFinanciera.Domain.Dtos;
using CooperativaFinanciera.Infrastructure.Domain;

namespace CooperativaFinanciera.Domain.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> ClienteNuevo(Cliente cliente)
        {
            return await _clienteRepository.InsertCliente(cliente);
        }

        public async Task<bool> ExisteClienteConDocumentoAsync(string tipoDocumento, long numeroDocumento)
        {
            return await _clienteRepository.ExisteClienteConDocumentoAsync(tipoDocumento, numeroDocumento);
        }

        public async Task<bool> UpdatCliente(Cliente cliente)
        {
            return await _clienteRepository.UpdatCliente(cliente);
        }

        public async Task<Cliente> ObtenerClientePorIdAsync(int codigo)
        {
            var cliente = await _clienteRepository.ObtenerClientePorIdAsync(codigo);
            return cliente.FirstOrDefault()!;

        }

        public async Task<bool> DeleteCliente(int codigo)
        {
            return await _clienteRepository.DeleteCliente(codigo);
        }

        public async Task<IEnumerable<ClienteDto>> ConsultarClientesPorFiltro(ConsultaClienteFiltro filtro)
        {
            return await _clienteRepository.ConsultarClientesPorFiltro(filtro);
        }
    }
}
