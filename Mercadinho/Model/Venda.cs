using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadinho.Model
{
    public class Venda
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public List<Produto> Produtos { get; set; }
        public DateTime DataCompra { get; set; }
        public decimal ValorTotal { get; set; }

        public Venda(int id, int idCliente, List<Produto> produtos, DateTime data)
        {
            this.Id = id;
            this.IdCliente = idCliente;
            this.Produtos = produtos;
            this.DataCompra = data;
            this.ValorTotal = getValorTotal();
        }

        private decimal getValorTotal()
        {
            return Produtos.Sum(produto => produto.Subtotal);
        }
    }
}
