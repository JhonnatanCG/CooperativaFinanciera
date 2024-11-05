
using CooperativaFinanciera.Domain;

namespace CooperativaFinanciera.Infrastructure.Domain
{
    public interface IClienteRepository
    {
        Task<bool> InsertCliente(Cliente cliente);
        Task<bool> ExisteClienteConDocumentoAsync(string tipoDocumento, long numeroDocumento);

        Task<bool> UpdatCliente(Cliente cliente);

        Task<List<Cliente>> ObtenerClientePorIdAsync(int codigo);
    }
}