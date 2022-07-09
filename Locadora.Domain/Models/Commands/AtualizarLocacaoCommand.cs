using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Domain.Models.Commands
{
    public class AtualizarLocacaoCommand
    {
        public int Id { get;  set; }
        public Cliente Cliente { get;  set; }
        public int IdCliente { get;  set; }
        public Filme Filme { get;  set; }
        public int IdFilmes { get;  set; }
        public DateTime DataLocacao { get;  set; }
        public DateTime DataDevolucao { get;  set; }
    }
}
