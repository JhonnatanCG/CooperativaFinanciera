
namespace CooperativaFinanciera.Domain
{
    public interface IClienteService
    {
        Task<bool> ClienteNuevo(Cliente cliente);
    }
}