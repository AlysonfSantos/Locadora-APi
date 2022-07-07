using Locadora.Application.ViewModels.ClientesViewModel;

namespace Locadora.Application.Services.Interfaces
{
    public interface IClienteAppService
    {
        Task<IEnumerable<ClienteViewModel>> ListarCliente();
        Task<ClienteViewModel> ClienteId(long id);
        Task<ClienteViewModel> CadastrarCliente(NovoClienteViewModel novoClienteViewModel);
        Task<ClienteViewModel> AtualizarCliente(AtualizarClienteViewModel atualizarClienteViewModel);
        Task<bool> DeletarCliente(long id);
    }
}
