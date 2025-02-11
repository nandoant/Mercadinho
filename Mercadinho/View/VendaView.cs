﻿using System;
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
        private static VendaView instance;
        private ClienteSelecaoPresenter clienteSelecaoPresenter; 

        private  ProdutoRepository produtoRepository = new ProdutoRepository();
        private  IClienteRepository clienteRepository = new ClienteRepository();
        
        private Cliente clienteSelecionado;
        private int paginaClienteAtual = 1;
        private int paginaVendaAtual = 1;
        private int paginaProdutoAtual = 1;
        private const int ITENS_POR_PAGINA = 5;
        private IEnumerable<Produto> produtosAtuais;
        private Dictionary<int, LstProduto> carrinho = new Dictionary<int, LstProduto>();
        private bool isCarrinhoView = false;
        private List<Produto> produtosEmMemoria;
        private VendaRepository vendaRepository = new VendaRepository();
        private VendaProdutoRepository vendaProdutoRepository = new VendaProdutoRepository();
        private int paginaCarrinhoAtual = 1;

        public Cliente ClienteSelecionado
        {
            get => clienteSelecionado;
            set => clienteSelecionado = value;
        }

        string ISelecaoClienteView.TextoPesquisa
        {
            get => txtBoxCliente.textBox.Text;
            set => txtBoxCliente.textBox.Text = value;
        }

        int ISelecaoClienteView.PaginaAtual
        {
            get => paginaClienteAtual;
            set
            {
                paginaClienteAtual = value;
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
            get => paginaVendaAtual;
            set
            {
                paginaVendaAtual = value;
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
        public event EventHandler VendaFinalizada;
        public VendaView()
        {
            InitializeComponent();
            ConfigurarFormulario();
            AssociarEventos();
            ConfigurarClienteSelecao();
            InicializarProdutos();
            btnPaginasP.Enabled = false;

        clienteSelecaoPresenter = new ClienteSelecaoPresenter(
            this, 
            this, 
            clienteRepository
        );
        btnFinalizar.Click += (s, e) => FinalizarVenda();

        txtBoxProduto.textBox.GotFocus += (s, e) => 
        {
            if (isCarrinhoView)
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
            
            btnPesquisarV.Click += (s, e) => Pesquisar?.Invoke(this, EventArgs.Empty);
            btnNovaVenda.Click += (s, e) => 
            {
                NovaVenda?.Invoke(this, EventArgs.Empty); 
                MostrarSelecaoCliente(); 
            };
            
            
            btnAvancarV.Click += (s, e) => ProximaPagina?.Invoke(this, EventArgs.Empty);
            btnVoltarV.Click += (s, e) => PaginaAnterior?.Invoke(this, EventArgs.Empty);
            
            
            txtBoxVendaV.textBox.KeyDown += (s, e) => 
            { 
                if (e.KeyCode == Keys.Enter) Pesquisar?.Invoke(this, EventArgs.Empty); 
            };

            btn_Voltar.Click += (s, e) => MostrarSelecaoCliente();

            buttonVoltar.Click += (s, e) => MostrarListaVendas();

            
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
            produtosEmMemoria = produtoRepository.Listar().ToList();
            produtosAtuais = produtosEmMemoria;
            ConfigurarEventosProdutos();
            ExibirProdutos();
        }

        private void ConfigurarEventosProdutos()
        {
            btnAvancarP.Click += (s, e) => 
            { 
                if (isCarrinhoView)
                {
                    paginaCarrinhoAtual++;
                    ExibirCarrinhoComFiltro(txtBoxProduto.textBox.Text.Trim());
                }
                else
                {
                    paginaProdutoAtual++;
                    ExibirProdutos();
                }
            };
            
            btnVoltarP.Click += (s, e) => 
            { 
                if (isCarrinhoView)
                {
                    paginaCarrinhoAtual--;
                    ExibirCarrinhoComFiltro(txtBoxProduto.textBox.Text.Trim());
                }
                else
                {
                    paginaProdutoAtual--;
                    ExibirProdutos();
                }
            };
            btnPesquisarProduto.Click += (s, e) => { paginaProdutoAtual = 1; ExibirProdutos(); };
            txtBoxProduto.textBox.KeyDown += (s, e) => 
            { 
                if (e.KeyCode == Keys.Enter)
                {
                    if (isCarrinhoView)
                        ExibirCarrinhoComFiltro(txtBoxProduto.textBox.Text.Trim());
                    else
                        ExibirProdutos(); 
                }
            };

            labelCarrinho.Click += (sender, e) => 
            {
                if (!isCarrinhoView) 
                {
                    AlternarVisualizacao();
                    labelPagina.Text = "Carrinho";
                    label16.Visible = false;
                }
            };

            labelProdutos.Click += (sender, e) => 
            {
                if (isCarrinhoView) 
                {
                    AlternarVisualizacao();
                    labelPagina.Text = "Produtos";
                    label16.Visible = true;
                }
            };
        }


        public void MostrarListaVendas() => tabControlClientes.SelectedTab = tabListaVendas;
        public void MostrarSelecaoCliente()
        {
            paginaProdutoAtual = 1;
            carrinho.Clear();
            ExibirProdutos();
            tabControlClientes.SelectedTab = tabDetalhesClientes;
            clienteSelecaoPresenter.RecarregarClientes();
        }
        public void MostrarProdutos() => tabControlClientes.SelectedTab = tabEscolherProdutos;

        public void ExibirClientes(List<Cliente> clientes)
        {
            GridClientes.Controls.Clear();
            foreach (var cliente in clientes)
            {
                var lstCliente = new LstCliente(cliente, true);
                lstCliente.Excluir += (s, e) => 
                {
                    ResetarCarrinho(); 
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
        private void ExibirProdutos()
        {
            GridProdutos.Controls.Clear();
            var produtos = ObterProdutosPaginados();

            foreach (var produto in produtos)
            {
                // Verifica se o produto está no carrinho
                int quantidadeNoCarrinho = carrinho.TryGetValue(produto.Id, out var itemCarrinho)
                    ? itemCarrinho.QuantidadeCliente
                    : 0;

                var lstProduto = new LstProduto(produto, true)
                {
                    QuantidadeDisponivel = produto.QuantidadeEmEstoque - quantidadeNoCarrinho
                };

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
                
                produtosAtuais = produtosEmMemoria
                    .Where(p => p.Nome.IndexOf(termoPesquisa, StringComparison.OrdinalIgnoreCase) >= 0 || 
                                p.Id.ToString() == termoPesquisa)
                    .ToList();
            }
            else
            {
                produtosAtuais = produtosEmMemoria; 
            }

            return produtosAtuais
                .Skip((paginaProdutoAtual - 1) * ITENS_POR_PAGINA)
                .Take(ITENS_POR_PAGINA);
        }

        private void AlternarVisualizacao()
        {
            isCarrinhoView = !isCarrinhoView;
            
            if (isCarrinhoView)
                paginaCarrinhoAtual = 1;
            else
                paginaProdutoAtual = 1;
            
            txtBoxProduto.textBox.Text = ""; 
            
            if (isCarrinhoView)
            {
                ExibirCarrinhoComFiltro(""); 
                AjustarUIparaCarrinho();
            }
            else
            {
                ExibirProdutos(); 
                AjustarUIparaProdutos();
            }
            
            
            labelPagina.Text = isCarrinhoView ? "Carrinho" : "Produtos";
            label16.Visible = !isCarrinhoView;
            
            
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
            }, false); 

            lst.QuantidadeCliente = produto.QuantidadeCliente;
            lst.Excluir += (s, e) => RemoverDoCarrinho(produto);
            return lst;
        }

        private void FinalizarVenda()
        {
            // Validações iniciais
            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente antes de finalizar a venda.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (carrinho.Count == 0)
            {
                MessageBox.Show("Adicione produtos ao carrinho antes de finalizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Atualizar estoque no banco de dados
                foreach (var itemCarrinho in carrinho.Values)
                {
                    var produtoNoBanco = produtoRepository.ObterPorId(itemCarrinho.Id);
                    if (produtoNoBanco != null)
                    {
                        // Subtrai a quantidade vendida do estoque real
                        produtoNoBanco.QuantidadeEmEstoque -= itemCarrinho.QuantidadeCliente;
                        produtoRepository.Atualizar(produtoNoBanco); // Persiste no banco
                    }
                }

                // 2. Criar registro da venda
                var venda = new Venda
                {
                    IdCliente = clienteSelecionado.Id,
                    DataCompra = DateTime.Now,
                    ValorTotal = (decimal)carrinho.Values.Sum(item => item.preco * item.QuantidadeCliente)
                };

                int vendaId = vendaRepository.Inserir(venda); // Insere no banco

                // 3. Registrar itens da venda
                var itensVenda = carrinho.Values.Select(item =>
                    new VendaProduto(
                        vendaId,
                        item.Id,
                        item.QuantidadeCliente,
                        item.preco
                    )).ToList();

                vendaProdutoRepository.AdicionarItens(vendaId, itensVenda);

                // 4. Atualizar estado local
                carrinho.Clear();
                produtosEmMemoria = produtoRepository.Listar().ToList(); // Recarrega dados frescos
                labelClienteNome.Text = "Nenhum cliente selecionado";

                // 5. Atualizar UI
                ExibirProdutos();
                AtualizarLabelsCarrinho();
                MessageBox.Show("Venda finalizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabControlClientes.SelectedTab = tabListaVendas;

                VendaFinalizada?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao finalizar venda: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AdicionarAoCarrinho(LstProduto lstProduto)
        {
            if (!ValidarQuantidade(lstProduto))
                return;

            var produtoEmMemoria = produtosEmMemoria.FirstOrDefault(p => p.Id == lstProduto.Id);
            if (produtoEmMemoria == null) return;

            if (carrinho.TryGetValue(lstProduto.Id, out var itemExistente))
            {
                itemExistente.QuantidadeCliente += lstProduto.QuantidadeCliente;
            }
            else
            {
                carrinho.Add(lstProduto.Id, lstProduto);
            }

            
            ExibirProdutos();
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

            var produtoEmMemoria = produtosEmMemoria.FirstOrDefault(p => p.Id == produto.Id);
            if (produtoEmMemoria == null) return false;

            // Obtém a quantidade JÁ reservada no carrinho, ok ?
            int quantidadeNoCarrinho = carrinho.TryGetValue(produto.Id, out var item) ? item.QuantidadeCliente : 0;

            // Calcula o estoque disponível REAL (estoque original - quantidade no carrinho)
            int estoqueDisponivel = produtoEmMemoria.QuantidadeEmEstoque - quantidadeNoCarrinho;

            // Verifica se a quantidade desejada excede o estoque disponível
            if (produto.QuantidadeCliente > estoqueDisponivel)
            {
                MessageBox.Show($"Quantidade solicitada ({produto.QuantidadeCliente}) excede o estoque disponível ({estoqueDisponivel}).",
                    "Estoque Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void MostrarMensagemAdicao(LstProduto produto)
        {
            MessageBox.Show($"Produto adicionado(s) ao carrinho!", "Sucesso",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RemoverDoCarrinho(LstProduto produto)
        {
            if (carrinho.ContainsKey(produto.Id))
            {
                carrinho.Remove(produto.Id);

                if (isCarrinhoView)
                    ExibirCarrinhoComFiltro(txtBoxProduto.textBox.Text.Trim());
                else
                    ExibirProdutos();

                AtualizarLabelsCarrinho();
            }
        }
        private void ExibirCarrinhoComFiltro(string termoPesquisa)
        {
            GridProdutos.Controls.Clear();
            var carrinhoFiltrado = FiltrarCarrinho(termoPesquisa).ToList();
            
            var itensPagina = carrinhoFiltrado
                .Skip((paginaCarrinhoAtual - 1) * ITENS_POR_PAGINA)
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
            
            btnAvancarP.Enabled = paginaCarrinhoAtual < totalPaginas;
            btnVoltarP.Enabled = paginaCarrinhoAtual > 1;
            
            btnPaginasP.Text = isCarrinhoView 
                ? paginaCarrinhoAtual.ToString() 
                : paginaProdutoAtual.ToString();
            
            AtualizarCoresBotoes(btnAvancarP, btnAvancarP.Enabled);
            AtualizarCoresBotoes(btnVoltarP, btnVoltarP.Enabled);
        }
        private void ResetarCarrinho()
        {
            foreach (var item in carrinho.Values)
            {
                var produto = produtosEmMemoria.FirstOrDefault(p => p.Id == item.Id);
                if (produto != null)
                {
                    produto.QuantidadeEmEstoque += item.QuantidadeCliente;
                }
            }
            
            carrinho.Clear();
            AtualizarLabelsCarrinho();
            
            if (isCarrinhoView)
                ExibirCarrinhoComFiltro("");
            else
                ExibirProdutos(); 
        }

        private IEnumerable<LstProduto> FiltrarCarrinho(string termo)
        {
            if (string.IsNullOrWhiteSpace(termo))
                return carrinho.Values;

            return carrinho.Values.Where(p =>
                p.Nome.IndexOf(termo, StringComparison.OrdinalIgnoreCase) >= 0 ||
                p.Id.ToString() == termo
            );
        }
        public static VendaView GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new VendaView { MdiParent = parentContainer };
                ConfigurarInstancia();
            }
            else
            {
                RestaurarInstancia();
            }
            return instance;
        }

        private static void ConfigurarInstancia()
        {
            instance.FormBorderStyle = FormBorderStyle.None;
            instance.Dock = DockStyle.Fill;
        }

        private static void RestaurarInstancia()
        {
            if (instance.WindowState == FormWindowState.Minimized)
                instance.WindowState = FormWindowState.Normal;
            instance.BringToFront();
        }

        private string GetClienteName(int clienteId)
        {
            try
            {
                return clienteRepository.ObterPorvalor(clienteId.ToString()).FirstOrDefault()?.Nome 
                    ?? $"Cliente não encontrado ({clienteId})";
            }
            catch
            {
                return $"Erro ao buscar cliente ({clienteId})";
            }
        }

        private void AtualizarUIProdutos()
        {
            btnPaginasP.Text = isCarrinhoView 
                ? paginaCarrinhoAtual.ToString() 
                : paginaProdutoAtual.ToString();
            
            if (!isCarrinhoView)
            {
                AtualizarBotoesPaginacao();
            }
        }

        private void AtualizarBotoesPaginacao()
        {
            var totalPaginas = (int)Math.Ceiling(produtosAtuais.Count() / (double)ITENS_POR_PAGINA);
            
            btnAvancarP.Enabled = paginaProdutoAtual < totalPaginas;
            btnVoltarP.Enabled = paginaProdutoAtual > 1;

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
            int totalItens = carrinho.Values.Sum(item => item.QuantidadeCliente);
            labelTotalProdutos.Text = totalItens.ToString();
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            decimal total = carrinho.Values.Sum(item => 
                (decimal)(item.preco * item.QuantidadeCliente) 
            );
            labelTotalVenda.Text = $"R$ {total:F2}";
        }

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

        private void GridVendas_Paint(object sender, PaintEventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }

    }
}