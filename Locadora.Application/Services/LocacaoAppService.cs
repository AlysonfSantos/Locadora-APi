
using AutoMapper;
using Locadora.Application.Services.Interfaces;
using Locadora.Application.ViewModels.LocacaoViewModel;
using Locadora.Domain.Interfaces.Services;
using Locadora.Domain.Models;
using Locadora.Domain.Models.Commands;

namespace Locadora.Application.Services
{
    public class LocacaoAppService: ILocacaoAppService
    {
        private readonly ILocacaoService _locacaoService;
        private readonly IMapper _mapper;

        public LocacaoAppService(ILocacaoService locacaoService, IMapper mapper)
        {
            _locacaoService = locacaoService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LocacaoViewModel>> Listarlocacao() 
        {
            var locacao = await _locacaoService.ListarLocacao();
            return _mapper.Map<IEnumerable<LocacaoViewModel>>(locacao);
        }
        public async Task<IEnumerable<LocacaoViewModel>> DataLocacao(DateTime data) 
        {
            var locacao = await _locacaoService.DataLocacao(data);
            return _mapper.Map<IEnumerable<LocacaoViewModel>>(locacao);
        }
        public async Task<LocacaoViewModel> CadastrarLocacao(NovaLocacaoViewModel novaLocacaoViewModel)
        {
            var novaLocacao = new Locacao(novaLocacaoViewModel.IdCliente, 
                novaLocacaoViewModel.IdFilmes,
                novaLocacaoViewModel.DataLocacao);
            var LocacaoCadastrada = await _locacaoService.CadastrarLocacao(novaLocacao);
            return _mapper.Map<LocacaoViewModel>(LocacaoCadastrada);
        }
        public async Task<LocacaoViewModel> AtualizarLocacao(AtualizarLocacaoViewModel atualizarLocacaoViewModel) 
        {
            var command = new AtualizarLocacaoCommand
            {
                Id = atualizarLocacaoViewModel.Id,
                IdCliente = atualizarLocacaoViewModel.IdCliente,
                IdFilmes = atualizarLocacaoViewModel.IdFilmes,
                DataLocacao = atualizarLocacaoViewModel.DataLocacao,
                DataDevolucao = atualizarLocacaoViewModel.DataDevolucao
            };
            var locacaoAtualizada = await _locacaoService.AtualizarLocacao(command);
            return _mapper.Map<LocacaoViewModel>(locacaoAtualizada);
        }
        public async Task<bool> DeletarLocacao(long id)
        {
            return await _locacaoService.DeletarLocacao(id);
        }
    }
}

