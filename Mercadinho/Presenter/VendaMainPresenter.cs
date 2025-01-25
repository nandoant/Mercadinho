using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mercadinho.Repository;
using Mercadinho.View.Interfaces;

namespace Mercadinho.Presenter
{
    public class VendaMainPresenter
    {
        private IVendaMainView mainView;
        private VendaListPresenter listPresenter;
        private ClienteSelecaoPresenter clientePresenter;
        private IClienteRepository clienteRepo;
        private IVendaRepository vendaRepo;
        private bool isNovaVenda;

        public VendaMainPresenter(
            IVendaMainView mainView,
            ISelecaoClienteView clienteView,
            IListaVendaView listaView,
            IClienteRepository clienteRepo,
            IVendaRepository vendaRepo)
        {
            this.mainView = mainView;
            this.clienteRepo = clienteRepo;
            this.vendaRepo = vendaRepo;

            listPresenter = new VendaListPresenter(listaView, vendaRepo, clienteRepo);
            clientePresenter = new ClienteSelecaoPresenter(clienteView, mainView, clienteRepo);

            ConfigurarEventos();
            IniciarFluxo();
        }

        private void ConfigurarEventos()
        {
            listPresenter.NovaVendaClick += HandleNovaVenda;
        }

        private void HandleNovaVenda(object sender, EventArgs e)
        {
            isNovaVenda = true;
            mainView.ClienteSelecionado = null;
            mainView.MostrarSelecaoCliente();
        }

        private void IniciarFluxo()
        {
            isNovaVenda = false;
            mainView.MostrarListaVendas();
        }
    }
}
