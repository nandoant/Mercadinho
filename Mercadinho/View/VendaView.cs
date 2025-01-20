using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Mercadinho.GRIDs;
using Mercadinho.Model;
using Mercadinho.View.Interfaces;

namespace Mercadinho.View
{
    public partial class VendaView : Form, IListaVendaView
    {
        private int _paginaAtual = 1;

        public string TextoPesquisa 
        { 
            get => txtBoxVendaV.textBox.Text;
            set => txtBoxVendaV.textBox.Text = value;
        }

        public int PaginaAtual
        {
            get => _paginaAtual;
            set
            {
                _paginaAtual = value;
                btnPaginasV.Text = value.ToString();
            }
        }

        public event EventHandler Pesquisar;
        public event EventHandler ProximaPagina;
        public event EventHandler PaginaAnterior;
        public event EventHandler NovaVenda;
        public event EventHandler<int> DeletarVenda;
        public event EventHandler VerProdutos;

        public VendaView()
        {
            InitializeComponent();
            ConfigurarFormulario();
            AssociarEventos();
        }

        private void ConfigurarFormulario()
        {
            btnPaginasV.Enabled = false;
            PaginaAtual = 1;
        }

        private void AssociarEventos()
        {
            btnPesquisarV.Click += (s, e) => Pesquisar?.Invoke(this, EventArgs.Empty);
            btnNovaVenda.Click += (s, e) => NovaVenda?.Invoke(this, EventArgs.Empty);
            btnAvancarV.Click += (s, e) => ProximaPagina?.Invoke(this, EventArgs.Empty);
            btnVoltarV.Click += (s, e) => PaginaAnterior?.Invoke(this, EventArgs.Empty);
            txtBoxVendaV.textBox.KeyDown += (s, e) => 
            { 
                if (e.KeyCode == Keys.Enter) 
                    Pesquisar?.Invoke(this, EventArgs.Empty); 
            };
            GridVendas.Controls.OfType<LstVenda>().ToList().ForEach(lst => 
            lst.VerProdutos += (s, e) => VerProdutos?.Invoke(s, e));
        }

        public void ExibirVendas(List<Venda> vendas)
        {
            GridVendas.Controls.Clear();
            foreach (var venda in vendas)
            {
                var lstVenda = new LstVenda(
                    venda.Id,
                    GetClienteName(venda.IdCliente),
                    venda.DataCompra,
                    venda.ValorTotal
                );

                lstVenda.Deletar += (s, e) => DeletarVenda?.Invoke(this, venda.Id);
                lstVenda.VerProdutos += (s, e) => VerProdutos?.Invoke(lstVenda, e); // Add this line
                GridVendas.Controls.Add(lstVenda);
            }
        }

        private string GetClienteName(int clienteId)
        {
            // Implementar lógica para buscar nome do cliente
            return "Cliente " + clienteId;
        }

        public void AtualizarPaginacao(bool temProxima, bool temAnterior)
        {
            btnAvancarV.Enabled = temProxima;
            btnVoltarV.Enabled = temAnterior;
        }

        private static VendaView _instance;
        public static VendaView GetInstance(Form parentContainer)
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new VendaView();
                _instance.MdiParent = parentContainer;
                _instance.FormBorderStyle = FormBorderStyle.None;
                _instance.Dock = DockStyle.Fill;
            }
            else
            {
                if (_instance.WindowState == FormWindowState.Minimized)
                    _instance.WindowState = FormWindowState.Normal;
                _instance.BringToFront();
            }
            return _instance;
        }
    }
}
