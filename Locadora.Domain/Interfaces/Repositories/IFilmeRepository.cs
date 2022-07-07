
using Locadora.Domain.Models;

namespace Locadora.Domain.Interfaces.Repositories
{
    public interface IFilmeRepository : IBaseRepository<Filme>
    {
        Task<IEnumerable<Filme>> ListarFilme();
        Task<Filme> FilmeId(long id);
        Task CadastrarFilme(Filme filme);
        Task AtualizarFilme(Filme filme);
        Task DeletarFilme(Filme filme);
    }
}
