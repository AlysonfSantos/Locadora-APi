using Locadora.Domain.Models;

namespace Locadora.Domain.Interfaces.Repositories
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Task<IEnumerable<Cliente>> ListarCliente();
        Task<Cliente> ClienteId(long id);
        Task CadastrarCliente(Cliente cliente);
        Task AtualizarCliente(Cliente cliente);
        Task DeletarCliente(Cliente cliente);
    }
}
