
namespace Locadora.Application.ViewModels.LocacaoViewModel
{
    public class NovaLocacaoViewModel
    {
     //   public int Id { get; set; }
     //   public ClienteViewModel Cliente { get; set; }
        public int IdCliente { get; set; }
      //  public FilmeViewModel Filme { get; set; }
        public int IdFilmes { get; set; }
        public DateTime DataLocacao { get; set; }

        public DateTime DataDevolucao { get; set; }
    }
}
