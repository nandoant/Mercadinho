using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mercadinho.Model;

namespace Mercadinho.GRIDs
{
    public partial class LstProduto : UserControl, ILstProduto
    {
        private Produto produto;
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
            QuantidadeDisponivel = produto.QuantidadeEmEstoque;

            btnDelete.Click += deletarItem;
            btnDelete.Click += (sender, e) => Excluir?.Invoke(this, e);
            btnEdit.Click += (sender, e) => Editar?.Invoke(this, e);
            txtBoxQtdCleinte.Dispose();
        }

    public LstProduto(Produto produto, bool isVenda)
    {
        InitializeComponent();
        
        this.produto = produto;
        btnEdit.Dispose();
        Id = produto.Id;
        Nome = produto.Nome;
        Descricao = produto.Descricao;
        Preco = produto.PrecoUnitario;
        Marca = produto.Marca;
        Modelo = produto.Modelo;
        if(isVenda)
        {
            QuantidadeDisponivel = produto.QuantidadeEmEstoque;
            txtBoxQtdCleinte.Text = "0";

            
            btnDelete.Image = Properties.Resources.icons8_arrow_24;
        }
        else 
        {
            txtBoxQtdCleinte.ReadOnly = true;
            labelQtdDispo.Dispose();
        }
        btnDelete.Click += deletarItem;
        btnDelete.Click += (sender, e) => Excluir?.Invoke(this, e);
    }

    public string nome => produto.Nome;
    public double preco => produto.PrecoUnitario;

    public int quantidadeDisponivel => produto.QuantidadeEmEstoque;
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
                labelDescricao.Text = value.Length > 20 ? value.Substring(0, 17) + "..." : value;
                dropDownText.SetToolTip(labelDescricao, value);
            }
        }
        public double Preco
        {
            get
            {
                try
                {
                    if (string.IsNullOrEmpty(labelPreco.Text))
                        return 0;

                    string value = labelPreco.Text
                        .Replace("R$", "")
                        .Trim();

                    return Convert.ToDouble(value);
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                labelPreco.Text = $"R$ {value:F2}";
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

        public int QuantidadeCliente
        {
            get { return int.Parse(txtBoxQtdCleinte.Text); }
            set 
            {
                txtBoxQtdCleinte.Text = value.ToString();
                dropDownText.SetToolTip(txtBoxQtdCleinte, value.ToString());
            }
        }

        public int QuantidadeDisponivel
        {
            get {
                return int.Parse(labelQtdDispo.Text.Trim()); }
            set 
            { 
                labelQtdDispo.Text = value.ToString();
                dropDownText.SetToolTip(labelQtdDispo, value.ToString());
            }
        }

        //Codigo gerado pelo designer
        private void deletarItem(object sender, EventArgs e){ }

        private void LstProduto_Load(object sender, EventArgs e){ }

        private void btnDelete_Click(object sender, EventArgs e){ }
    }
}
