using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercadinho.View
{
    public partial class VendaView : Form
    {
        public VendaView()
        {
            InitializeComponent();
            button5.Enabled = false;
            labelCarrinho.Click += delegate
            {
                button5.Location = new Point(542, 97);
                labelCarrinho.Enabled = false;
                labelProdutos.Enabled = true;
                labelCarrinho.BackColor = Color.White;
                labelProdutos.BackColor = Color.FromArgb(190, 192, 189);

            };

            labelProdutos.Click += delegate
            {
                button5.Location = new Point(451, 97);
                labelProdutos.Enabled = false;
                labelCarrinho.Enabled = true;
                labelProdutos.BackColor = Color.White;
                labelCarrinho.BackColor = Color.FromArgb(190, 192, 189);
                labelCarrinho.ForeColor = Color.Black;
                labelProdutos.ForeColor = Color.Black;
            };
        }

    }
}
