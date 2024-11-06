
using CooperativaFinanciera.Domain;
using CooperativaFinanciera.Domain.Dtos;

namespace CooperativaFinanciera.Infrastructure.Domain
{
    public interface IClienteRepository
    {
        Task<bool> InsertCliente(Cliente cliente);
        Task<bool> ExisteClienteConDocumentoAsync(string tipoDocumento, long numeroDocumento);
        Task<bool> UpdatCliente(Cliente cliente);
        Task<List<Cliente>> ObtenerClientePorIdAsync(int codigo);
        Task<bool> DeleteCliente(int codigo);
        Task<IEnumerable<ClienteDto>> ConsultarClientesPorFiltro(ConsultaClienteFiltro filtro);
    }
}