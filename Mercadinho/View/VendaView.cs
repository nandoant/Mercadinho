using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Mercadinho.GRIDs;
using Mercadinho.Model;
using Mercadinho.Presenter;
using Mercadinho.Repository;
using Mercadinho.View.Interfaces;

namespace Mercadinho.View
{
    public partial class VendaView : Form, IListaVendaView, ISelecaoClienteView, IVendaMainView
    {
        private readonly VendaMainPresenter _mainPresenter;
        private Cliente _clienteSelecionado;
        private int _paginaClienteAtual = 1;
        private int _paginaVendaAtual = 1;
        private int _paginaAtual = 1;
        private IClienteRepository _clienteRepository = new ClienteRepository();

    string ISelecaoClienteView.TextoPesquisa 
    { 
        get => txtBoxCliente.textBox.Text; 
        set => txtBoxCliente.textBox.Text = value; 
    }

        int ISelecaoClienteView.PaginaAtual 
        { 
            get => _paginaClienteAtual;
            set 
            { 
                _paginaClienteAtual = value;
                btnPaginasC.Text = value.ToString();
            }
        }
        public string TextoPesquisa 
        { 
            get => txtBoxVendaV.textBox.Text;
            set => txtBoxVendaV.textBox.Text = value;
        }

        public Cliente ClienteSelecionado 
        { 
            get => _clienteSelecionado;
            set => _clienteSelecionado = value;
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
        public event EventHandler<Cliente> OnClienteSelecionado;

    public void MostrarListaVendas()
    {
        tabControlClientes.SelectedTab = tabListaVendas;
    }

    public void MostrarSelecaoCliente()
    {
        tabControlClientes.SelectedTab = tabDetalhesClientes;
    }

    public void MostrarProdutos()
    {
        tabControlClientes.SelectedTab = tabEscolherProdutos;
    }

        public void ExibirClientes(List<Cliente> clientes)
    {
        GridClientes.Controls.Clear();
        foreach (var cliente in clientes)
        {
            var lstCliente = new LstCliente(cliente, true);
            lstCliente.Excluir += (s, e) => OnClienteSelecionado?.Invoke(this, cliente);
            lstCliente.Excluir += (s, e) => labelClienteNome.Text = _clienteSelecionado.Nome;
            GridClientes.Controls.Add(lstCliente);
        }
    }

        public VendaView()
        {
            InitializeComponent();
            ConfigurarFormulario();
            AssociarEventos();
            ConfigurarClienteSelecao();

            _mainPresenter = new VendaMainPresenter(
            this,
            this,
            this,
            _clienteRepository,
            new VendaRepository()
            );
            btnPaginasC.Enabled = false;
        }

        public void AtualizarPaginacaoClientes(bool temProxima, bool temAnterior)
        {
            if (!temProxima)
            {
                btnAvancarC.InactiveColor = Color.LightGray;
                btnAvancarC.BorderColor = Color.LightGray;
            }
            else 
            {
                btnAvancarC.InactiveColor = Color.FromArgb(32, 34, 37);
                btnAvancarC.BorderColor = Color.FromArgb(32, 34, 37);
            }

            if (!temAnterior)
            {
                btnVoltarC.InactiveColor = Color.LightGray;
                btnVoltarC.BorderColor = Color.LightGray;
            }
            else
            {
                btnVoltarC.InactiveColor = Color.FromArgb(32, 34, 37);
                btnVoltarC.BorderColor = Color.FromArgb(32, 34, 37);
            }
            
            btnAvancarC.Enabled = temProxima;
            btnVoltarC.Enabled = temAnterior;
        }


        private void ConfigurarClienteSelecao()
        {
            // Adiciona eventos específicos para seleção de cliente
            btnPesquisarCliente.Click += (s, e) => Pesquisar?.Invoke(this, EventArgs.Empty);
            btnAvancarC.Click += (s, e) => ProximaPagina?.Invoke(this, EventArgs.Empty);
            btnVoltarC.Click += (s, e) => PaginaAnterior?.Invoke(this, EventArgs.Empty);
            txtBoxCliente.textBox.KeyDown += (s, e) => 
            { 
                if (e.KeyCode == Keys.Enter) 
                    Pesquisar?.Invoke(this, EventArgs.Empty); 
            };
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
            try
            {
                var cliente = _clienteRepository.ObterPorvalor(clienteId.ToString()).FirstOrDefault();
                return cliente?.Nome ?? $"Cliente não encontrado ({clienteId})";
            }
            catch
            {
                return $"Erro ao buscar cliente ({clienteId})";
            }
        }

        public void AtualizarPaginacao(bool temProximaPagina, bool temPaginaAnterior)
        {
            if (!temProximaPagina)
            {
                btnAvancarV.InactiveColor = Color.LightGray;
                btnAvancarV.BorderColor = Color.LightGray;
            }
            else
            {
                btnAvancarV.InactiveColor = Color.FromArgb(32, 34, 37);
                btnAvancarV.BorderColor = Color.FromArgb(32, 34, 37);
            }

            if (!temPaginaAnterior)
            {
                btnVoltarV.InactiveColor = Color.LightGray;
                btnVoltarV.BorderColor = Color.LightGray;
            }
            else
            {
                btnVoltarV.InactiveColor = Color.FromArgb(32, 34, 37);
                btnVoltarV.BorderColor = Color.FromArgb(32, 34, 37);
            }
            
            btnAvancarV.Enabled = temProximaPagina;
            btnVoltarV.Enabled = temPaginaAnterior;
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
