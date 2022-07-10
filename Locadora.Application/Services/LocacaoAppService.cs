
using AutoMapper;
using Locadora.Application.Services.Interfaces;
using Locadora.Application.ViewModels.LocacaoViewModel;
using Locadora.Domain.Interfaces.Services;
using Locadora.Domain.Models;
using Locadora.Domain.Models.Commands;
using System.Text;

namespace Locadora.Application.Services
{
    public class LocacaoAppService: ILocacaoAppService
    {
        private readonly IClienteService _cadastroService;
        private readonly IFilmeService _filmesService;
        private readonly ILocacaoService _locacaoService;
        private readonly IMapper _mapper;

        public LocacaoAppService(ILocacaoService locacaoService, IMapper mapper, IFilmeService filmesService, IClienteService cadastroService)
        {
            _locacaoService = locacaoService;
            _mapper = mapper;
            _filmesService = filmesService;
            _cadastroService = cadastroService;
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
            var filme = await _filmesService.FilmeId(novaLocacaoViewModel.IdFilmes);
            var cliente = await _cadastroService.ClienteId(novaLocacaoViewModel.IdCliente);

            var novaLocacao = new Locacao(novaLocacaoViewModel.IdCliente, 
                novaLocacaoViewModel.IdFilmes,
                novaLocacaoViewModel.DataLocacao,
                novaLocacaoViewModel.DataDevolucao = filme.Lancamento == true ? novaLocacaoViewModel.DataLocacao.AddDays(2) : novaLocacaoViewModel.DataLocacao.AddDays(3));
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
        //public async Task<IEnumerable<LocacaoViewModel>> ExportarArquivo()
        //{
        //    var locacao = await _locacaoService.ListarLocacao();
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine("Id;IdCliente;IdFilmes;DataLocacao;DataDevolucao");
        //    foreach (var ListaLocacao in locacao) 
        //    {
        //        sb.AppendLine($"{ListaLocacao.Id};{ListaLocacao.IdCliente};{ListaLocacao.IdFilmes};{ListaLocacao.DataLocacao};{ListaLocacao.DataDevolucao}");
        //    }
        //    var filePath = @"C:/tmp/locacao.csv";
        //    File.WriteAllText(filePath, sb.ToString());
        //    Console.ReadKey();
        //    return _mapper.Map<IEnumerable<LocacaoViewModel>>(locacao);
        //}
    }
}

