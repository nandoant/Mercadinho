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
        #region Fields and Properties
        private static VendaView _instance;
        private readonly VendaMainPresenter _mainPresenter;
        private Cliente _clienteSelecionado;
        private int _paginaClienteAtual = 1;
        private int _paginaVendaAtual = 1;
        private int _paginaAtual = 1;
        private IClienteRepository _clienteRepository = new ClienteRepository();

        public Cliente ClienteSelecionado 
        { 
            get => _clienteSelecionado;
            set => _clienteSelecionado = value;
        }
        #endregion

        #region Interface Implementations
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

        public int PaginaAtual
        {
            get => _paginaAtual;
            set
            {
                _paginaAtual = value;
                btnPaginasV.Text = value.ToString();
            }
        }
        #endregion

        #region Events
        public event EventHandler Pesquisar;
        public event EventHandler ProximaPagina;
        public event EventHandler PaginaAnterior;
        public event EventHandler NovaVenda;
        public event EventHandler<int> DeletarVenda;
        public event EventHandler VerProdutos;
        public event EventHandler<Cliente> OnClienteSelecionado;
        #endregion

        #region Constructor and Initialization
        public VendaView()
        {
            InitializeComponent();
            ConfigurarFormulario();
            AssociarEventos();
            ConfigurarClienteSelecao();
            btnPaginasP.Enabled = false;

            _mainPresenter = new VendaMainPresenter(
                this,
                this,
                this,
                _clienteRepository,
                new VendaRepository()
            );
            btnPaginasC.Enabled = false;

                btnAvancarP.Click += (s, e) => {
        _paginaProdutoAtual++;
        exibirProdutos();
    };

    btnVoltarP.Click += (s, e) => {
        _paginaProdutoAtual--;
        exibirProdutos();
    };

btnPesquisarProduto.Click += (s, e) => {
    _paginaProdutoAtual = 1;
    exibirProdutos();
};

txtBoxProduto.textBox.KeyDown += (s, e) => {
    if (e.KeyCode == Keys.Enter)
    {
        _paginaProdutoAtual = 1;
        exibirProdutos();
    }
};
            _produtosAtuais = _produtoRepository.Listar();
            exibirProdutos();
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

        private void ConfigurarClienteSelecao()
        {
            btnPesquisarCliente.Click += (s, e) => Pesquisar?.Invoke(this, EventArgs.Empty);
            btnAvancarC.Click += (s, e) => ProximaPagina?.Invoke(this, EventArgs.Empty);
            btnVoltarC.Click += (s, e) => PaginaAnterior?.Invoke(this, EventArgs.Empty);
            txtBoxCliente.textBox.KeyDown += (s, e) => 
            { 
                if (e.KeyCode == Keys.Enter) 
                    Pesquisar?.Invoke(this, EventArgs.Empty); 
            };
        }
        #endregion

        #region Core Methods
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
                lstVenda.VerProdutos += (s, e) => VerProdutos?.Invoke(lstVenda, e);
                GridVendas.Controls.Add(lstVenda);
            }
        }
        #endregion

        #region Utility Methods
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
        #endregion

#region Finalizar Venda
private readonly ProdutoRepository _produtoRepository = new ProdutoRepository();
private int _paginaProdutoAtual = 1;
private const int ITENS_POR_PAGINA = 5;
private IEnumerable<Produto> _produtosAtuais;
private List<LstProduto> _carrinho = new List<LstProduto>(); // Lista para o carrinho

private IEnumerable<Produto> ObterProdutosPaginados()
{
    var termoPesquisa = txtBoxProduto.textBox.Text.Trim();
    
    // Se o texto for vazio ou igual ao placeholder, mostra todos os produtos
    if (string.IsNullOrEmpty(termoPesquisa) || 
        termoPesquisa.Equals("Nome ou ID do produto", StringComparison.OrdinalIgnoreCase))
    {
        _produtosAtuais = _produtoRepository.Listar();
    }
    else 
    {
        // Caso contrário, realiza a pesquisa
        _produtosAtuais = _produtoRepository.ObterPorvalor(termoPesquisa);
    }

    return _produtosAtuais
        .Skip((_paginaProdutoAtual - 1) * ITENS_POR_PAGINA)
        .Take(ITENS_POR_PAGINA);
}

private void AdicionarAoCarrinho(LstProduto produto)
{
    // Valida quantidade digitada
    if (!int.TryParse("" + produto.QuantidadeCliente, out int quantidadeSolicitada) || quantidadeSolicitada <= 0)
    {
        MessageBox.Show("Por favor, insira uma quantidade válida maior que zero.", "Quantidade Inválida",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }

    // Valida estoque disponível
    if (quantidadeSolicitada > produto.quantidadeDisponivel)
    {
        MessageBox.Show($"Quantidade solicitada maior que disponível em estoque ({produto.quantidadeDisponivel}).", 
            "Estoque Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }

    // Adiciona ao carrinho a quantidade especificada
    for (int i = 0; i < quantidadeSolicitada; i++)
    {
        _carrinho.Add(produto);
    }

    // Atualiza interface
    AtualizarLabelsCarrinho();
    MessageBox.Show($"{quantidadeSolicitada}x {produto.Nome} adicionado(s) ao carrinho!", "Sucesso",
        MessageBoxButtons.OK, MessageBoxIcon.Information);

    produto.QuantidadeCliente = 0;
    produto.QuantidadeDisponivel -= quantidadeSolicitada;
        }

public void exibirProdutos()
{
    GridProdutos.Controls.Clear();

    var produtos = ObterProdutosPaginados();
    foreach (var produto in produtos)
    {
        var lstProduto = new LstProduto(produto, true);
        lstProduto.Excluir += (s, e) =>
        {
            if (s is LstProduto produtoClicado)
            {
                AdicionarAoCarrinho(produtoClicado);
            }
        };

        GridProdutos.Controls.Add(lstProduto);
    }

    btnPaginasP.Text = _paginaProdutoAtual.ToString();
    AtualizarBotoesPaginacao();
}

private void AtualizarBotoesPaginacao()
{
    var totalPaginas = Math.Ceiling(_produtosAtuais.Count() / (double)ITENS_POR_PAGINA);
    
    btnAvancarP.Enabled = _paginaProdutoAtual < totalPaginas;
    btnVoltarP.Enabled = _paginaProdutoAtual > 1;

    btnAvancarP.InactiveColor = btnAvancarP.Enabled 
        ? Color.FromArgb(32, 34, 37) 
        : Color.LightGray;
    
    btnVoltarP.InactiveColor = btnVoltarP.Enabled 
        ? Color.FromArgb(32, 34, 37) 
        : Color.LightGray;

    btnAvancarP.BorderColor = btnAvancarP.InactiveColor;
    btnVoltarP.BorderColor = btnVoltarP.InactiveColor;
}

private void AtualizarLabelsCarrinho()
{
    labelTotalProdutos.Text = _carrinho.Count.ToString();
    CalcularTotal();
}

private void CalcularTotal()
{
    if (_carrinho.Count > 0)
    {
        double total = _carrinho.Sum(item => item.preco);
        labelTotalVenda.Text = $"R$ {total:F2}";
        labelTotalProdutos.Text = _carrinho.Count.ToString();
    }
    else
    {
        labelTotalVenda.Text = "R$ 0,00";
        labelTotalProdutos.Text = "0";
    }
}
#endregion

            #region Empty Event Handlers
        private void GridVendas_Paint(object sender, PaintEventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        #endregion
    }
}
