using AutoMapper;
using Locadora.Application.Services.Interfaces;
using Locadora.Application.ViewModels.FilmesViewModel;
using Locadora.Domain.Interfaces.Services;
using Locadora.Domain.Models;
using Locadora.Domain.Models.Commands;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;


namespace Locadora.Application.Services
{
    public class FilmesAppService :IFilmeAppService
    {
        private readonly IFilmeService _filmesService;
        private readonly IMapper _mapper;

        public FilmesAppService(IFilmeService filmesService, IMapper mapper)
        {
            _filmesService = filmesService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FilmeViewModel>> ListarFilme() 
        {
            var filme = await _filmesService.ListarFilme();
            return _mapper.Map<IEnumerable<FilmeViewModel>>(filme);
        }
        public async Task<FilmeViewModel> FilmeId (long id) 
        {
            var filme = await _filmesService.FilmeId(id);
            return _mapper.Map<FilmeViewModel>(filme);
        }
        public async Task<FilmeViewModel> CadastrarFilme(NovoFilmeViewModel novoFilmeViewModel) 
        {
            var novoFilme = new Filme( novoFilmeViewModel.Titulo,
                novoFilmeViewModel.ClassificacaoIndicativa,
                novoFilmeViewModel.Lancamento);
            var filmeCadastrado = await _filmesService.CadastrarFilme(novoFilme);
            return _mapper.Map<FilmeViewModel>(filmeCadastrado);
        }
        public async Task<FilmeViewModel> AtualizarFilme(AtualizarFilmeViewModel atualizarFilmeViewModel) 
        {
            var command = new AtualizarFilmeCommand
            {
                Id = atualizarFilmeViewModel.Id,
                Titulo = atualizarFilmeViewModel.Titulo,
                ClassificacaoIndicativa = atualizarFilmeViewModel.ClassificacaoIndicativa,
                Lancamento = atualizarFilmeViewModel.Lancamento,
            };
            var filmeAtualizado = await _filmesService.AtualizarFilme(command);
            return _mapper.Map<FilmeViewModel>(filmeAtualizado);
        }
        public async Task<bool> DeletarFilme(long id) 
        {
            return await _filmesService.DeletarFilme(id);
        }

        public async Task<FilmeViewModel> ImportarArquivo(IFormFile file)
        {
            //if (file == null) return null;
            //var split = file.FileName.Split('.');
            //var extensao = split[split.Length - 1];
            //var result = file.FileName.Replace($".{extensao}", "");
            //if (result != "csv") return null;
           
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var filmeCadastrado = new Filme();
                int numeroLinha = 0;
                while (reader.Peek() >= 0)
                {
                    numeroLinha++;
                    var registro = await reader.ReadLineAsync();
                    
                    if (numeroLinha == 1) continue;

                    var conteudo = registro.Split(';');
                    var ListaFilmeId = Convert.ToInt32(conteudo[0]);
                    var filmeID = await _filmesService.FilmeId(ListaFilmeId);
                    if (filmeID == null)
                    {
                        var filme = new Filme(conteudo[1], Convert.ToInt32(conteudo[2]), Convert.ToInt32(conteudo[3]) == 1);
                        filmeCadastrado = await _filmesService.CadastrarFilme(filme);
                    }
                }
                return _mapper.Map<FilmeViewModel>(filmeCadastrado);
            }
         
        }
       
    }
}

