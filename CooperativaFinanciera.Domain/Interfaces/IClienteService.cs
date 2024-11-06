
using CooperativaFinanciera.Domain.Dtos;

namespace CooperativaFinanciera.Domain
{
    public interface IClienteService
    {
        Task<bool> ClienteNuevo(Cliente cliente);
        Task<bool> ExisteClienteConDocumentoAsync(string tipoDocumento, long numeroDocumento);
        Task<bool> UpdatCliente(Cliente cliente);
        Task<Cliente> ObtenerClientePorIdAsync(int codigo);
        Task<bool> DeleteCliente(int codigo);
        Task<IEnumerable<ClienteDto>> ConsultarClientesPorFiltro(ConsultaClienteFiltro filtro);


    }
}