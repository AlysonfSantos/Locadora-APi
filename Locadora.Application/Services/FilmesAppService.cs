using AutoMapper;
using Locadora.Application.Services.Interfaces;
using Locadora.Application.ViewModels.FilmesViewModel;
using Locadora.Application.ViewModels.UploadArquivosViewModel;
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

        //public async Task<FilmeViewModel> ImportarFilme(ReadUploadArquivoViewModel formFile) 
        //{
        //    foreach( var filmes in formFile) 
        //    {
            
        //    }

        //}

        //public Stream ReadStraem(IFormFile form) 
        //{
        //    using  (var stream = new MemoryStream()) 
        //    {
        //        form?.CopyTo(stream);
        //        //    var byteArray = stream.ToArray();
        //        //   return  new MemoryStream(byteArray);
        //        return stream;
        //    }

        //}
        //public async Task<FilmeViewModel> LerArquivo(MemoryStream stream)
        //{
        //    var ListarFilme = new List<FilmeViewModel>();
        //    var filme2 = new FilmeViewModel();
        //    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        //    using (ExcelPackage package = new ExcelPackage(stream))
        //    {
        //        ExcelWorksheet worksheet = package.Workbook.Worksheets[PositionID: 0];
        //        int colCount = worksheet.Dimension.End.Column;
        //        int rowCount = worksheet.Dimension.End.Row;

        //        for (int row = 2; row <= rowCount; row++)
        //        {
        //            var filme = new NovoFilmeViewModel();
        //            filme.Id = Convert.ToInt32(worksheet.Cells[row, Col: 1].Value);
        //            filme.Titulo = worksheet.Cells[row, Col: 2].Value.ToString();
        //            filme.ClassificacaoIndicativa = Convert.ToInt32(worksheet.Cells[row, Col: 3].Value);
        //            filme.Lancamento = Convert.ToInt32(worksheet.Cells[row, Col: 4].Value);
        //            // ListarFilme.Add(filme);

        //            var ArquivoFilme = new Filme(
        //                //filme.Id,
        //                filme.Titulo,
        //                filme.ClassificacaoIndicativa,
        //                filme.Lancamento
        //                );


        //            var filmeAtualizado = await _filmesService.CadastrarFilme(ArquivoFilme);
        //            return _mapper.Map<FilmeViewModel>(filmeAtualizado);
        //        }

        //    }

        //    return  _mapper.Map<FilmeViewModel>(ListarFilme);
        //}
    }
}

