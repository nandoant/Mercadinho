using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mercadinho.Model;

namespace Mercadinho.View.Interfaces
{
    public interface IVendaPrincipalView
    {
        void MostrarListaVendas();
        void MostrarSelecaoCliente();
        void MostrarProdutoCarrinho();
        void DefinirClienteSelecionado(Cliente cliente);
        void AtualizarTotal(decimal total);
    }
}
