using Locadora.Application.ViewModels.FilmesViewModel;
using Locadora.Application.ViewModels.UploadArquivosViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Application.Services.Interfaces
{
    public interface IFilmeAppService
    {
        Task<IEnumerable<FilmeViewModel>> ListarFilme();
        Task<FilmeViewModel> FilmeId(long id);
        Task<FilmeViewModel> CadastrarFilme(NovoFilmeViewModel novoFilmeViewModel);
        Task<FilmeViewModel> AtualizarFilme(AtualizarFilmeViewModel atualizarFilmeViewModel);
        Task<bool> DeletarFilme(long id);

        Task<FilmeViewModel> ImportarArquivo(IFormFile file);

    }
}
