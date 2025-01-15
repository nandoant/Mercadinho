namespace Mercadinho.View
{
    partial class ProdutoView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControlProdutos = new System.Windows.Forms.TabControl();
            this.tabListaProdutos = new System.Windows.Forms.TabPage();
            this.btnPaginas = new System.Windows.Forms.Button();
            this.btnVoltar = new ReaLTaiizor.Controls.Button();
            this.btnAvancar = new ReaLTaiizor.Controls.Button();
            this.GridProdutos = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cyberTextBox3 = new ReaLTaiizor.Controls.CyberTextBox();
            this.txtBoxPesquisa = new ReaLTaiizor.Controls.CyberTextBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnNovoProduto = new ReaLTaiizor.Controls.Button();
            this.tabDetalhesProduto = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBoxDescricao = new ReaLTaiizor.Controls.RichTextBoxEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new ReaLTaiizor.Controls.Button();
            this.txtBoxID = new ReaLTaiizor.Controls.CyberTextBox();
            this.txtBoxNome = new ReaLTaiizor.Controls.CyberTextBox();
            this.txtBoxIdade = new ReaLTaiizor.Controls.CyberTextBox();
            this.txtBoxModelo = new ReaLTaiizor.Controls.CyberTextBox();
            this.txtBoxMarca = new ReaLTaiizor.Controls.CyberTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControlProdutos.SuspendLayout();
            this.tabListaProdutos.SuspendLayout();
            this.tabDetalhesProduto.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlProdutos
            // 
            this.tabControlProdutos.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControlProdutos.Controls.Add(this.tabListaProdutos);
            this.tabControlProdutos.Controls.Add(this.tabDetalhesProduto);
            this.tabControlProdutos.Location = new System.Drawing.Point(0, 0);
            this.tabControlProdutos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControlProdutos.Name = "tabControlProdutos";
            this.tabControlProdutos.SelectedIndex = 0;
            this.tabControlProdutos.Size = new System.Drawing.Size(1133, 650);
            this.tabControlProdutos.TabIndex = 0;
            // 
            // tabListaProdutos
            // 
            this.tabListaProdutos.BackColor = System.Drawing.Color.White;
            this.tabListaProdutos.Controls.Add(this.btnPaginas);
            this.tabListaProdutos.Controls.Add(this.btnVoltar);
            this.tabListaProdutos.Controls.Add(this.btnAvancar);
            this.tabListaProdutos.Controls.Add(this.GridProdutos);
            this.tabListaProdutos.Controls.Add(this.label6);
            this.tabListaProdutos.Controls.Add(this.label5);
            this.tabListaProdutos.Controls.Add(this.label4);
            this.tabListaProdutos.Controls.Add(this.label3);
            this.tabListaProdutos.Controls.Add(this.label2);
            this.tabListaProdutos.Controls.Add(this.label1);
            this.tabListaProdutos.Controls.Add(this.cyberTextBox3);
            this.tabListaProdutos.Controls.Add(this.txtBoxPesquisa);
            this.tabListaProdutos.Controls.Add(this.btnPesquisar);
            this.tabListaProdutos.Controls.Add(this.btnNovoProduto);
            this.tabListaProdutos.Location = new System.Drawing.Point(4, 4);
            this.tabListaProdutos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabListaProdutos.Name = "tabListaProdutos";
            this.tabListaProdutos.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabListaProdutos.Size = new System.Drawing.Size(1125, 621);
            this.tabListaProdutos.TabIndex = 0;
            this.tabListaProdutos.Text = "Lista de Produtos";
            this.tabListaProdutos.Click += new System.EventHandler(this.tabListaProdutos_Click);
            // 
            // btnPaginas
            // 
            this.btnPaginas.Location = new System.Drawing.Point(59, 9);
            this.btnPaginas.Margin = new System.Windows.Forms.Padding(4);
            this.btnPaginas.Name = "btnPaginas";
            this.btnPaginas.Size = new System.Drawing.Size(39, 39);
            this.btnPaginas.TabIndex = 32;
            this.btnPaginas.Text = "1";
            this.btnPaginas.UseVisualStyleBackColor = true;
            this.btnPaginas.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.Transparent;
            this.btnVoltar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoltar.EnteredBorderColor = System.Drawing.Color.White;
            this.btnVoltar.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnVoltar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Image = null;
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVoltar.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnVoltar.Location = new System.Drawing.Point(12, 9);
            this.btnVoltar.Margin = new System.Windows.Forms.Padding(4);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnVoltar.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnVoltar.Size = new System.Drawing.Size(37, 38);
            this.btnVoltar.TabIndex = 31;
            this.btnVoltar.Text = "<";
            this.btnVoltar.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnVoltar.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnAvancar
            // 
            this.btnAvancar.BackColor = System.Drawing.Color.Transparent;
            this.btnAvancar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnAvancar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAvancar.EnteredBorderColor = System.Drawing.Color.White;
            this.btnAvancar.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnAvancar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAvancar.Image = null;
            this.btnAvancar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAvancar.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnAvancar.Location = new System.Drawing.Point(105, 9);
            this.btnAvancar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAvancar.Name = "btnAvancar";
            this.btnAvancar.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnAvancar.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnAvancar.Size = new System.Drawing.Size(37, 38);
            this.btnAvancar.TabIndex = 30;
            this.btnAvancar.Text = ">";
            this.btnAvancar.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnAvancar.Click += new System.EventHandler(this.button2_Click);
            // 
            // GridProdutos
            // 
            this.GridProdutos.Location = new System.Drawing.Point(11, 95);
            this.GridProdutos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GridProdutos.Name = "GridProdutos";
            this.GridProdutos.Size = new System.Drawing.Size(1105, 505);
            this.GridProdutos.TabIndex = 29;
            this.GridProdutos.Paint += new System.Windows.Forms.PaintEventHandler(this.GridProdutos_Paint);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(648, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 23);
            this.label6.TabIndex = 19;
            this.label6.Text = "Descrição";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(508, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 23);
            this.label5.TabIndex = 18;
            this.label5.Text = "Preço";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(372, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 28);
            this.label4.TabIndex = 17;
            this.label4.Text = "Modelo";
            this.label4.UseCompatibleTextRendering = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(256, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 23);
            this.label3.TabIndex = 16;
            this.label3.Text = "Marca";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(101, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 23);
            this.label2.TabIndex = 15;
            this.label2.Text = "Nome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 23);
            this.label1.TabIndex = 14;
            this.label1.Text = "ID";
            // 
            // cyberTextBox3
            // 
            this.cyberTextBox3.Alpha = 20;
            this.cyberTextBox3.BackColor = System.Drawing.Color.Transparent;
            this.cyberTextBox3.Background_WidthPen = 1F;
            this.cyberTextBox3.BackgroundPen = true;
            this.cyberTextBox3.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.cyberTextBox3.ColorBackground_Pen = System.Drawing.Color.LightGray;
            this.cyberTextBox3.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.cyberTextBox3.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.cyberTextBox3.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.cyberTextBox3.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.cyberTextBox3.Enabled = false;
            this.cyberTextBox3.Font = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.cyberTextBox3.ForeColor = System.Drawing.Color.Black;
            this.cyberTextBox3.Lighting = false;
            this.cyberTextBox3.LinearGradientPen = false;
            this.cyberTextBox3.Location = new System.Drawing.Point(11, 55);
            this.cyberTextBox3.Margin = new System.Windows.Forms.Padding(4);
            this.cyberTextBox3.Name = "cyberTextBox3";
            this.cyberTextBox3.PenWidth = 15;
            this.cyberTextBox3.RGB = false;
            this.cyberTextBox3.Rounding = true;
            this.cyberTextBox3.RoundingInt = 10;
            this.cyberTextBox3.Size = new System.Drawing.Size(1105, 39);
            this.cyberTextBox3.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.cyberTextBox3.TabIndex = 13;
            this.cyberTextBox3.Tag = "Cyber";
            this.cyberTextBox3.TextButton = "";
            this.cyberTextBox3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.cyberTextBox3.Timer_RGB = 300;
            // 
            // txtBoxPesquisa
            // 
            this.txtBoxPesquisa.Alpha = 20;
            this.txtBoxPesquisa.BackColor = System.Drawing.Color.Transparent;
            this.txtBoxPesquisa.Background_WidthPen = 1F;
            this.txtBoxPesquisa.BackgroundPen = true;
            this.txtBoxPesquisa.ColorBackground = System.Drawing.Color.White;
            this.txtBoxPesquisa.ColorBackground_Pen = System.Drawing.Color.LightGray;
            this.txtBoxPesquisa.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtBoxPesquisa.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtBoxPesquisa.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.txtBoxPesquisa.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.txtBoxPesquisa.Font = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.txtBoxPesquisa.ForeColor = System.Drawing.Color.DarkGray;
            this.txtBoxPesquisa.Lighting = false;
            this.txtBoxPesquisa.LinearGradientPen = false;
            this.txtBoxPesquisa.Location = new System.Drawing.Point(151, 7);
            this.txtBoxPesquisa.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxPesquisa.Name = "txtBoxPesquisa";
            this.txtBoxPesquisa.PenWidth = 15;
            this.txtBoxPesquisa.RGB = false;
            this.txtBoxPesquisa.Rounding = true;
            this.txtBoxPesquisa.RoundingInt = 17;
            this.txtBoxPesquisa.Size = new System.Drawing.Size(677, 39);
            this.txtBoxPesquisa.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.txtBoxPesquisa.TabIndex = 11;
            this.txtBoxPesquisa.Tag = "Cyber";
            this.txtBoxPesquisa.TextButton = "Nome ou ID do produto";
            this.txtBoxPesquisa.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.txtBoxPesquisa.Timer_RGB = 300;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(837, 7);
            this.btnPesquisar.Margin = new System.Windows.Forms.Padding(4);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(113, 41);
            this.btnPesquisar.TabIndex = 10;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            // 
            // btnNovoProduto
            // 
            this.btnNovoProduto.BackColor = System.Drawing.Color.Transparent;
            this.btnNovoProduto.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnNovoProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovoProduto.EnteredBorderColor = System.Drawing.Color.White;
            this.btnNovoProduto.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnNovoProduto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoProduto.Image = null;
            this.btnNovoProduto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovoProduto.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnNovoProduto.Location = new System.Drawing.Point(957, 9);
            this.btnNovoProduto.Margin = new System.Windows.Forms.Padding(4);
            this.btnNovoProduto.Name = "btnNovoProduto";
            this.btnNovoProduto.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnNovoProduto.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnNovoProduto.Size = new System.Drawing.Size(155, 38);
            this.btnNovoProduto.TabIndex = 7;
            this.btnNovoProduto.Text = "+ Novo Produto";
            this.btnNovoProduto.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // tabDetalhesProduto
            // 
            this.tabDetalhesProduto.BackColor = System.Drawing.Color.White;
            this.tabDetalhesProduto.Controls.Add(this.label12);
            this.tabDetalhesProduto.Controls.Add(this.label11);
            this.tabDetalhesProduto.Controls.Add(this.label10);
            this.tabDetalhesProduto.Controls.Add(this.label9);
            this.tabDetalhesProduto.Controls.Add(this.label8);
            this.tabDetalhesProduto.Controls.Add(this.txtBoxDescricao);
            this.tabDetalhesProduto.Controls.Add(this.label7);
            this.tabDetalhesProduto.Controls.Add(this.btnCancelar);
            this.tabDetalhesProduto.Controls.Add(this.btnSalvar);
            this.tabDetalhesProduto.Controls.Add(this.txtBoxID);
            this.tabDetalhesProduto.Controls.Add(this.txtBoxNome);
            this.tabDetalhesProduto.Controls.Add(this.txtBoxIdade);
            this.tabDetalhesProduto.Controls.Add(this.txtBoxModelo);
            this.tabDetalhesProduto.Controls.Add(this.txtBoxMarca);
            this.tabDetalhesProduto.Location = new System.Drawing.Point(4, 4);
            this.tabDetalhesProduto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabDetalhesProduto.Name = "tabDetalhesProduto";
            this.tabDetalhesProduto.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabDetalhesProduto.Size = new System.Drawing.Size(1125, 621);
            this.tabDetalhesProduto.TabIndex = 1;
            this.tabDetalhesProduto.Text = "Detalhes do Produto";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(227, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 23);
            this.label12.TabIndex = 26;
            this.label12.Text = "ID:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(227, 94);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 23);
            this.label11.TabIndex = 25;
            this.label11.Text = "Nome:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(221, 174);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 23);
            this.label10.TabIndex = 24;
            this.label10.Text = "Idade:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(221, 254);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 23);
            this.label9.TabIndex = 23;
            this.label9.Text = "Marca:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(227, 416);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 23);
            this.label8.TabIndex = 22;
            this.label8.Text = "Descrição:";
            // 
            // txtBoxDescricao
            // 
            this.txtBoxDescricao.AutoWordSelection = false;
            this.txtBoxDescricao.BackColor = System.Drawing.Color.Transparent;
            this.txtBoxDescricao.BaseColor = System.Drawing.Color.Transparent;
            this.txtBoxDescricao.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtBoxDescricao.EdgeColor = System.Drawing.Color.White;
            this.txtBoxDescricao.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxDescricao.ForeColor = System.Drawing.Color.Black;
            this.txtBoxDescricao.Location = new System.Drawing.Point(227, 442);
            this.txtBoxDescricao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBoxDescricao.Name = "txtBoxDescricao";
            this.txtBoxDescricao.ReadOnly = false;
            this.txtBoxDescricao.Size = new System.Drawing.Size(677, 100);
            this.txtBoxDescricao.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.txtBoxDescricao.TabIndex = 21;
            this.txtBoxDescricao.Text = "Descrição";
            this.txtBoxDescricao.TextBackColor = System.Drawing.Color.White;
            this.txtBoxDescricao.TextBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxDescricao.TextFont = new System.Drawing.Font("Tahoma", 10F);
            this.txtBoxDescricao.WordWrap = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(221, 334);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 23);
            this.label7.TabIndex = 20;
            this.label7.Text = "Modelo:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(589, 561);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(155, 42);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.Transparent;
            this.btnSalvar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnSalvar.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnSalvar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Image = null;
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnSalvar.Location = new System.Drawing.Point(749, 562);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnSalvar.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnSalvar.Size = new System.Drawing.Size(155, 38);
            this.btnSalvar.TabIndex = 18;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtBoxID
            // 
            this.txtBoxID.Alpha = 20;
            this.txtBoxID.BackColor = System.Drawing.Color.Transparent;
            this.txtBoxID.Background_WidthPen = 1F;
            this.txtBoxID.BackgroundPen = true;
            this.txtBoxID.ColorBackground = System.Drawing.Color.White;
            this.txtBoxID.ColorBackground_Pen = System.Drawing.Color.LightGray;
            this.txtBoxID.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtBoxID.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtBoxID.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.txtBoxID.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.txtBoxID.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtBoxID.ForeColor = System.Drawing.Color.Black;
            this.txtBoxID.Lighting = false;
            this.txtBoxID.LinearGradientPen = false;
            this.txtBoxID.Location = new System.Drawing.Point(227, 41);
            this.txtBoxID.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxID.Name = "txtBoxID";
            this.txtBoxID.PenWidth = 15;
            this.txtBoxID.RGB = false;
            this.txtBoxID.Rounding = true;
            this.txtBoxID.RoundingInt = 17;
            this.txtBoxID.Size = new System.Drawing.Size(677, 39);
            this.txtBoxID.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.txtBoxID.TabIndex = 17;
            this.txtBoxID.Tag = "Cyber";
            this.txtBoxID.TextButton = "ID";
            this.txtBoxID.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.txtBoxID.Timer_RGB = 300;
            // 
            // txtBoxNome
            // 
            this.txtBoxNome.Alpha = 20;
            this.txtBoxNome.BackColor = System.Drawing.Color.Transparent;
            this.txtBoxNome.Background_WidthPen = 1F;
            this.txtBoxNome.BackgroundPen = true;
            this.txtBoxNome.ColorBackground = System.Drawing.Color.White;
            this.txtBoxNome.ColorBackground_Pen = System.Drawing.Color.LightGray;
            this.txtBoxNome.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtBoxNome.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtBoxNome.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.txtBoxNome.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.txtBoxNome.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtBoxNome.ForeColor = System.Drawing.Color.Black;
            this.txtBoxNome.Lighting = false;
            this.txtBoxNome.LinearGradientPen = false;
            this.txtBoxNome.Location = new System.Drawing.Point(227, 121);
            this.txtBoxNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxNome.Name = "txtBoxNome";
            this.txtBoxNome.PenWidth = 15;
            this.txtBoxNome.RGB = false;
            this.txtBoxNome.Rounding = true;
            this.txtBoxNome.RoundingInt = 17;
            this.txtBoxNome.Size = new System.Drawing.Size(677, 39);
            this.txtBoxNome.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.txtBoxNome.TabIndex = 16;
            this.txtBoxNome.Tag = "Cyber";
            this.txtBoxNome.TextButton = "Nome";
            this.txtBoxNome.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.txtBoxNome.Timer_RGB = 300;
            // 
            // txtBoxIdade
            // 
            this.txtBoxIdade.Alpha = 20;
            this.txtBoxIdade.BackColor = System.Drawing.Color.Transparent;
            this.txtBoxIdade.Background_WidthPen = 1F;
            this.txtBoxIdade.BackgroundPen = true;
            this.txtBoxIdade.ColorBackground = System.Drawing.Color.White;
            this.txtBoxIdade.ColorBackground_Pen = System.Drawing.Color.LightGray;
            this.txtBoxIdade.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtBoxIdade.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtBoxIdade.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.txtBoxIdade.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.txtBoxIdade.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtBoxIdade.ForeColor = System.Drawing.Color.Black;
            this.txtBoxIdade.Lighting = false;
            this.txtBoxIdade.LinearGradientPen = false;
            this.txtBoxIdade.Location = new System.Drawing.Point(227, 201);
            this.txtBoxIdade.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxIdade.Name = "txtBoxIdade";
            this.txtBoxIdade.PenWidth = 15;
            this.txtBoxIdade.RGB = false;
            this.txtBoxIdade.Rounding = true;
            this.txtBoxIdade.RoundingInt = 17;
            this.txtBoxIdade.Size = new System.Drawing.Size(677, 39);
            this.txtBoxIdade.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.txtBoxIdade.TabIndex = 15;
            this.txtBoxIdade.Tag = "Cyber";
            this.txtBoxIdade.TextButton = "Preço";
            this.txtBoxIdade.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.txtBoxIdade.Timer_RGB = 300;
            // 
            // txtBoxModelo
            // 
            this.txtBoxModelo.Alpha = 20;
            this.txtBoxModelo.BackColor = System.Drawing.Color.Transparent;
            this.txtBoxModelo.Background_WidthPen = 1F;
            this.txtBoxModelo.BackgroundPen = true;
            this.txtBoxModelo.ColorBackground = System.Drawing.Color.White;
            this.txtBoxModelo.ColorBackground_Pen = System.Drawing.Color.LightGray;
            this.txtBoxModelo.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtBoxModelo.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtBoxModelo.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.txtBoxModelo.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.txtBoxModelo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtBoxModelo.ForeColor = System.Drawing.Color.Black;
            this.txtBoxModelo.Lighting = false;
            this.txtBoxModelo.LinearGradientPen = false;
            this.txtBoxModelo.Location = new System.Drawing.Point(227, 361);
            this.txtBoxModelo.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxModelo.Name = "txtBoxModelo";
            this.txtBoxModelo.PenWidth = 15;
            this.txtBoxModelo.RGB = false;
            this.txtBoxModelo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBoxModelo.Rounding = true;
            this.txtBoxModelo.RoundingInt = 17;
            this.txtBoxModelo.Size = new System.Drawing.Size(677, 39);
            this.txtBoxModelo.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.txtBoxModelo.TabIndex = 13;
            this.txtBoxModelo.Tag = "Cyber";
            this.txtBoxModelo.TextButton = "Modelo";
            this.txtBoxModelo.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.txtBoxModelo.Timer_RGB = 300;
            // 
            // txtBoxMarca
            // 
            this.txtBoxMarca.Alpha = 20;
            this.txtBoxMarca.BackColor = System.Drawing.Color.Transparent;
            this.txtBoxMarca.Background_WidthPen = 1F;
            this.txtBoxMarca.BackgroundPen = true;
            this.txtBoxMarca.ColorBackground = System.Drawing.Color.White;
            this.txtBoxMarca.ColorBackground_Pen = System.Drawing.Color.LightGray;
            this.txtBoxMarca.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtBoxMarca.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtBoxMarca.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.txtBoxMarca.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.txtBoxMarca.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtBoxMarca.ForeColor = System.Drawing.Color.Black;
            this.txtBoxMarca.Lighting = false;
            this.txtBoxMarca.LinearGradientPen = false;
            this.txtBoxMarca.Location = new System.Drawing.Point(227, 281);
            this.txtBoxMarca.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxMarca.Name = "txtBoxMarca";
            this.txtBoxMarca.PenWidth = 15;
            this.txtBoxMarca.RGB = false;
            this.txtBoxMarca.Rounding = true;
            this.txtBoxMarca.RoundingInt = 17;
            this.txtBoxMarca.Size = new System.Drawing.Size(677, 39);
            this.txtBoxMarca.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.txtBoxMarca.TabIndex = 12;
            this.txtBoxMarca.Tag = "Cyber";
            this.txtBoxMarca.TextButton = "Marca";
            this.txtBoxMarca.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.txtBoxMarca.Timer_RGB = 300;
            // 
            // ProdutoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1133, 625);
            this.Controls.Add(this.tabControlProdutos);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ProdutoView";
            this.Text = "ProdutoView";
            this.Load += new System.EventHandler(this.ProdutoView_Load);
            this.tabControlProdutos.ResumeLayout(false);
            this.tabListaProdutos.ResumeLayout(false);
            this.tabListaProdutos.PerformLayout();
            this.tabDetalhesProduto.ResumeLayout(false);
            this.tabDetalhesProduto.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlProdutos;
        private System.Windows.Forms.TabPage tabListaProdutos;
        private System.Windows.Forms.TabPage tabDetalhesProduto;
        private ReaLTaiizor.Controls.Button btnNovoProduto;
        private System.Windows.Forms.Button btnPesquisar;
        private ReaLTaiizor.Controls.CyberTextBox txtBoxPesquisa;
        private ReaLTaiizor.Controls.CyberTextBox cyberTextBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel GridProdutos;
        private ReaLTaiizor.Controls.Button btnAvancar;
        private System.Windows.Forms.Button btnPaginas;
        private ReaLTaiizor.Controls.Button btnVoltar;
        private System.Windows.Forms.Button btnCancelar;
        private ReaLTaiizor.Controls.Button btnSalvar;
        private ReaLTaiizor.Controls.CyberTextBox txtBoxID;
        private ReaLTaiizor.Controls.CyberTextBox txtBoxNome;
        private ReaLTaiizor.Controls.CyberTextBox txtBoxIdade;
        private ReaLTaiizor.Controls.CyberTextBox txtBoxMarca;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label8;
        private ReaLTaiizor.Controls.RichTextBoxEdit txtBoxDescricao;
        private System.Windows.Forms.Label label7;
        private ReaLTaiizor.Controls.CyberTextBox txtBoxModelo;
    }
}