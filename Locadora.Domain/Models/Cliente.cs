using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Domain.Models
{
    public class Cliente
    {
        public Cliente(){  }

        public int Id { get;  private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public DateTime DataNascimento { get; private set; }

        public Cliente( string name, string cpf, DateTime dataNascimento)
        {
            Nome = name;
            CPF = cpf;
            DataNascimento = dataNascimento;
        }
        public void Atualizar(string nome, DateTime dataNascimento) 
        {
            Nome = nome;
            DataNascimento = dataNascimento;
        }
    }
}
