namespace ProjetoIntegradorLojaGearTrack
{
    partial class FrmRelatorioFinanceiro
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalGasto = new System.Windows.Forms.TextBox();
            this.txtTotalFaturado = new System.Windows.Forms.TextBox();
            this.txtLucroBruto = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Gasto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Italic);
            this.label2.Location = new System.Drawing.Point(55, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lucro Bruto:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Italic);
            this.label3.Location = new System.Drawing.Point(29, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total Faturado:";
            // 
            // txtTotalGasto
            // 
            this.txtTotalGasto.Location = new System.Drawing.Point(187, 91);
            this.txtTotalGasto.Name = "txtTotalGasto";
            this.txtTotalGasto.ReadOnly = true;
            this.txtTotalGasto.Size = new System.Drawing.Size(233, 20);
            this.txtTotalGasto.TabIndex = 3;
            // 
            // txtTotalFaturado
            // 
            this.txtTotalFaturado.Location = new System.Drawing.Point(187, 151);
            this.txtTotalFaturado.Name = "txtTotalFaturado";
            this.txtTotalFaturado.ReadOnly = true;
            this.txtTotalFaturado.Size = new System.Drawing.Size(233, 20);
            this.txtTotalFaturado.TabIndex = 4;
            // 
            // txtLucroBruto
            // 
            this.txtLucroBruto.Location = new System.Drawing.Point(187, 212);
            this.txtLucroBruto.Name = "txtLucroBruto";
            this.txtLucroBruto.ReadOnly = true;
            this.txtLucroBruto.Size = new System.Drawing.Size(233, 20);
            this.txtLucroBruto.TabIndex = 5;
            // 
            // FrmRelatorioFinanceiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 372);
            this.Controls.Add(this.txtLucroBruto);
            this.Controls.Add(this.txtTotalFaturado);
            this.Controls.Add(this.txtTotalGasto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmRelatorioFinanceiro";
            this.Text = "FrmRelatorioFinanceiro";
            this.Load += new System.EventHandler(this.FrmRelatorioFinanceiro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalGasto;
        private System.Windows.Forms.TextBox txtTotalFaturado;
        private System.Windows.Forms.TextBox txtLucroBruto;
    }
}