namespace Mercadinho.GRIDs
{
    partial class LstVenda
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnProdutos = new ReaLTaiizor.Controls.Button();
            this.btnDelete = new ReaLTaiizor.Controls.Button();
            this.labelData = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelNome = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.Panel = new ReaLTaiizor.Controls.CyberTextBox();
            this.SuspendLayout();
            // 
            // btnProdutos
            // 
            this.btnProdutos.BackColor = System.Drawing.Color.White;
            this.btnProdutos.BorderColor = System.Drawing.Color.LightGray;
            this.btnProdutos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProdutos.EnteredBorderColor = System.Drawing.Color.Black;
            this.btnProdutos.EnteredColor = System.Drawing.Color.DodgerBlue;
            this.btnProdutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnProdutos.Image = global::Mercadinho.Properties.Resources.icons8_search_24;
            this.btnProdutos.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnProdutos.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.btnProdutos.InactiveColor = System.Drawing.Color.White;
            this.btnProdutos.Location = new System.Drawing.Point(840, 6);
            this.btnProdutos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnProdutos.Name = "btnProdutos";
            this.btnProdutos.PressedBorderColor = System.Drawing.Color.MidnightBlue;
            this.btnProdutos.PressedColor = System.Drawing.Color.MidnightBlue;
            this.btnProdutos.Size = new System.Drawing.Size(57, 38);
            this.btnProdutos.TabIndex = 53;
            this.btnProdutos.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.BorderColor = System.Drawing.Color.LightGray;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.EnteredBorderColor = System.Drawing.Color.Black;
            this.btnDelete.EnteredColor = System.Drawing.Color.Brown;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnDelete.Image = global::Mercadinho.Properties.Resources.icons8_delete_24__2_;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDelete.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.btnDelete.InactiveColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(1039, 6);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.PressedBorderColor = System.Drawing.Color.DarkRed;
            this.btnDelete.PressedColor = System.Drawing.Color.DarkRed;
            this.btnDelete.Size = new System.Drawing.Size(57, 38);
            this.btnDelete.TabIndex = 52;
            this.btnDelete.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelData
            // 
            this.labelData.AutoSize = true;
            this.labelData.BackColor = System.Drawing.Color.White;
            this.labelData.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelData.ForeColor = System.Drawing.Color.Black;
            this.labelData.Location = new System.Drawing.Point(683, 14);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(136, 23);
            this.labelData.TabIndex = 51;
            this.labelData.Text = "Data da Compra";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.BackColor = System.Drawing.Color.White;
            this.labelTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.ForeColor = System.Drawing.Color.Black;
            this.labelTotal.Location = new System.Drawing.Point(913, 14);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(107, 23);
            this.labelTotal.TabIndex = 50;
            this.labelTotal.Text = "R$ 151555,90";
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.BackColor = System.Drawing.Color.White;
            this.labelNome.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNome.ForeColor = System.Drawing.Color.Black;
            this.labelNome.Location = new System.Drawing.Point(137, 14);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(140, 23);
            this.labelNome.TabIndex = 49;
            this.labelNome.Text = "Nome do Cliente";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.BackColor = System.Drawing.Color.White;
            this.labelID.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelID.ForeColor = System.Drawing.Color.Black;
            this.labelID.Location = new System.Drawing.Point(13, 14);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(26, 23);
            this.labelID.TabIndex = 48;
            this.labelID.Text = "01";
            // 
            // Panel
            // 
            this.Panel.Alpha = 20;
            this.Panel.BackColor = System.Drawing.Color.Transparent;
            this.Panel.Background_WidthPen = 1F;
            this.Panel.BackgroundPen = true;
            this.Panel.ColorBackground = System.Drawing.Color.White;
            this.Panel.ColorBackground_Pen = System.Drawing.Color.LightGray;
            this.Panel.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.Panel.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.Panel.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.Panel.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.Panel.Enabled = false;
            this.Panel.Font = new System.Drawing.Font("Segoe UI Symbol", 12F);
            this.Panel.ForeColor = System.Drawing.Color.Brown;
            this.Panel.Lighting = false;
            this.Panel.LinearGradientPen = false;
            this.Panel.Location = new System.Drawing.Point(0, 0);
            this.Panel.Margin = new System.Windows.Forms.Padding(0);
            this.Panel.Name = "Panel";
            this.Panel.PenWidth = 15;
            this.Panel.RGB = false;
            this.Panel.Rounding = true;
            this.Panel.RoundingInt = 10;
            this.Panel.Size = new System.Drawing.Size(1105, 50);
            this.Panel.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.Panel.TabIndex = 47;
            this.Panel.Tag = "Cyber";
            this.Panel.TextButton = "";
            this.Panel.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.Panel.Timer_RGB = 300;
            // 
            // LstVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnProdutos);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.labelData);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.labelNome);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.Panel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "LstVenda";
            this.Size = new System.Drawing.Size(1105, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Controls.Button btnProdutos;
        private ReaLTaiizor.Controls.Button btnDelete;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.Label labelID;
        private ReaLTaiizor.Controls.CyberTextBox Panel;
    }
}
