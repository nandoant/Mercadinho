using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mercadinho.Model;

namespace Mercadinho.GRIDs
{
    public partial class LstCliente : UserControl, ILstCliente
    {

        public event EventHandler Editar;
        public event EventHandler Excluir;
        public int Id
        {
            get { return int.Parse(labelID.Text); }
            set { labelID.Text = ""+value; }

        } 
        public String Nome
        {
            get { return labelNome.Text; }
            set { labelNome.Text = value; }
        }

        public int Idade
        {
            get { return int.Parse(labelIdade.Text); }
            set { labelIdade.Text = "" + value; }
        }

        public string Cpf
        {
            get { return labelCPF.Text; }
            set { labelCPF.Text = value; }
        }
        public LstCliente()
        {
            InitializeComponent();
            btnDelete.Click += delegate
            {
                this.Dispose();
                Excluir?.Invoke(this, EventArgs.Empty);
            };
            btnEdit.Click += (sender, e) => Editar?.Invoke(this, e);
        }

        public LstCliente(Cliente cliente)
        {
            InitializeComponent();
            Id = cliente.Id;
            Nome = cliente.Nome;
            Idade = cliente.Idade;
            Cpf = cliente.Cpf;
            btnDelete.Click += delegate
            {
                Excluir?.Invoke(this, EventArgs.Empty);
            };
            btnEdit.Click += (sender, e) => Editar?.Invoke(this, e);
        }

        public LstCliente(Cliente cliente, Boolean isVenda)
        {
            InitializeComponent();
            Id = cliente.Id;
            Nome = cliente.Nome;
            Idade = cliente.Idade;
            Cpf = cliente.Cpf;
            btnDelete.Image = Properties.Resources.icons8_arrow_24;
            btnDelete.Click += delegate
            {
                Excluir?.Invoke(this, EventArgs.Empty);
            };
            btnEdit.Dispose();
        }
    }
}
