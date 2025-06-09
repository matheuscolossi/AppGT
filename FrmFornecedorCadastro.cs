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
    public partial class FrmFornecedorCadastro : Form
    {
        public FrmFornecedorCadastro()
        {
            InitializeComponent();
            Load += FrmFornecedorCadastro_Load;
        }

        private void FrmFornecedorCadastro_Load(object sender, EventArgs e)
        {
            mskCnpj.Mask = "00.000.000/0000-00";
            mskTelefone.Mask = "(00) 00000-0000";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var conn = new SqlConnection(Database.ConnectionString))
            using (var cmd = new SqlCommand(
                "INSERT INTO Fornecedores (nomeFornecedor,cnpjFornecedor,telefoneFornecedor,emailFornecedor,enderecoFornecedor) VALUES (@n,@c,@t,@e,@d)",
                conn))
            {
                cmd.Parameters.AddWithValue("@n", txtNomeFornecedor.Text);
                cmd.Parameters.AddWithValue("@c", mskCnpj.Text);
                cmd.Parameters.AddWithValue("@t", mskTelefone.Text);
                cmd.Parameters.AddWithValue("@e", txtEmail.Text);
                cmd.Parameters.AddWithValue("@d", txtEndereco.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Fornecedor cadastrado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void mskCnpj_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void txtNomeFornecedor_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
