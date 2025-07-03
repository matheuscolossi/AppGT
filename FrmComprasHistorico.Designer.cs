namespace ProjetoIntegradorLojaGearTrack
{
    partial class FrmComprasHistorico
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewHistorico = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistorico)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Berlin Sans FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Histórico de Compra";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(634, 430);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(189, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "Excluir Compra";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridViewHistorico
            // 
            this.dataGridViewHistorico.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistorico.Location = new System.Drawing.Point(15, 74);
            this.dataGridViewHistorico.Name = "dataGridViewHistorico";
            this.dataGridViewHistorico.Size = new System.Drawing.Size(808, 341);
            this.dataGridViewHistorico.TabIndex = 2;
            this.dataGridViewHistorico.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewHistorico_CellContentClick);
            // 
            // FrmComprasHistorico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 476);
            this.Controls.Add(this.dataGridViewHistorico);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "FrmComprasHistorico";
            this.Text = "FrmComprasHistorico";
            this.Load += new System.EventHandler(this.FrmComprasHistorico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistorico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridViewHistorico;
    }
}