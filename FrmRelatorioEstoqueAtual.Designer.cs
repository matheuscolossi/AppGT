namespace ProjetoIntegradorLojaGearTrack
{
    partial class FrmRelatorioEstoqueAtual
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewEstoque = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEstoque)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Estoque Atual";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dataGridViewEstoque
            // 
            this.dataGridViewEstoque.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewEstoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEstoque.Location = new System.Drawing.Point(29, 62);
            this.dataGridViewEstoque.Name = "dataGridViewEstoque";
            this.dataGridViewEstoque.Size = new System.Drawing.Size(734, 353);
            this.dataGridViewEstoque.TabIndex = 1;
            this.dataGridViewEstoque.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(280, 434);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(211, 43);
            this.button1.TabIndex = 2;
            this.button1.Text = "Atualizar Estoque";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmRelatorioEstoqueAtual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 489);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewEstoque);
            this.Controls.Add(this.label1);
            this.Name = "FrmRelatorioEstoqueAtual";
            this.Text = "FrmRelatorioEstoqueAtual";
            this.Load += new System.EventHandler(this.FrmRelatorioEstoqueAtual_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEstoque)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewEstoque;
        private System.Windows.Forms.Button button1;
    }
}