using Locadora.Domain.Models;
using Locadora.Domain.Models.Commands;

namespace Locadora.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> ListarCliente();
        Task<Cliente> ClienteId(long id);
        Task<Cliente> CadastrarCliente(Cliente cliente);
        Task<Cliente> AtualizarCliente(AtualizarClienteCommand command);
        Task<bool> DeletarCliente(long id);
    }
}
