using Locadora.Domain.Interfaces.Repositories;
using Locadora.Domain.Models;
using Locadora.Infra.Data.EF;
using Locadora.Infra.Data.Repositoreis.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Infra.Data.Repositoreis
{
    public class FilmeRepository : BaseRepository<Filme>, IFilmeRepository
    {
        private readonly LocadoraContext _context;

        public FilmeRepository(LocadoraContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Filme>> ListarFilme() 
        {
            return await _context.Filmes.ToListAsync();
        }
        public async Task<Filme> FilmeId(long id)
        {
            return await _context.Filmes.FindAsync(id);
        }
        public async Task CadastrarFilme(Filme filme) 
        {
            await _context.Filmes.AddAsync(filme);
        }
        public async Task AtualizarFilme(Filme  filme) 
        {
            await Task.FromResult(_context.Update(filme)); 
        }
        public async Task DeletarFilme(Filme filme) 
        {
            await Task.FromResult(_context.Remove(filme));
        }

    }
}



