using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadinho.Model
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }

        public Cliente()
        {
        }

        public Cliente(int id, string nome, int idade, string cpf)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
            Cpf = cpf;
        }
    }
}
