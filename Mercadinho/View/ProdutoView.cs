using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mercadinho.GRIDs;
using Mercadinho.Model;
using Mercadinho.Repository;
using Mercadinho.View;

namespace Mercadinho.View
{
    public partial class ProdutoView : Form, IProdutoView
    {
        private int _pagina = 1;

        public string BarraDePesquisa 
        { 
            get => txtBoxPesquisa.textBox.Text;
            set => txtBoxPesquisa.textBox.Text = value;
        }

        public int Pagina
        {
            get => _pagina;
            set
            {
                _pagina = value;
                btnPaginas.Text = value.ToString();
            }
        }

        public event EventHandler Adicionar;
        public event EventHandler Pesquisar;
        public event EventHandler AvancarPagina;
        public event EventHandler VoltarPagina;
        public event EventHandler Salvar;
        public event EventHandler Cancelar;
        public event EventHandler<int> EditarProduto;
        public event EventHandler<int> ExcluirProduto;
        public event EventHandler FecharJanela;

        public ProdutoView()
        {
            InitializeComponent();
            ConfigurarFormulario();
            AssociarEventos();
            this.FormClosing += (s, e) => FecharJanela?.Invoke(this, EventArgs.Empty);
        }

        private void ConfigurarFormulario()
        {
            tabControlProdutos.TabPages.Remove(tabDetalhesProduto);
            btnPaginas.Enabled = false;
            Pagina = 1;
        }

