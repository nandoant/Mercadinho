using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadinho.Model
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }

        public Produto() { }

        public Produto(int id, string nome, double preco, string descricao, string marca, string modelo)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Descricao = descricao;
            Marca = marca;
            Modelo = modelo;
        }
    }
}
