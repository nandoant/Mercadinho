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
    public partial class LstProduto : UserControl, ILstProduto
    {
        public event EventHandler Editar;
        public event EventHandler Excluir;

        public LstProduto()
        {
            InitializeComponent();
        }

        public LstProduto(Produto produto)
        {
            InitializeComponent();
            Id = produto.Id;
            Nome = produto.Nome;
            Descricao = produto.Descricao;
            Preco = produto.PrecoUnitario;
            Marca = produto.Marca;
            Modelo = produto.Modelo;

            btnDelete.Click += deletarItem;
            btnDelete.Click += (sender, e) => Excluir?.Invoke(this, e);
            btnEdit.Click += (sender, e) => Editar?.Invoke(this, e);
        }
        public int Id
        {
            get { return int.Parse(labelID.Text); }
            set 
            {
                string id = ""+value;
                labelID.Text = id.Length > 9 ? id.Substring(0, 6) + "..." : id;
                dropDownText.SetToolTip(labelID, id);
            }
        }
        public string Nome 
        { 
            get { return labelNome.Text; }
            set 
            { 
                labelNome.Text = value.Length > 9 ? value.Substring(0, 6) + "..." : value;
                dropDownText.SetToolTip(labelNome, value);
            } 
        }
        public string Descricao
        {
            get { return labelDescricao.Text; }
            set
            {
                labelDescricao.Text = value.Length > 23 ? value.Substring(0, 20) + "..." : value;
                dropDownText.SetToolTip(labelDescricao, value);
            }
        }
        public double Preco
        {
            get 
            {
                string value = labelID.Text = labelPreco.Text.Replace("R$ ", "");
                return Double.Parse(value); 
            }
            set 
            { 
                string preco = "R$ " + value; 
                labelPreco.Text = preco.Length > 9 ? preco.Substring(0, 6) + "..." : preco;
                dropDownText.SetToolTip(labelPreco, preco);
            }
        }

        public string Marca
        {
            get { return labelMarca.Text; }
            set 
            {
                labelMarca.Text = value.Length > 9 ? value.Substring(0, 6) + "..." : value;
                dropDownText.SetToolTip(labelMarca, value);
            }
        }

        public string Modelo
        {
            get { return labelModelo.Text; }
            set 
            {
                labelModelo.Text = value.Length > 9 ? value.Substring(0, 6) + "..." : value;
                dropDownText.SetToolTip(labelModelo, value);
            }
        }

        //Codigo gerado pelo designer
        private void deletarItem(object sender, EventArgs e){ this.Dispose(); }

        private void LstProduto_Load(object sender, EventArgs e){ }

        private void btnDelete_Click(object sender, EventArgs e){ }
    }
}
