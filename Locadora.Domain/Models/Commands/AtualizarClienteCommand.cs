using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Domain.Models.Commands
{
    public class AtualizarClienteCommand
    {
        public int Id { get;  set; }
        public string Nome { get;  set; }
        public DateTime DataNascimento { get;  set; }

    }
}
