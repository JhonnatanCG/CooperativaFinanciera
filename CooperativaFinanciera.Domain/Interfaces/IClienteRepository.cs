
using CooperativaFinanciera.Domain;

namespace CooperativaFinanciera.Infrastructure.Domain
{
    public interface IClienteRepository
    {
        Task<bool> InsertCliente(Cliente cliente);
    }
}