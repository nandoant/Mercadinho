using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mercadinho.GRIDs;
using Mercadinho.Model;

namespace Mercadinho.View
{
    public partial class ClienteView : Form, IClienteView
    {
        private int pagina = 1;

        public string BarraDePesquisa 
        { 
            get => txtBoxPesquisa.textBox.Text;
            set => txtBoxPesquisa.textBox.Text = value;
        }

        public int Pagina
        {
            get => pagina;
            set
            {
                pagina = value;
                btnPaginas.Text = value.ToString();
            }
        }

        public event EventHandler Adicionar;
        public event EventHandler Pesquisar;
        public event EventHandler AvancarPagina;
        public event EventHandler VoltarPagina;
        public event EventHandler Salvar;
        public event EventHandler Cancelar;
        public event EventHandler<int> EditarCliente;
        public event EventHandler<int> ExcluirCliente;

        public ClienteView()
        {
            InitializeComponent();
            ConfigurarFormulario();
            AssociarEventos();
        }

        private void ConfigurarFormulario()
        {
            tabControlClientes.TabPages.Remove(tabDetalhesClientes);
            btnPaginas.Enabled = false;
            Pagina = 1;
        }

        private void AssociarEventos()
        {
            btnNovoCliente.Click += (s, e) => Adicionar?.Invoke(this, EventArgs.Empty);
            btnPesquisar.Click += (s, e) => Pesquisar?.Invoke(this, EventArgs.Empty);
            btnSalvar.Click += (s, e) => Salvar?.Invoke(this, EventArgs.Empty);
            btnCancelar.Click += (s, e) => Cancelar?.Invoke(this, EventArgs.Empty);
            btnAvancar.Click += (s, e) => AvancarPagina?.Invoke(this, EventArgs.Empty);
            btnVoltar.Click += (s, e) => VoltarPagina?.Invoke(this, EventArgs.Empty);
            txtBoxPesquisa.textBox.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) Pesquisar?.Invoke(this, EventArgs.Empty); };
        }

        public void DisplayClientes(List<Cliente> clientes)
        {
            GridClientes.Controls.Clear();

            foreach (var cliente in clientes)
            {
                LstCliente lstCliente = new LstCliente(cliente);
                lstCliente.Editar += (s, e) => EditarCliente?.Invoke(this, cliente.Id);
                lstCliente.Excluir += (s, e) => ExcluirCliente?.Invoke(this, cliente.Id);
                GridClientes.Controls.Add((Control)lstCliente);
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
            tabControlClientes.TabPages.Remove(tabListaClientes);
            tabControlClientes.TabPages.Add(tabDetalhesClientes);
        }

        public void MostrarLista()
        {
            tabControlClientes.TabPages.Remove(tabDetalhesClientes);
            tabControlClientes.TabPages.Add(tabListaClientes);
        }

        public void LimparCampos()
        {
            txtBoxID.textBox.Text = "0";
            txtBoxID.Enabled = false;
            txtBoxNome.textBox.Text = "";
            txtBoxIdade.textBox.Text = "";
            txtBoxCpf.textBox.Text = "";
        }

        public void PreencherCampos(Cliente cliente)
        {
            txtBoxID.Enabled = false;
            txtBoxID.textBox.Text = cliente.Id.ToString();
            txtBoxNome.textBox.Text = cliente.Nome;
            txtBoxIdade.textBox.Text = cliente.Idade.ToString();
            txtBoxCpf.textBox.Text = cliente.Cpf;
        }

        public Cliente ObterClienteDoFormulario()
        {
            if (!int.TryParse(txtBoxIdade.textBox.Text.Trim(), out int idade))
            {
                throw new Exception("Idade inválida");
            }

            return new Cliente
            {
                Id = string.IsNullOrEmpty(txtBoxID.textBox.Text) ? 0 : int.Parse(txtBoxID.textBox.Text),
                Nome = txtBoxNome.textBox.Text.Trim(),
                Idade = idade,
                Cpf = txtBoxCpf.textBox.Text.Trim()
            };
        }

        private static ClienteView _instance;
        public static ClienteView GetInstance(Form parentContainer)
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new ClienteView();
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

        private void ClienteView_Load(object sender, EventArgs e)
        {

        }
    }
}