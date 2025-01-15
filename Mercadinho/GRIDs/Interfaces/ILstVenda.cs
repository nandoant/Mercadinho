using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadinho.GRIDs
{
    public interface ILstVenda
    {
        // Properties
        int Id { get; set; }
        string NomedoCliente { get; set; }
        DateTime DataDaCompra { get; set; }
        decimal ValorTotal { get; set; }

        // Events
        event EventHandler Deletar;
        event EventHandler VerProdutos;
    }
}
