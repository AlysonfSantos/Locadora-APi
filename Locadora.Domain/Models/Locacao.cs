
namespace Locadora.Domain.Models
{
    public class Locacao
    {
        public Locacao(){   }
        public int Id { get; private set; }
        public Cliente Cliente { get; private set; }
        public int IdCliente { get; private set; }
        public Filme  Filme { get; private set; }
        public int IdFilmes  { get; private set; }
        public DateTime DataLocacao { get; private set; }
        public DateTime DataDevolucao { get; private set; }
        public Locacao(int idCliente, int idfilme, DateTime dataLocacao, DateTime dataDevolução)
        {
            IdCliente = idCliente;
            IdFilmes = idfilme;
            DataLocacao = DateTime.Now;
            DataDevolucao = dataDevolução;
                //Filme.Lancamento == true  ? DataLocacao.AddDays(2) : DataLocacao.AddDays(3);
        }
        public void Atualizar(int idCliente, int idfilme, DateTime dataLocacao, DateTime dataDevolução) 
        {
            IdCliente = idCliente;
            IdFilmes = idfilme;
            DataLocacao = DateTime.Now;
            DataDevolucao = dataDevolução;
        }
    }
}
