using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercadinho.GRIDs
{
    public partial class LstVenda : UserControl, ILstVenda
    {
        public int Id { get => int.Parse(labelID.Text); set => labelID.Text = "" + value; }
        public string NomedoCliente { get =>  labelNome.Text; set => labelNome.Text = value; }
        public DateTime DataDaCompra { get => DateTime.Parse(labelData.Text); set => labelData.Text = value.ToString("dd/MM/yyyy"); }
        public decimal ValorTotal { get => decimal.Parse(labelTotal.Text.Replace("R$ ", "")); set => labelTotal.Text = "R$ " + value; }

        public LstVenda()
        {
            InitializeComponent();
            btnDelete.Click += (s, e) => Deletar?.Invoke(this, e);
            btnProdutos.Click += (s, e) => VerProdutos?.Invoke(this, e);
        }

        public LstVenda(int id, string nome, DateTime data, decimal total)
        {
            InitializeComponent();
            Id = id;
            NomedoCliente = nome;
            DataDaCompra = data;
            ValorTotal = total;
            btnDelete.Click += (s, e) => Deletar?.Invoke(this, e);
            btnProdutos.Click += (s, e) => VerProdutos?.Invoke(this, e);
        }

        public event EventHandler Deletar;
        public event EventHandler VerProdutos;
    }
}
