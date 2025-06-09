using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoIntegradorLojaGearTrack;

namespace ProjetoIntegradorLojaGearTrack
{
    public partial class FrmClienteCadastro : Form
    {
        public FrmClienteCadastro()
        {
            InitializeComponent();
        }

        private void FrmClienteCadastro_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var conn = new SqlConnection(Database.ConnectionString))
            using (var cmd = new SqlCommand(
                "INSERT INTO Clientes (nomeCliente,cpfCliente,telefoneCliente,emailCliente,enderecoCliente) VALUES (@n,@c,@t,@e,@d)",
                conn))
            {
                cmd.Parameters.AddWithValue("@n", txtNomeCliente.Text);
                cmd.Parameters.AddWithValue("@c", mskCpfCliente.Text);
                cmd.Parameters.AddWithValue("@t", mskTelefoneCliente.Text);
                cmd.Parameters.AddWithValue("@e", txtEmailCliente.Text);
                cmd.Parameters.AddWithValue("@d", txtEnderecoCliente.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Cliente cadastrado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mskTelefoneCliente_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void mskCpfCliente_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtEmailCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtEnderecoCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtNomeCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
