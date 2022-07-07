using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Domain.Models.Commands
{
    public class AtualizarFilmeCommand
    {
        public int Id { get;  set; }
        public string Titulo { get;  set; }
        public int ClassificacaoIndicativa { get;  set; }
        public int Lancamento { get;  set; }
    }
}
