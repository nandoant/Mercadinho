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

namespace Mercadinho.View
{
    public partial class VendaProdutoView : Form
    {
        private DataGridView gridProdutos;
        public VendaProdutoView()
        {
            InitializeComponent();
            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            gridProdutos = new DataGridView();
            gridProdutos.Dock = DockStyle.Fill;
            gridProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridProdutos.AllowUserToAddRows = false;
            gridProdutos.ReadOnly = true;

            gridProdutos.Columns.Add("Nome", "Nome");
            gridProdutos.Columns.Add("Quantidade", "Quantidade");
            gridProdutos.Columns.Add("PrecoUnitario", "Preço Unitário");
            gridProdutos.Columns.Add("Subtotal", "Subtotal");

            Controls.Add(gridProdutos);
        }

        public void ExibirProdutos(List<VendaProduto> produtos, List<Produto> detalhes)
        {
            gridProdutos.Rows.Clear();
            foreach (var vendaProduto in produtos)
            {
                var produto = detalhes.FirstOrDefault(p => p.Id == vendaProduto.ProdutoId);
                if (produto != null)
                {
                    gridProdutos.Rows.Add(
                        produto.Nome,
                        vendaProduto.Quantidade,
                        $"R$ {vendaProduto.PrecoUnitario:F2}",
                        $"R$ {vendaProduto.CalcularSubtotal():F2}"
                    );
                }
            }
        }
    }
}
