using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Application.ViewModels.ClientesViewModel
{
    public class ClienteViewModel
    {
        public int Id { get;  set; }
        public string Nome { get;  set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get;  set; }
    }
}
