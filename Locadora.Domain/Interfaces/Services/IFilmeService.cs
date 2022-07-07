using Locadora.Domain.Models;
using Locadora.Domain.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Domain.Interfaces.Services
{
    public interface IFilmeService
    {
        Task<IEnumerable<Filme>> ListarFilme();
        Task<Filme> FilmeId(long id);
        Task<Filme> CadastrarFilme(Filme filme);
        Task<Filme> AtualizarFilme(AtualizarFilmeCommand command);
        Task<bool> DeletarFilme(long id);
     //   Task<Filme> LerArquivo(Stream stream);


    }
}
