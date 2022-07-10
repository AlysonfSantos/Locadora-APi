using Locadora.Application.ViewModels.LocacaoViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Application.Services.Interfaces
{
    public interface ILocacaoAppService
    {
        Task<IEnumerable<LocacaoViewModel>> Listarlocacao();
        Task<IEnumerable<LocacaoViewModel>> DataLocacao(DateTime data);
        Task<LocacaoViewModel> CadastrarLocacao(NovaLocacaoViewModel novaLocacaoViewModel);
        Task<LocacaoViewModel> AtualizarLocacao(AtualizarLocacaoViewModel atualizarLocacaoViewModel);
        Task<bool> DeletarLocacao(long id);
        //Task<IEnumerable<LocacaoViewModel>> ExportarArquivo();

    }
}


