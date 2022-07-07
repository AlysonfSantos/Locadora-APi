using Locadora.Domain.Interfaces.Repositories;
using Locadora.Domain.Interfaces.Services;
using Locadora.Domain.Models;
using Locadora.Domain.Models.Commands;

namespace Locadora.Domain.Services
{
    public class LocacaoService : ILocacaoService
    {
        private readonly ILocacaoRepository _locacaoRepository;

        public LocacaoService(ILocacaoRepository locacaoRepository)
        {
            _locacaoRepository = locacaoRepository;
        }

        public async Task<IEnumerable<Locacao>> ListarLocacao() 
        {
            return await _locacaoRepository.Listarlocacao();
        }
        public async Task<IEnumerable<Locacao>> DataLocacao(DateTime data) 
        {
            var locacao = await _locacaoRepository.GetAll(x => x.DataLocacao == data);
            if (locacao == null) return null;

            return locacao;
        }
       

        public async Task<Locacao> CadastrarLocacao(Locacao locacao) 
        {
            await _locacaoRepository.CadastrarLocacao(locacao);
            await _locacaoRepository.UnitOfWork.SaveChangesAsync();
            return locacao;
        }

        public async Task<Locacao> AtualizarLocacao(AtualizarLocacaoCommand command) 
        {
            var locacao = await _locacaoRepository.Get(x => x.Id == command.Id);
            if (locacao == null) return null;

            locacao.Atualizar(command.IdCliente,
                command.IdFilmes,
                command.DataLocacao);

            await _locacaoRepository.AtualizarLocacao(locacao);
            await _locacaoRepository.UnitOfWork.SaveChangesAsync();
            return locacao;
        }
        public async Task<bool> DeletarLocacao(long id) 
        {
            var locacao = await _locacaoRepository.Get(x => x.Id == id);
            if (locacao == null) return false;
            await _locacaoRepository.DeletarLocacao(locacao);
            await _locacaoRepository.UnitOfWork.SaveChangesAsync();
            return true;
            
        }
    }
}
