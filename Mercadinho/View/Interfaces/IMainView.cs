using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadinho.View
{
    public interface IMainView
    {
        event EventHandler MostrarProdutos;
        event EventHandler MostrarClientes;
        event EventHandler MostrarVendas;
        void FecharViewsAbertas();
    }
}
