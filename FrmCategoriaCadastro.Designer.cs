namespace ProjetoIntegradorLojaGearTrack
{
    partial class FrmCategoriaCadastro
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
            this.btnCancelar_Click = new System.Windows.Forms.Button();
            this.btnSalvar_Click = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNomeCategoria = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescricaoCategoria = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancelar_Click
            // 
            this.btnCancelar_Click.BackColor = System.Drawing.Color.DimGray;
            this.btnCancelar_Click.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar_Click.ForeColor = System.Drawing.Color.White;
            this.btnCancelar_Click.Location = new System.Drawing.Point(434, 428);
            this.btnCancelar_Click.Name = "btnCancelar_Click";
            this.btnCancelar_Click.Size = new System.Drawing.Size(101, 37);
            this.btnCancelar_Click.TabIndex = 25;
            this.btnCancelar_Click.Text = "Cancelar";
            this.btnCancelar_Click.UseVisualStyleBackColor = false;
            this.btnCancelar_Click.Click += new System.EventHandler(this.btnCancelar_Click_Click);
            // 
            // btnSalvar_Click
            // 
            this.btnSalvar_Click.BackColor = System.Drawing.Color.DimGray;
            this.btnSalvar_Click.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar_Click.ForeColor = System.Drawing.Color.White;
            this.btnSalvar_Click.Location = new System.Drawing.Point(550, 428);
            this.btnSalvar_Click.Name = "btnSalvar_Click";
            this.btnSalvar_Click.Size = new System.Drawing.Size(82, 38);
            this.btnSalvar_Click.TabIndex = 24;
            this.btnSalvar_Click.Text = "Salvar";
            this.btnSalvar_Click.UseVisualStyleBackColor = false;
            this.btnSalvar_Click.Click += new System.EventHandler(this.btnSalvar_Click_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(110, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 15);
            this.label6.TabIndex = 22;
            this.label6.Text = "DESCRIÇÃO:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.DimGray;
            this.label5.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(109, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(331, 28);
            this.label5.TabIndex = 21;
            this.label5.Text = "CADASTRO DE CATEGORIA";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtNomeCategoria
            // 
            this.txtNomeCategoria.Location = new System.Drawing.Point(202, 152);
            this.txtNomeCategoria.Name = "txtNomeCategoria";
            this.txtNomeCategoria.Size = new System.Drawing.Size(205, 20);
            this.txtNomeCategoria.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(110, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "NOME:";
            // 
            // txtDescricaoCategoria
            // 
            this.txtDescricaoCategoria.Location = new System.Drawing.Point(202, 199);
            this.txtDescricaoCategoria.Multiline = true;
            this.txtDescricaoCategoria.Name = "txtDescricaoCategoria";
            this.txtDescricaoCategoria.Size = new System.Drawing.Size(205, 103);
            this.txtDescricaoCategoria.TabIndex = 26;
            // 
            // FrmCategoriaCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 500);
            this.Controls.Add(this.txtDescricaoCategoria);
            this.Controls.Add(this.btnCancelar_Click);
            this.Controls.Add(this.btnSalvar_Click);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNomeCategoria);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCategoriaCadastro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Categoria";
            this.Load += new System.EventHandler(this.FrmCategoriaCadastro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar_Click;
        private System.Windows.Forms.Button btnSalvar_Click;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNomeCategoria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescricaoCategoria;
    }
}