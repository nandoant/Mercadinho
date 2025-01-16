namespace Mercadinho.GRIDs
{
    partial class LstProduto
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
            this.components = new System.ComponentModel.Container();
            this.labelDescricao = new System.Windows.Forms.Label();
            this.labelPreco = new System.Windows.Forms.Label();
            this.labelModelo = new System.Windows.Forms.Label();
            this.labelMarca = new System.Windows.Forms.Label();
            this.labelNome = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.Panel = new ReaLTaiizor.Controls.CyberTextBox();
            this.btnEdit = new ReaLTaiizor.Controls.Button();
            this.btnDelete = new ReaLTaiizor.Controls.Button();
            this.dropDownText = new System.Windows.Forms.ToolTip(this.components);
            this.labelQtdDispo = new System.Windows.Forms.Label();
            this.labelQtdCliente = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelDescricao
            // 
            this.labelDescricao.AutoSize = true;
            this.labelDescricao.BackColor = System.Drawing.Color.White;
            this.labelDescricao.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescricao.ForeColor = System.Drawing.Color.Black;
            this.labelDescricao.Location = new System.Drawing.Point(480, 11);
            this.labelDescricao.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDescricao.Name = "labelDescricao";
            this.labelDescricao.Size = new System.Drawing.Size(45, 19);
            this.labelDescricao.TabIndex = 35;
            this.labelDescricao.Text = "Desc..";
            this.dropDownText.SetToolTip(this.labelDescricao, "Isso é um teste");
            // 
            // labelPreco
            // 
            this.labelPreco.AutoSize = true;
            this.labelPreco.BackColor = System.Drawing.Color.White;
            this.labelPreco.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.labelPreco.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPreco.ForeColor = System.Drawing.Color.Black;
            this.labelPreco.Location = new System.Drawing.Point(375, 11);
            this.labelPreco.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPreco.Name = "labelPreco";
            this.labelPreco.Size = new System.Drawing.Size(65, 19);
            this.labelPreco.TabIndex = 34;
            this.labelPreco.Text = "R$ 55,90";
            // 
            // labelModelo
            // 
            this.labelModelo.AutoSize = true;
            this.labelModelo.BackColor = System.Drawing.Color.White;
            this.labelModelo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.labelModelo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelModelo.ForeColor = System.Drawing.Color.Black;
            this.labelModelo.Location = new System.Drawing.Point(273, 11);
            this.labelModelo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelModelo.Name = "labelModelo";
            this.labelModelo.Size = new System.Drawing.Size(51, 19);
            this.labelModelo.TabIndex = 33;
            this.labelModelo.Text = "Bovina";
            // 
            // labelMarca
            // 
            this.labelMarca.AutoSize = true;
            this.labelMarca.BackColor = System.Drawing.Color.White;
            this.labelMarca.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.labelMarca.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMarca.ForeColor = System.Drawing.Color.Black;
            this.labelMarca.Location = new System.Drawing.Point(186, 11);
            this.labelMarca.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMarca.Name = "labelMarca";
            this.labelMarca.Size = new System.Drawing.Size(42, 19);
            this.labelMarca.TabIndex = 32;
            this.labelMarca.Text = "Switf";
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.BackColor = System.Drawing.Color.White;
            this.labelNome.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.labelNome.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNome.ForeColor = System.Drawing.Color.Black;
            this.labelNome.Location = new System.Drawing.Point(70, 11);
            this.labelNome.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(45, 19);
            this.labelNome.TabIndex = 31;
            this.labelNome.Text = "Carne";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.BackColor = System.Drawing.Color.White;
            this.labelID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.labelID.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelID.ForeColor = System.Drawing.Color.Black;
            this.labelID.Location = new System.Drawing.Point(10, 11);
            this.labelID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(23, 19);
            this.labelID.TabIndex = 30;
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
            this.Panel.Font = new System.Drawing.Font("Segoe UI Symbol", 10F);
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
            this.Panel.Size = new System.Drawing.Size(829, 41);
            this.Panel.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.Panel.TabIndex = 29;
            this.Panel.Tag = "Cyber";
            this.Panel.TextButton = "";
            this.Panel.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.Panel.Timer_RGB = 300;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.White;
            this.btnEdit.BorderColor = System.Drawing.Color.LightGray;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.EnteredBorderColor = System.Drawing.Color.Black;
            this.btnEdit.EnteredColor = System.Drawing.Color.Gold;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnEdit.Image = global::Mercadinho.Properties.Resources.icons8_edit_24;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.btnEdit.InactiveColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(732, 5);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.PressedBorderColor = System.Drawing.Color.Goldenrod;
            this.btnEdit.PressedColor = System.Drawing.Color.Goldenrod;
            this.btnEdit.Size = new System.Drawing.Size(43, 31);
            this.btnEdit.TabIndex = 37;
            this.btnEdit.TextAlignment = System.Drawing.StringAlignment.Center;
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
            this.btnDelete.Location = new System.Drawing.Point(779, 5);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.PressedBorderColor = System.Drawing.Color.DarkRed;
            this.btnDelete.PressedColor = System.Drawing.Color.DarkRed;
            this.btnDelete.Size = new System.Drawing.Size(43, 31);
            this.btnDelete.TabIndex = 36;
            this.btnDelete.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // labelQtdDispo
            // 
            this.labelQtdDispo.BackColor = System.Drawing.Color.White;
            this.labelQtdDispo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.labelQtdDispo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQtdDispo.ForeColor = System.Drawing.Color.Black;
            this.labelQtdDispo.Location = new System.Drawing.Point(626, 11);
            this.labelQtdDispo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelQtdDispo.Name = "labelQtdDispo";
            this.labelQtdDispo.Size = new System.Drawing.Size(68, 19);
            this.labelQtdDispo.TabIndex = 83;
            this.labelQtdDispo.Text = "Quantidade";
            this.labelQtdDispo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dropDownText.SetToolTip(this.labelQtdDispo, "Isso é um teste");
            // 
            // labelQtdCliente
            // 
            this.labelQtdCliente.BackColor = System.Drawing.Color.White;
            this.labelQtdCliente.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.labelQtdCliente.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQtdCliente.ForeColor = System.Drawing.Color.Black;
            this.labelQtdCliente.Location = new System.Drawing.Point(707, 11);
            this.labelQtdCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelQtdCliente.Name = "labelQtdCliente";
            this.labelQtdCliente.Size = new System.Drawing.Size(68, 19);
            this.labelQtdCliente.TabIndex = 84;
            this.labelQtdCliente.Text = "Quantidade";
            this.labelQtdCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dropDownText.SetToolTip(this.labelQtdCliente, "Isso é um teste");
            // 
            // LstProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelQtdCliente);
            this.Controls.Add(this.labelQtdDispo);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.labelDescricao);
            this.Controls.Add(this.labelPreco);
            this.Controls.Add(this.labelModelo);
            this.Controls.Add(this.labelMarca);
            this.Controls.Add(this.labelNome);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.Panel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "LstProduto";
            this.Size = new System.Drawing.Size(829, 41);
            this.Load += new System.EventHandler(this.LstProduto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Controls.Button btnEdit;
        private ReaLTaiizor.Controls.Button btnDelete;
        private System.Windows.Forms.Label labelDescricao;
        private System.Windows.Forms.Label labelPreco;
        private System.Windows.Forms.Label labelModelo;
        private System.Windows.Forms.Label labelMarca;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.Label labelID;
        private ReaLTaiizor.Controls.CyberTextBox Panel;
        private System.Windows.Forms.ToolTip dropDownText;
        private System.Windows.Forms.Label labelQtdDispo;
        private System.Windows.Forms.Label labelQtdCliente;
    }
}
