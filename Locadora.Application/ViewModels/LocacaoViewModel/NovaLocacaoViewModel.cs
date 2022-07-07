using Locadora.Application.ViewModels.ClientesViewModel;
using Locadora.Application.ViewModels.FilmesViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Application.ViewModels.LocacaoViewModel
{
    public class NovaLocacaoViewModel
    {
        public int Id { get; set; }
        public ClienteViewModel Cliente { get; set; }
        public int IdCliente { get; set; }
        public FilmeViewModel Filme { get; set; }
        public IEnumerable<int> IdFilmes { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