        private void AssociarEventos()
        {
            btnNovoProduto.Click += (s, e) => Adicionar?.Invoke(this, EventArgs.Empty);
            btnPesquisar.Click += (s, e) => { Pesquisar?.Invoke(this, EventArgs.Empty); 
            };
            btnSalvar.Click += (s, e) => Salvar?.Invoke(this, EventArgs.Empty);
            btnCancelar.Click += (s, e) => Cancelar?.Invoke(this, EventArgs.Empty);
            btnAvancar.Click += (s, e) => AvancarPagina?.Invoke(this, EventArgs.Empty);
            btnVoltar.Click += (s, e) => VoltarPagina?.Invoke(this, EventArgs.Empty);
            txtBoxPesquisa.textBox.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) Pesquisar?.Invoke(this, EventArgs.Empty); };
            FecharJanela += (s, e) => this.Dispose();
        }

        public void DisplayProdutos(List<Produto> produtos)
        {
            GridProdutos.Controls.Clear();

            foreach (var produto in produtos)
            {
                ILstProduto lstProduto = new LstProduto(produto);
                lstProduto.Editar += (s, e) => EditarProduto?.Invoke(this, produto.Id);
                lstProduto.Excluir += (s, e) => ExcluirProduto?.Invoke(this, produto.Id);
                GridProdutos.Controls.Add((Control)lstProduto);
            }
        }

        public void AtualizarBotoesPaginacao(bool temProximaPagina, bool temPaginaAnterior)
        {
            if (!temProximaPagina)
            {
                btnAvancar.InactiveColor = Color.LightGray;
                btnAvancar.BorderColor = Color.LightGray;
            }
            else
            {
                btnAvancar.InactiveColor = Color.FromArgb(32, 34, 37);
                btnAvancar.BorderColor = Color.FromArgb(32, 34, 37);
            }

            if (!temPaginaAnterior)
            {
                btnVoltar.InactiveColor = Color.LightGray;
                btnVoltar.BorderColor = Color.LightGray;
            }
            else
            {
                btnVoltar.InactiveColor = Color.FromArgb(32, 34, 37);
                btnVoltar.BorderColor = Color.FromArgb(32, 34, 37);
            }
            btnAvancar.Enabled = temProximaPagina;
            btnVoltar.Enabled = temPaginaAnterior;
        }

        public void MostrarDetalhes()
        {
            tabControlProdutos.TabPages.Remove(tabListaProdutos);
            tabControlProdutos.TabPages.Add(tabDetalhesProduto);
        }

        public void MostrarLista()
        {
            tabControlProdutos.TabPages.Remove(tabDetalhesProduto);
            tabControlProdutos.TabPages.Add(tabListaProdutos);
        }

        public void LimparCampos()
        {
            txtBoxID.textBox.Text = "0";
            txtBoxID.Enabled = false;
            txtBoxNome.textBox.Text = "";
            txtBoxPreco.textBox.Text = "";
            txtBoxDescricao.Text = "";
            txtBoxMarca.textBox.Text = "";
            txtBoxModelo.textBox.Text = "";
            txtBoxQuantidade.textBox.Text = "";
        }

        public void PreencherCampos(Produto produto)
        {
            txtBoxID.Enabled = false;
            txtBoxID.textBox.Text = produto.Id.ToString();
            txtBoxNome.textBox.Text = produto.Nome;
            txtBoxPreco.textBox.Text = produto.PrecoUnitario.ToString("0.00").Replace(".", ",");
            txtBoxDescricao.Text = produto.Descricao;
            txtBoxMarca.textBox.Text = produto.Marca;
            txtBoxModelo.textBox.Text = produto.Modelo;
            txtBoxQuantidade.textBox.Text = produto.QuantidadeEmEstoque.ToString();
        }

        public Produto ObterProdutoDoFormulario()
        {
            double preco = ConverterPrecoEmDouble(txtBoxPreco.textBox.Text.Trim());
            int quantidade = ConverterQuantidadeEmInt(txtBoxQuantidade.textBox.Text.Trim());
            return new Produto
            {
                Id = string.IsNullOrEmpty(txtBoxID.textBox.Text) ? 0 : int.Parse(txtBoxID.textBox.Text),
                Nome = txtBoxNome.textBox.Text,
                PrecoUnitario = preco,
                Descricao = txtBoxDescricao.Text,
                Marca = txtBoxMarca.textBox.Text,
                Modelo = txtBoxModelo.textBox.Text,
                QuantidadeEmEstoque = quantidade
            };
        }

        private double ConverterPrecoEmDouble(string preco)
        {
            // Normaliza separadores decimais
            preco = preco.Replace(".", ",");

            // Verifica formato inválido com múltiplas vírgulas
            if (preco.Count(c => c == ',') > 1)
            {
                throw new Exception("Use apenas um separador decimal");
            }

            // Separa partes inteira e decimal
            string[] partes = preco.Split(',');
            string parteInteira = partes[0];
            string parteDecimal = partes.Length > 1 ? partes[1] : "00";

            // Completa ou limita casas decimais
            if (parteDecimal.Length > 2)
            {
                throw new Exception("Máximo de duas casas decimais");
            }
            else if (parteDecimal.Length < 2)
            {
                parteDecimal = parteDecimal.PadRight(2, '0');
            }

            // Reconstrói o valor formatado
            string valorFormatado = $"{parteInteira},{parteDecimal}";

            if (!double.TryParse(valorFormatado, out double resultado))
            {
                throw new Exception("Valor numérico inválido");
            }

            if (resultado <= 0)
            {
                throw new Exception("O preço deve ser maior que zero");
            }

            return resultado;
        }

        private static ProdutoView _instance;
        public static ProdutoView GetInstance(Form parentContainer)
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new ProdutoView();
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

        private int ConverterQuantidadeEmInt(string quantidade)
        {
            if (!int.TryParse(quantidade, out int qtd))
            {
                throw new Exception("Quantidade deve ser um número inteiro");
            }
            if (qtd < 0)
            {
                throw new Exception("Quantidade não pode ser negativa");
            }
            return qtd;
        }

        // Codigo gerado pelo Designer
        private void ProdutoView_Load(object sender, EventArgs e) { }
        private void tabListaProdutos_Click(object sender, EventArgs e) { }

        private void GridProdutos_Paint(object sender, PaintEventArgs e) { }

        private void button2_Click(object sender, EventArgs e) { }

        private void button5_Click(object sender, EventArgs e) { }

        private void button4_Click(object sender, EventArgs e) { }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void cyberTextBox1_Load(object sender, EventArgs e)
        {

        }
    }
}
