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
        #region Fields and Constants
        private static VendaView _instance;
        private ClienteSelecaoPresenter _clienteSelecaoPresenter; 

        private readonly VendaMainPresenter _mainPresenter;
        private readonly ProdutoRepository _produtoRepository = new ProdutoRepository();
        private readonly IClienteRepository _clienteRepository = new ClienteRepository();
        
        private Cliente _clienteSelecionado;
        private int _paginaClienteAtual = 1;
        private int _paginaVendaAtual = 1;
        private int _paginaProdutoAtual = 1;
        private const int ITENS_POR_PAGINA = 5;
        private IEnumerable<Produto> _produtosAtuais;
        private Dictionary<int, LstProduto> _carrinho = new Dictionary<int, LstProduto>();
        private bool _isCarrinhoView = false;
        private List<Produto> _produtosEmMemoria;
        private VendaRepository _vendaRepository = new VendaRepository();
        private VendaProdutoRepository _vendaProdutoRepository = new VendaProdutoRepository();
        private int _paginaCarrinhoAtual = 1;

        #endregion

        #region Properties and Interface Implementations
        public Cliente ClienteSelecionado
        {
            get => _clienteSelecionado;
            set => _clienteSelecionado = value;
        }

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
            get => _paginaVendaAtual;
            set
            {
                _paginaVendaAtual = value;
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
        public event EventHandler VendaFinalizada;
        #endregion

        #region Constructor and Initialization
        public VendaView()
        {
            InitializeComponent();
            ConfigurarFormulario();
            AssociarEventos();
            ConfigurarClienteSelecao();
            InicializarProdutos();
            btnPaginasP.Enabled = false;

        _clienteSelecaoPresenter = new ClienteSelecaoPresenter(
            this, 
            this, 
            _clienteRepository
        );
        btnFinalizar.Click += (s, e) => FinalizarVenda();

        txtBoxProduto.textBox.GotFocus += (s, e) => 
        {
            if (_isCarrinhoView)
                txtBoxProduto.textBox.Text = "Pesquisar no carrinho...";
            else
                txtBoxProduto.textBox.Text = "Nome ou ID do produto";
        };

        }

        private void ConfigurarFormulario()
        {
            btnPaginasV.Enabled = false;
            btnPaginasC.Enabled = false;
            btnPaginasP.Enabled = false;
            PaginaAtual = 1;
        }

        private void AssociarEventos()
        {
            // Eventos gerais
            btnPesquisarV.Click += (s, e) => Pesquisar?.Invoke(this, EventArgs.Empty);
            btnNovaVenda.Click += (s, e) => 
            {
                NovaVenda?.Invoke(this, EventArgs.Empty); 
                MostrarSelecaoCliente(); 
            };
            
            // Eventos de paginação
            btnAvancarV.Click += (s, e) => ProximaPagina?.Invoke(this, EventArgs.Empty);
            btnVoltarV.Click += (s, e) => PaginaAnterior?.Invoke(this, EventArgs.Empty);
            
            // Eventos de pesquisa
            txtBoxVendaV.textBox.KeyDown += (s, e) => 
            { 
                if (e.KeyCode == Keys.Enter) Pesquisar?.Invoke(this, EventArgs.Empty); 
            };

            btn_Voltar.Click += (s, e) => MostrarSelecaoCliente();

            buttonVoltar.Click += (s, e) => MostrarListaVendas();

            // Eventos da grid
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
                if (e.KeyCode == Keys.Enter) Pesquisar?.Invoke(this, EventArgs.Empty); 
            };
        }

        private void InicializarProdutos()
        {
            _produtosEmMemoria = _produtoRepository.Listar().ToList(); // Carrega em memória
            _produtosAtuais = _produtosEmMemoria;
            ConfigurarEventosProdutos();
            ExibirProdutos();
        }

        private void ConfigurarEventosProdutos()
        {
            btnAvancarP.Click += (s, e) => 
            { 
                if (_isCarrinhoView)
                {
                    _paginaCarrinhoAtual++;
                    ExibirCarrinhoComFiltro(txtBoxProduto.textBox.Text.Trim());
                }
                else
                {
                    _paginaProdutoAtual++;
                    ExibirProdutos();
                }
            };
            
            btnVoltarP.Click += (s, e) => 
            { 
                if (_isCarrinhoView)
                {
                    _paginaCarrinhoAtual--;
                    ExibirCarrinhoComFiltro(txtBoxProduto.textBox.Text.Trim());
                }
                else
                {
                    _paginaProdutoAtual--;
                    ExibirProdutos();
                }
            };
            btnPesquisarProduto.Click += (s, e) => { _paginaProdutoAtual = 1; ExibirProdutos(); };
            txtBoxProduto.textBox.KeyDown += (s, e) => 
            { 
                if (e.KeyCode == Keys.Enter)
                {
                    if (_isCarrinhoView)
                        ExibirCarrinhoComFiltro(txtBoxProduto.textBox.Text.Trim()); // Novo método para carrinho
                    else
                        ExibirProdutos(); // Mantém a lógica original para produtos
                }
            };

            labelCarrinho.Click += (sender, e) => 
            {
                if (!_isCarrinhoView) // Só alterna se já não estiver no carrinho
                {
                    AlternarVisualizacao();
                    labelPagina.Text = "Carrinho";
                    label16.Visible = false;
                }
            };

            labelProdutos.Click += (sender, e) => 
            {
                if (_isCarrinhoView) // Só alterna se já estiver no carrinho
                {
                    AlternarVisualizacao();
                    labelPagina.Text = "Produtos";
                    label16.Visible = true;
                }
            };
        }
        #endregion

        #region Navigation Methods
        public void MostrarListaVendas() => tabControlClientes.SelectedTab = tabListaVendas;
        public void MostrarSelecaoCliente()
        {
            tabControlClientes.SelectedTab = tabDetalhesClientes;
            _clienteSelecaoPresenter.RecarregarClientes(); // Recarrega a lista de clientes
        }
        public void MostrarProdutos() => tabControlClientes.SelectedTab = tabEscolherProdutos;
        #endregion

        #region Display Methods
        public void ExibirClientes(List<Cliente> clientes)
        {
            GridClientes.Controls.Clear();
            foreach (var cliente in clientes)
            {
                var lstCliente = new LstCliente(cliente, true);
                lstCliente.Excluir += (s, e) => 
                {
                    ResetarCarrinho(); // Reseta o carrinho
                    OnClienteSelecionado?.Invoke(this, cliente);
                    labelClienteNome.Text = cliente.Nome;
                };
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

        #region Product Management
        private void ExibirProdutos()
        {
            GridProdutos.Controls.Clear();
            var produtos = ObterProdutosPaginados();

            foreach (var produto in produtos)
            {
                var lstProduto = new LstProduto(produto, true);
                lstProduto.Excluir += (s, e) => AdicionarAoCarrinho((LstProduto)s);
                GridProdutos.Controls.Add(lstProduto);
            }

            AtualizarUIProdutos();
        }

        private IEnumerable<Produto> ObterProdutosPaginados()
        {
            var termoPesquisa = txtBoxProduto.textBox.Text.Trim();
            
            if (!string.IsNullOrEmpty(termoPesquisa) && !termoPesquisa.Equals("Nome ou ID do produto", StringComparison.OrdinalIgnoreCase))
            {
                // Filtra na lista em memória
                _produtosAtuais = _produtosEmMemoria
                    .Where(p => p.Nome.IndexOf(termoPesquisa, StringComparison.OrdinalIgnoreCase) >= 0 || 
                                p.Id.ToString() == termoPesquisa)
                    .ToList();
            }
            else
            {
                _produtosAtuais = _produtosEmMemoria; // Usa a lista completa
            }

            return _produtosAtuais
                .Skip((_paginaProdutoAtual - 1) * ITENS_POR_PAGINA)
                .Take(ITENS_POR_PAGINA);
        }
        #endregion

        #region Shopping Cart Management
        private void AlternarParaCarrinho(object sender, EventArgs e)
        {
            if (!_isCarrinhoView)
            {
                AlternarVisualizacao();
                labelPagina.Text = "Carrinho";
            }
        }

        private void AlternarParaProdutos(object sender, EventArgs e)
        {
            if (_isCarrinhoView)
            {
                AlternarVisualizacao();
                labelPagina.Text = "Produtos";
            }
        }

        private void AlternarVisualizacao()
        {
            _isCarrinhoView = !_isCarrinhoView;
            
            if (_isCarrinhoView)
                _paginaCarrinhoAtual = 1;
            else
                _paginaProdutoAtual = 1;
            
            txtBoxProduto.textBox.Text = ""; 
            
            if (_isCarrinhoView)
            {
                ExibirCarrinhoComFiltro(""); 
                AjustarUIparaCarrinho();
            }
            else
            {
                ExibirProdutos(); 
                AjustarUIparaProdutos();
            }
            
            
            labelPagina.Text = _isCarrinhoView ? "Carrinho" : "Produtos";
            label16.Visible = !_isCarrinhoView;
            
            
            AtualizarUIProdutos();
        }

        private void AjustarUIparaCarrinho()
        {
            button5.Location = new Point(541, 97);
            labelCarrinho.BackColor = Color.White;
            labelProdutos.BackColor = Color.FromArgb(190, 192, 189);
            
        }

        private void AjustarUIparaProdutos()
        {
            button5.Location = new Point(451, 97);
            labelProdutos.BackColor = Color.White;
            labelCarrinho.BackColor = Color.FromArgb(190, 192, 189);
            
        }

        private void ExibirCarrinho()
        {
            ExibirCarrinhoComFiltro(""); 
        }

        private LstProduto CriarItemCarrinho(LstProduto produto)
        {
            var lst = new LstProduto(new Produto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                PrecoUnitario = produto.preco,
                Descricao = produto.Descricao,
                Marca = produto.Marca,
                Modelo = produto.Modelo,
                QuantidadeEmEstoque = produto.QuantidadeDisponivel
            }, false); //

            lst.QuantidadeCliente = produto.QuantidadeCliente;
            lst.Excluir += (s, e) => RemoverDoCarrinho(produto);
            return lst;
        }

        private void FinalizarVenda()
        {
            // Validações
            if (_clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente antes de finalizar a venda.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_carrinho.Count == 0)
            {
                MessageBox.Show("Adicione produtos ao carrinho antes de finalizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Cria a venda
                var venda = new Venda
                {
                    IdCliente = _clienteSelecionado.Id,
                    DataCompra = DateTime.Now,
                    Produtos = new List<Produto>() // Opcional, apenas para compatibilidade
                };

                // Insere a venda no banco e obtém o ID gerado
                int vendaId = _vendaRepository.Inserir(venda);

                // Prepara os itens da vendaProduto
                var itensVenda = _carrinho.Values.Select(item => 
                    new VendaProduto(
                        vendaId,
                        item.Id,
                        item.QuantidadeCliente,
                        item.preco
                    )).ToList();

                // Insere os itens no banco
                _vendaProdutoRepository.AdicionarItens(vendaId, itensVenda);

                // Atualiza estoque no banco
                foreach (var produto in _produtosEmMemoria)
                {
                    _produtoRepository.Atualizar(produto);
                }

                // Limpa o carrinho e recarrega dados
                _carrinho.Clear();
                _produtosEmMemoria = _produtoRepository.Listar().ToList();
                _clienteSelecionado = null;
                labelClienteNome.Text = "Nenhum cliente selecionado";

                ExibirProdutos();
                MessageBox.Show("Venda finalizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabControlClientes.SelectedTab = tabListaVendas;
                
                // Disparar o evento para atualizar a lista
                VendaFinalizada?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao finalizar venda: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Cart Operations
        private void AdicionarAoCarrinho(LstProduto lstProduto)
        {
            // Valida a quantidade antes de prosseguir
            if (!ValidarQuantidade(lstProduto))
                return;

            var produtoEmMemoria = _produtosEmMemoria.FirstOrDefault(p => p.Id == lstProduto.Id);
            if (produtoEmMemoria == null) return;

            if (_carrinho.TryGetValue(lstProduto.Id, out var itemExistente))
            {
                int novaQuantidadeTotal = itemExistente.QuantidadeCliente + lstProduto.QuantidadeCliente;
                
                // Verifica se a soma excede o estoque
                if (novaQuantidadeTotal > produtoEmMemoria.QuantidadeEmEstoque)
                {
                    MessageBox.Show($"Quantidade total ({novaQuantidadeTotal}) excede o estoque disponível ({produtoEmMemoria.QuantidadeEmEstoque}).",
                        "Estoque Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                itemExistente.QuantidadeCliente = novaQuantidadeTotal;
                itemExistente.QuantidadeDisponivel = produtoEmMemoria.QuantidadeEmEstoque - novaQuantidadeTotal;
            }
            else
            {
                lstProduto.QuantidadeDisponivel = produtoEmMemoria.QuantidadeEmEstoque - lstProduto.QuantidadeCliente;
                _carrinho.Add(lstProduto.Id, lstProduto);
            }

            produtoEmMemoria.QuantidadeEmEstoque -= lstProduto.QuantidadeCliente;
            
            AtualizarLabelsCarrinho();
            MostrarMensagemAdicao(lstProduto);
        }

        private bool ValidarQuantidade(LstProduto produto)
        {
            if (produto.QuantidadeCliente <= 0)
            {
                MessageBox.Show("Por favor, insira uma quantidade válida maior que zero.", "Quantidade Inválida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var produtoEmMemoria = _produtosEmMemoria.FirstOrDefault(p => p.Id == produto.Id);
            if (produtoEmMemoria == null) return false;

            int quantidadeNoCarrinho = _carrinho.TryGetValue(produto.Id, out var item) ? item.QuantidadeCliente : 0;
            int quantidadeTotal = quantidadeNoCarrinho + produto.QuantidadeCliente;

            if (quantidadeTotal > produtoEmMemoria.QuantidadeEmEstoque)
            {
                MessageBox.Show($"Quantidade solicitada ({quantidadeTotal}) maior que disponível em estoque ({produtoEmMemoria.QuantidadeEmEstoque}).",
                    "Estoque Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void AtualizarEstoqueProduto(LstProduto produto)
        {
            produto.QuantidadeDisponivel -= produto.QuantidadeCliente;
            produto.QuantidadeCliente = 0;
        }

        private void MostrarMensagemAdicao(LstProduto produto)
        {
            MessageBox.Show($"Produto adicionado(s) ao carrinho!", "Sucesso",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RemoverDoCarrinho(LstProduto produto)
        {
            if (_carrinho.ContainsKey(produto.Id))
            {
                var produtoEmMemoria = _produtosEmMemoria.FirstOrDefault(p => p.Id == produto.Id);
                if (produtoEmMemoria != null)
                {
                    produtoEmMemoria.QuantidadeEmEstoque += _carrinho[produto.Id].QuantidadeCliente;
                    // Atualiza a quantidade disponível no LstProduto do carrinho
                    produto.QuantidadeDisponivel = produtoEmMemoria.QuantidadeEmEstoque;
                }
                _carrinho.Remove(produto.Id);
                AtualizarExibicao();
            }
        }

        private void RestaurarEstoqueProduto(LstProduto produto)
        {
            var produtoOriginal = _produtosAtuais.FirstOrDefault(p => p.Id == produto.Id);
            if (produtoOriginal != null)
            {
                produtoOriginal.QuantidadeEmEstoque += 1;
                produto.QuantidadeDisponivel += 1; 
            }
        }

        private void AtualizarExibicao()
        {
            if (_isCarrinhoView) ExibirCarrinho();
            else ExibirProdutos();
        }
        private void ExibirCarrinhoComFiltro(string termoPesquisa)
        {
            GridProdutos.Controls.Clear();
            var carrinhoFiltrado = FiltrarCarrinho(termoPesquisa).ToList();
            
            var itensPagina = carrinhoFiltrado
                .Skip((_paginaCarrinhoAtual - 1) * ITENS_POR_PAGINA)
                .Take(ITENS_POR_PAGINA);
            
            foreach (var produto in itensPagina)
            {
                var lstProduto = CriarItemCarrinho(produto);
                GridProdutos.Controls.Add(lstProduto);
            }
            
            AtualizarLabelsCarrinho();
            AtualizarUIPaginacaoCarrinho(carrinhoFiltrado.Count);
        }

        private void AtualizarUIPaginacaoCarrinho(int totalItens)
        {
            int totalPaginas = (int)Math.Ceiling(totalItens / (double)ITENS_POR_PAGINA);
            
            btnAvancarP.Enabled = _paginaCarrinhoAtual < totalPaginas;
            btnVoltarP.Enabled = _paginaCarrinhoAtual > 1;
            
            btnPaginasP.Text = _isCarrinhoView 
                ? _paginaCarrinhoAtual.ToString() 
                : _paginaProdutoAtual.ToString();
            
            AtualizarCoresBotoes(btnAvancarP, btnAvancarP.Enabled);
            AtualizarCoresBotoes(btnVoltarP, btnVoltarP.Enabled);
        }
        private void ResetarCarrinho()
        {
            // Restaurar estoque dos produtos no carrinho
            foreach (var item in _carrinho.Values)
            {
                var produto = _produtosEmMemoria.FirstOrDefault(p => p.Id == item.Id);
                if (produto != null)
                {
                    produto.QuantidadeEmEstoque += item.QuantidadeCliente;
                }
            }
            
            _carrinho.Clear(); // Limpa o carrinho
            AtualizarLabelsCarrinho(); // Atualiza totais
            
            if (_isCarrinhoView)
                ExibirCarrinhoComFiltro(""); // Atualiza a exibição se estiver na view do carrinho
            else
                ExibirProdutos(); // Atualiza a lista de produtos
        }

        private IEnumerable<LstProduto> FiltrarCarrinho(string termo)
        {
            if (string.IsNullOrWhiteSpace(termo))
                return _carrinho.Values; // Retorna os valores, não o dicionário

            return _carrinho.Values.Where(p =>
                p.Nome.IndexOf(termo, StringComparison.OrdinalIgnoreCase) >= 0 ||
                p.Id.ToString() == termo
            );
        }
        #endregion

        #region Utility Methods
        public static VendaView GetInstance(Form parentContainer)
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new VendaView { MdiParent = parentContainer };
                ConfigurarInstancia();
            }
            else
            {
                RestaurarInstancia();
            }
            return _instance;
        }

        private static void ConfigurarInstancia()
        {
            _instance.FormBorderStyle = FormBorderStyle.None;
            _instance.Dock = DockStyle.Fill;
        }

        private static void RestaurarInstancia()
        {
            if (_instance.WindowState == FormWindowState.Minimized)
                _instance.WindowState = FormWindowState.Normal;
            _instance.BringToFront();
        }

        private string GetClienteName(int clienteId)
        {
            try
            {
                return _clienteRepository.ObterPorvalor(clienteId.ToString()).FirstOrDefault()?.Nome 
                    ?? $"Cliente não encontrado ({clienteId})";
            }
            catch
            {
                return $"Erro ao buscar cliente ({clienteId})";
            }
        }

        private void AtualizarUIProdutos()
        {
            btnPaginasP.Text = _isCarrinhoView 
                ? _paginaCarrinhoAtual.ToString() 
                : _paginaProdutoAtual.ToString();
            
            if (!_isCarrinhoView)
            {
                AtualizarBotoesPaginacao();
            }
        }

        private void AtualizarBotoesPaginacao()
        {
            var totalPaginas = (int)Math.Ceiling(_produtosAtuais.Count() / (double)ITENS_POR_PAGINA);
            
            btnAvancarP.Enabled = _paginaProdutoAtual < totalPaginas;
            btnVoltarP.Enabled = _paginaProdutoAtual > 1;

            AtualizarCoresBotoes(btnAvancarP, btnAvancarP.Enabled);
            AtualizarCoresBotoes(btnVoltarP, btnVoltarP.Enabled);
        }

        private void AtualizarCoresBotoes(ReaLTaiizor.Controls.Button btn, bool habilitado)
        {
            btn.InactiveColor = habilitado ? Color.FromArgb(32, 34, 37) : Color.LightGray;
            btn.BorderColor = btn.InactiveColor;
        }

        private void AtualizarLabelsCarrinho()
        {
            int totalItens = _carrinho.Values.Sum(item => item.QuantidadeCliente);
            labelTotalProdutos.Text = totalItens.ToString();
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            decimal total = _carrinho.Values.Sum(item => 
                (decimal)(item.preco * item.QuantidadeCliente) // Preço * Quantidade
            );
            labelTotalVenda.Text = $"R$ {total:F2}";
        }
        #endregion

        #region Pagination Configuration
        public void AtualizarPaginacao(bool temProximaPagina, bool temPaginaAnterior)
        {
            AtualizarBotaoPaginacao(btnAvancarV, temProximaPagina);
            AtualizarBotaoPaginacao(btnVoltarV, temPaginaAnterior);
        }

        public void AtualizarPaginacaoClientes(bool temProxima, bool temAnterior)
        {
            AtualizarBotaoPaginacao(btnAvancarC, temProxima);
            AtualizarBotaoPaginacao(btnVoltarC, temAnterior);
        }
        private void AtualizarBotaoPaginacao(ReaLTaiizor.Controls.Button btn, bool habilitado)
        {
            btn.Enabled = habilitado;
            btn.InactiveColor = habilitado ? Color.FromArgb(32, 34, 37) : Color.LightGray;
            btn.BorderColor = btn.InactiveColor;
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