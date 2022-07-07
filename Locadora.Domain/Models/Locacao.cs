
namespace Locadora.Domain.Models
{
    public class Locacao
    {
        public Locacao(){   }
        public int Id { get; private set; }
        public Cliente Cliente { get; private set; }
        public int IdCliente { get; private set; }
        public Filme  Filme { get; private set; }
        public IEnumerable<int> IdFilmes  { get; private set; }
        public DateTime DataLocacao { get; private set; }
        public DateTime DataDevolucao { get; private set; }
        public Locacao(int idCliente, IEnumerable<int> idfilme, DateTime dataLocacao)
        {
            IdCliente = idCliente;
            IdFilmes = idfilme;
            DataLocacao = DateTime.Now;
            DataDevolucao = Filme.Lancamento == 1 ? DataLocacao.AddDays(2) : DataLocacao.AddDays(3);
        }
        public void Atualizar(int idCliente, IEnumerable<int> idfilme, DateTime dataLocacao) 
        {
            IdCliente = idCliente;
            IdFilmes = idfilme;
            DataLocacao = DateTime.Now;
            DataDevolucao = Filme.Lancamento == 1 ? DataLocacao.AddDays(2) : DataLocacao.AddDays(3);
        }
    }
}
