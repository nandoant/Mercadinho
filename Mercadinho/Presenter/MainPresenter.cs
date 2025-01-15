using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mercadinho.Repository;
using Mercadinho.View;

namespace Mercadinho.Presenter
{
    public class MainPresenter
    {
        private IMainView view;
        
        public MainPresenter(IMainView view)
        {
            this.view = view;
            view.MostrarClientes += delegate { MostrarViewClientes(); };
            view.MostrarProdutos += delegate { MostrarViewProdutos(); };
            //view.MostrarVendas += delegate { MostrarViewVendas(); };
        }

        private void MostrarViewClientes()
        {
            IClienteView clienteView = ClienteView.GetInstance((Form)view);
            IClienteRepository clienteRepository = new ClienteRepository();
            new ClientePresenter(clienteRepository, clienteView);
        }

        private void MostrarViewProdutos()
        {
            IProdutoView produtoView = ProdutoView.GetInstance((Form)view);
            IProdutoRepository produtoRepository = new ProdutoRepository();
            new ProdutoPresenter(produtoRepository, produtoView);
        }

        /*private void MostrarViewVendas()
        {
            IVendaView vendaView = VendaView.GetInstance((Form)view);
            IVendaRepository vendaRepository = new VendaRepository();
            new VendaPresenter(vendaRepository, vendaView);
        }*/
    }
}
