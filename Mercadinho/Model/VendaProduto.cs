using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadinho.Model
{
    public class VendaProduto
    {
        public int VendaId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public double PrecoUnitario { get; set; }

        public VendaProduto(int vendaId, int produtoId, int quantidade, double precoUnitario)
        {
            VendaId = vendaId;
            ProdutoId = produtoId;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }

        public decimal CalcularSubtotal()
        {
            return (decimal)(Quantidade * PrecoUnitario);
        }
    }
}
