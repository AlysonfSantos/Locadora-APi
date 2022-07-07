

using Locadora.Domain.Models;

namespace Locadora.Domain.Interfaces.Repositories
{
    public interface ILocacaoRepository : IBaseRepository<Locacao>
    {
        Task<IEnumerable<Locacao>> Listarlocacao();
        Task<IEnumerable<Locacao>> DataLocacao(DateTime data);
      //  Task<Locacao> DataLocacao(DateTime data);
        Task CadastrarLocacao(Locacao locacao);
        Task AtualizarLocacao(Locacao locacao);
        Task DeletarLocacao(Locacao locacao);
    }
}
