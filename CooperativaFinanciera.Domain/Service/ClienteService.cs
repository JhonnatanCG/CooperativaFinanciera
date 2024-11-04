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
        

        
    }
}
