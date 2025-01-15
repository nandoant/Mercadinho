namespace Mercadinho.View
{
    partial class ClienteView
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
            this.GridClientes = new System.Windows.Forms.FlowLayoutPanel();
            this.tabListaClientes = new System.Windows.Forms.TabPage();
            this.btnPaginas = new System.Windows.Forms.Button();
            this.btnVoltar = new ReaLTaiizor.Controls.Button();
            this.btnAvancar = new ReaLTaiizor.Controls.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cyberTextBox3 = new ReaLTaiizor.Controls.CyberTextBox();
            this.txtBoxPesquisa = new ReaLTaiizor.Controls.CyberTextBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnNovoCliente = new ReaLTaiizor.Controls.Button();
            this.tabControlClientes = new System.Windows.Forms.TabControl();
            this.tabDetalhesClientes = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new ReaLTaiizor.Controls.Button();
            this.txtBoxID = new ReaLTaiizor.Controls.CyberTextBox();
            this.txtBoxNome = new ReaLTaiizor.Controls.CyberTextBox();
            this.txtBoxIdade = new ReaLTaiizor.Controls.CyberTextBox();
            this.txtBoxCpf = new ReaLTaiizor.Controls.CyberTextBox();
            this.tabListaClientes.SuspendLayout();
            this.tabControlClientes.SuspendLayout();
            this.tabDetalhesClientes.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridClientes
            // 
            this.GridClientes.Location = new System.Drawing.Point(8, 77);
            this.GridClientes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GridClientes.Name = "GridClientes";
            this.GridClientes.Size = new System.Drawing.Size(829, 410);
            this.GridClientes.TabIndex = 29;
            // 
            // tabListaClientes
            // 
            this.tabListaClientes.BackColor = System.Drawing.Color.White;
            this.tabListaClientes.Controls.Add(this.btnPaginas);
            this.tabListaClientes.Controls.Add(this.btnVoltar);
            this.tabListaClientes.Controls.Add(this.btnAvancar);
            this.tabListaClientes.Controls.Add(this.GridClientes);
            this.tabListaClientes.Controls.Add(this.label4);
            this.tabListaClientes.Controls.Add(this.label3);
            this.tabListaClientes.Controls.Add(this.label2);
            this.tabListaClientes.Controls.Add(this.label1);
            this.tabListaClientes.Controls.Add(this.cyberTextBox3);
            this.tabListaClientes.Controls.Add(this.txtBoxPesquisa);
            this.tabListaClientes.Controls.Add(this.btnPesquisar);
            this.tabListaClientes.Controls.Add(this.btnNovoCliente);
            this.tabListaClientes.Location = new System.Drawing.Point(4, 4);
            this.tabListaClientes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabListaClientes.Name = "tabListaClientes";
            this.tabListaClientes.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabListaClientes.Size = new System.Drawing.Size(842, 502);
            this.tabListaClientes.TabIndex = 0;
            this.tabListaClientes.Text = "Lista de Clientes";
            // 
            // btnPaginas
            // 
            this.btnPaginas.Location = new System.Drawing.Point(44, 7);
            this.btnPaginas.Name = "btnPaginas";
            this.btnPaginas.Size = new System.Drawing.Size(29, 32);
            this.btnPaginas.TabIndex = 32;
            this.btnPaginas.Text = "1";
            this.btnPaginas.UseVisualStyleBackColor = true;
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
            this.btnVoltar.Location = new System.Drawing.Point(9, 7);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnVoltar.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnVoltar.Size = new System.Drawing.Size(28, 31);
            this.btnVoltar.TabIndex = 31;
            this.btnVoltar.Text = "<";
            this.btnVoltar.TextAlignment = System.Drawing.StringAlignment.Center;
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
            this.btnAvancar.Location = new System.Drawing.Point(79, 7);
            this.btnAvancar.Name = "btnAvancar";
            this.btnAvancar.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnAvancar.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnAvancar.Size = new System.Drawing.Size(28, 31);
            this.btnAvancar.TabIndex = 30;
            this.btnAvancar.Text = ">";
            this.btnAvancar.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(622, 50);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 23);
            this.label4.TabIndex = 17;
            this.label4.Text = "Cpf";
            this.label4.UseCompatibleTextRendering = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(548, 51);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 19);
            this.label3.TabIndex = 16;
            this.label3.Text = "Idade";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(110, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "Nome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 19);
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
            this.cyberTextBox3.Font = new System.Drawing.Font("Segoe UI Symbol", 8F);
            this.cyberTextBox3.ForeColor = System.Drawing.Color.Black;
            this.cyberTextBox3.Lighting = false;
            this.cyberTextBox3.LinearGradientPen = false;
            this.cyberTextBox3.Location = new System.Drawing.Point(8, 45);
            this.cyberTextBox3.Name = "cyberTextBox3";
            this.cyberTextBox3.PenWidth = 15;
            this.cyberTextBox3.RGB = false;
            this.cyberTextBox3.Rounding = true;
            this.cyberTextBox3.RoundingInt = 10;
            this.cyberTextBox3.Size = new System.Drawing.Size(829, 32);
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
            this.txtBoxPesquisa.Font = new System.Drawing.Font("Segoe UI Symbol", 8F);
            this.txtBoxPesquisa.ForeColor = System.Drawing.Color.DarkGray;
            this.txtBoxPesquisa.Lighting = false;
            this.txtBoxPesquisa.LinearGradientPen = false;
            this.txtBoxPesquisa.Location = new System.Drawing.Point(113, 6);
            this.txtBoxPesquisa.Name = "txtBoxPesquisa";
            this.txtBoxPesquisa.PenWidth = 15;
            this.txtBoxPesquisa.RGB = false;
            this.txtBoxPesquisa.Rounding = true;
            this.txtBoxPesquisa.RoundingInt = 17;
            this.txtBoxPesquisa.Size = new System.Drawing.Size(508, 32);
            this.txtBoxPesquisa.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.txtBoxPesquisa.TabIndex = 11;
            this.txtBoxPesquisa.Tag = "Cyber";
            this.txtBoxPesquisa.TextButton = "Nome ou ID do Cliente";
            this.txtBoxPesquisa.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.txtBoxPesquisa.Timer_RGB = 300;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(628, 6);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(85, 33);
            this.btnPesquisar.TabIndex = 10;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            // 
            // btnNovoCliente
            // 
            this.btnNovoCliente.BackColor = System.Drawing.Color.Transparent;
            this.btnNovoCliente.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnNovoCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovoCliente.EnteredBorderColor = System.Drawing.Color.White;
            this.btnNovoCliente.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnNovoCliente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoCliente.Image = null;
            this.btnNovoCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovoCliente.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnNovoCliente.Location = new System.Drawing.Point(718, 7);
            this.btnNovoCliente.Name = "btnNovoCliente";
            this.btnNovoCliente.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnNovoCliente.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnNovoCliente.Size = new System.Drawing.Size(116, 31);
            this.btnNovoCliente.TabIndex = 7;
            this.btnNovoCliente.Text = "+ Novo Cliente";
            this.btnNovoCliente.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // tabControlClientes
            // 
            this.tabControlClientes.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControlClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlClientes.Controls.Add(this.tabListaClientes);
            this.tabControlClientes.Controls.Add(this.tabDetalhesClientes);
            this.tabControlClientes.Location = new System.Drawing.Point(0, 0);
            this.tabControlClientes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControlClientes.Name = "tabControlClientes";
            this.tabControlClientes.SelectedIndex = 0;
            this.tabControlClientes.Size = new System.Drawing.Size(850, 528);
            this.tabControlClientes.TabIndex = 1;
            // 
            // tabDetalhesClientes
            // 
            this.tabDetalhesClientes.BackColor = System.Drawing.Color.White;
            this.tabDetalhesClientes.Controls.Add(this.label12);
            this.tabDetalhesClientes.Controls.Add(this.label11);
            this.tabDetalhesClientes.Controls.Add(this.label10);
            this.tabDetalhesClientes.Controls.Add(this.label9);
            this.tabDetalhesClientes.Controls.Add(this.btnCancelar);
            this.tabDetalhesClientes.Controls.Add(this.btnSalvar);
            this.tabDetalhesClientes.Controls.Add(this.txtBoxID);
            this.tabDetalhesClientes.Controls.Add(this.txtBoxNome);
            this.tabDetalhesClientes.Controls.Add(this.txtBoxIdade);
            this.tabDetalhesClientes.Controls.Add(this.txtBoxCpf);
            this.tabDetalhesClientes.Location = new System.Drawing.Point(4, 4);
            this.tabDetalhesClientes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabDetalhesClientes.Name = "tabDetalhesClientes";
            this.tabDetalhesClientes.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabDetalhesClientes.Size = new System.Drawing.Size(842, 502);
            this.tabDetalhesClientes.TabIndex = 1;
            this.tabDetalhesClientes.Text = "Detalhes do Produto";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(170, 101);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 19);
            this.label12.TabIndex = 36;
            this.label12.Text = "ID:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(170, 166);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 19);
            this.label11.TabIndex = 35;
            this.label11.Text = "Nome:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(166, 231);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 19);
            this.label10.TabIndex = 34;
            this.label10.Text = "Idade:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(166, 296);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 19);
            this.label9.TabIndex = 33;
            this.label9.Text = "CPF:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(442, 369);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(116, 34);
            this.btnCancelar.TabIndex = 32;
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
            this.btnSalvar.Location = new System.Drawing.Point(562, 370);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnSalvar.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnSalvar.Size = new System.Drawing.Size(116, 31);
            this.btnSalvar.TabIndex = 31;
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
            this.txtBoxID.Location = new System.Drawing.Point(170, 123);
            this.txtBoxID.Name = "txtBoxID";
            this.txtBoxID.PenWidth = 15;
            this.txtBoxID.RGB = false;
            this.txtBoxID.Rounding = true;
            this.txtBoxID.RoundingInt = 17;
            this.txtBoxID.Size = new System.Drawing.Size(508, 32);
            this.txtBoxID.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.txtBoxID.TabIndex = 30;
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
            this.txtBoxNome.Location = new System.Drawing.Point(170, 188);
            this.txtBoxNome.Name = "txtBoxNome";
            this.txtBoxNome.PenWidth = 15;
            this.txtBoxNome.RGB = false;
            this.txtBoxNome.Rounding = true;
            this.txtBoxNome.RoundingInt = 17;
            this.txtBoxNome.Size = new System.Drawing.Size(508, 32);
            this.txtBoxNome.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.txtBoxNome.TabIndex = 29;
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
            this.txtBoxIdade.Location = new System.Drawing.Point(170, 253);
            this.txtBoxIdade.Name = "txtBoxIdade";
            this.txtBoxIdade.PenWidth = 15;
            this.txtBoxIdade.RGB = false;
            this.txtBoxIdade.Rounding = true;
            this.txtBoxIdade.RoundingInt = 17;
            this.txtBoxIdade.Size = new System.Drawing.Size(508, 32);
            this.txtBoxIdade.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.txtBoxIdade.TabIndex = 28;
            this.txtBoxIdade.Tag = "Cyber";
            this.txtBoxIdade.TextButton = "Preço";
            this.txtBoxIdade.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.txtBoxIdade.Timer_RGB = 300;
            // 
            // txtBoxCpf
            // 
            this.txtBoxCpf.Alpha = 20;
            this.txtBoxCpf.BackColor = System.Drawing.Color.Transparent;
            this.txtBoxCpf.Background_WidthPen = 1F;
            this.txtBoxCpf.BackgroundPen = true;
            this.txtBoxCpf.ColorBackground = System.Drawing.Color.White;
            this.txtBoxCpf.ColorBackground_Pen = System.Drawing.Color.LightGray;
            this.txtBoxCpf.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtBoxCpf.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtBoxCpf.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.txtBoxCpf.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.txtBoxCpf.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtBoxCpf.ForeColor = System.Drawing.Color.Black;
            this.txtBoxCpf.Lighting = false;
            this.txtBoxCpf.LinearGradientPen = false;
            this.txtBoxCpf.Location = new System.Drawing.Point(170, 318);
            this.txtBoxCpf.Name = "txtBoxCpf";
            this.txtBoxCpf.PenWidth = 15;
            this.txtBoxCpf.RGB = false;
            this.txtBoxCpf.Rounding = true;
            this.txtBoxCpf.RoundingInt = 17;
            this.txtBoxCpf.Size = new System.Drawing.Size(508, 32);
            this.txtBoxCpf.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.txtBoxCpf.TabIndex = 27;
            this.txtBoxCpf.Tag = "Cyber";
            this.txtBoxCpf.TextButton = "CPF";
            this.txtBoxCpf.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.txtBoxCpf.Timer_RGB = 300;
            // 
            // ClienteView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 509);
            this.Controls.Add(this.tabControlClientes);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ClienteView";
            this.Text = "ClienteView";
            this.tabListaClientes.ResumeLayout(false);
            this.tabListaClientes.PerformLayout();
            this.tabControlClientes.ResumeLayout(false);
            this.tabDetalhesClientes.ResumeLayout(false);
            this.tabDetalhesClientes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel GridClientes;
        private System.Windows.Forms.TabPage tabListaClientes;
        private System.Windows.Forms.Button btnPaginas;
        private ReaLTaiizor.Controls.Button btnVoltar;
        private ReaLTaiizor.Controls.Button btnAvancar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ReaLTaiizor.Controls.CyberTextBox cyberTextBox3;
        private ReaLTaiizor.Controls.CyberTextBox txtBoxPesquisa;
        private System.Windows.Forms.Button btnPesquisar;
        private ReaLTaiizor.Controls.Button btnNovoCliente;
        private System.Windows.Forms.TabControl tabControlClientes;
        private System.Windows.Forms.TabPage tabDetalhesClientes;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCancelar;
        private ReaLTaiizor.Controls.Button btnSalvar;
        private ReaLTaiizor.Controls.CyberTextBox txtBoxID;
        private ReaLTaiizor.Controls.CyberTextBox txtBoxNome;
        private ReaLTaiizor.Controls.CyberTextBox txtBoxIdade;
        private ReaLTaiizor.Controls.CyberTextBox txtBoxCpf;
    }
}