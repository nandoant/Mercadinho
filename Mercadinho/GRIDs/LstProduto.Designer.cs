﻿namespace Mercadinho.GRIDs
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
            this.txtBoxQtdCleinte = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // labelDescricao
            // 
            this.labelDescricao.AutoSize = true;
            this.labelDescricao.BackColor = System.Drawing.Color.White;
            this.labelDescricao.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescricao.ForeColor = System.Drawing.Color.Black;
            this.labelDescricao.Location = new System.Drawing.Point(640, 14);
            this.labelDescricao.Name = "labelDescricao";
            this.labelDescricao.Size = new System.Drawing.Size(54, 23);
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
            this.labelPreco.Location = new System.Drawing.Point(500, 14);
            this.labelPreco.Name = "labelPreco";
            this.labelPreco.Size = new System.Drawing.Size(75, 23);
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
            this.labelModelo.Location = new System.Drawing.Point(364, 14);
            this.labelModelo.Name = "labelModelo";
            this.labelModelo.Size = new System.Drawing.Size(62, 23);
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
            this.labelMarca.Location = new System.Drawing.Point(248, 14);
            this.labelMarca.Name = "labelMarca";
            this.labelMarca.Size = new System.Drawing.Size(48, 23);
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
            this.labelNome.Location = new System.Drawing.Point(93, 14);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(55, 23);
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
            this.labelID.Location = new System.Drawing.Point(13, 14);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(26, 23);
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
            this.btnEdit.Location = new System.Drawing.Point(976, 6);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.PressedBorderColor = System.Drawing.Color.Goldenrod;
            this.btnEdit.PressedColor = System.Drawing.Color.Goldenrod;
            this.btnEdit.Size = new System.Drawing.Size(57, 38);
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
            this.btnDelete.Location = new System.Drawing.Point(1039, 6);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.PressedBorderColor = System.Drawing.Color.DarkRed;
            this.btnDelete.PressedColor = System.Drawing.Color.DarkRed;
            this.btnDelete.Size = new System.Drawing.Size(57, 38);
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
            this.labelQtdDispo.Location = new System.Drawing.Point(835, 14);
            this.labelQtdDispo.Name = "labelQtdDispo";
            this.labelQtdDispo.Size = new System.Drawing.Size(91, 23);
            this.labelQtdDispo.TabIndex = 83;
            this.labelQtdDispo.Text = "Quantidade";
            this.labelQtdDispo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dropDownText.SetToolTip(this.labelQtdDispo, "Isso é um teste");
            // 
            // txtBoxQtdCleinte
            // 
            this.txtBoxQtdCleinte.Location = new System.Drawing.Point(944, 14);
            this.txtBoxQtdCleinte.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBoxQtdCleinte.Mask = "00000000000";
            this.txtBoxQtdCleinte.Name = "txtBoxQtdCleinte";
            this.txtBoxQtdCleinte.Size = new System.Drawing.Size(77, 22);
            this.txtBoxQtdCleinte.TabIndex = 86;
            // 
            // LstProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtBoxQtdCleinte);
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
            this.Size = new System.Drawing.Size(1105, 50);
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
        private System.Windows.Forms.MaskedTextBox txtBoxQtdCleinte;
    }
}
