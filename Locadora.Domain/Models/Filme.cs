using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Domain.Models
{
    public class Filme
    {
        public Filme(){ }

        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public int ClassificacaoIndicativa { get; private set; }
        public bool Lancamento { get; private set; }
        public ICollection<Locacao> Locacao { get; private set; }
        public Filme(string titulo, int classificacaoIndicativa, bool lancamento)
        {
           
            Titulo = titulo;
            ClassificacaoIndicativa = classificacaoIndicativa;
            Lancamento = lancamento;
        }
        public void Atualizar(string titulo, int classificacaoIndicativa, bool lancamento) 
        {
            Titulo = titulo;
            ClassificacaoIndicativa = classificacaoIndicativa;
            Lancamento = lancamento;
        }
    }
}
