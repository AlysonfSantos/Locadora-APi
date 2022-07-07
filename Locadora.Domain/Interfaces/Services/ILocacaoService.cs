using Locadora.Domain.Models;
using Locadora.Domain.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Domain.Interfaces.Services
{
    public interface ILocacaoService
    {
        Task<IEnumerable<Locacao>> ListarLocacao();
        Task<IEnumerable<Locacao>> DataLocacao(DateTime data);
       /// Task<Locacao> DataLocacao(long id);
        Task<Locacao> CadastrarLocacao(Locacao locacao);
        Task<Locacao> AtualizarLocacao(AtualizarLocacaoCommand command);
        Task<bool> DeletarLocacao(long id);
    }
}
