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
    public partial class MainView : Form, IMainView
    {
        public event EventHandler MostrarProdutos;
        public event EventHandler MostrarClientes;
        public event EventHandler MostrarVendas;

        public MainView()
        {
            InitializeComponent();
            btnClientes.Click += delegate 
            {
                //selecao.Location = new Point(4, 200);
                FecharViewsAbertas();
                MostrarClientes(this, EventArgs.Empty); 
            };
            btnProdutos.Click += delegate 
            {
                //selecao.Location = new Point(4, 246);
                FecharViewsAbertas();
                MostrarProdutos(this, EventArgs.Empty); 
            };
            btnVendas.Click += delegate 
            { 
                FecharViewsAbertas();
                MostrarVendas(this, EventArgs.Empty); 
            };
        }

        public void FecharViewsAbertas()
        {
            foreach (Form form in MdiChildren)
            {
                form.Dispose();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cyberTextBox1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
