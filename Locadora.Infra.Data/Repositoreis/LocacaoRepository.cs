using Locadora.Domain.Interfaces.Repositories;
using Locadora.Domain.Models;
using Locadora.Infra.Data.EF;
using Locadora.Infra.Data.Repositoreis.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Infra.Data.Repositoreis
{
    public class LocacaoRepository : BaseRepository<Locacao>, ILocacaoRepository
    {
        private readonly LocadoraContext _context;

        public LocacaoRepository(LocadoraContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Locacao>> Listarlocacao() 
        {
            return await _context.Locacao.ToListAsync();
        }
        public async Task<IEnumerable<Locacao>> DataLocacao(DateTime data)
        {
            return await _context.Locacao.ToListAsync(); ;
        }
        public async Task CadastrarLocacao(Locacao locacao) 
        {
            await _context.Locacao.AddAsync(locacao);
        }
        public async Task AtualizarLocacao(Locacao locacao) 
        {
            await Task.FromResult(_context.Update(locacao));
        }
        public async Task DeletarLocacao(Locacao locacao) 
        {
            await Task.FromResult(_context.Remove(locacao));
        }
    }
}