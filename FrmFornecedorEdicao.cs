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
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjetoIntegradorLojaGearTrack
{
    public partial class FrmFornecedorEdicao : Form
    {
        private readonly int _idFornecedor;
        public FrmFornecedorEdicao(int idFornecedor)
        {
            InitializeComponent();
            _idFornecedor = idFornecedor;
        }

        private void FrmFornecedorEdicao_Load(object sender, EventArgs e)
        {
            CarregarDadosFornecedor();  
        }
        private void CarregarDadosFornecedor()
        {
            string cs = Database.ConnectionString; // ou pegue de app.config

            using (var conn = new SqlConnection(cs))
            using (var cmd = new SqlCommand(
                "SELECT nomeFornecedor, cnpjFornecedor, telefoneFornecedor, emailFornecedor, enderecoFornecedor FROM Fornecedores WHERE id_fornecedor = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", _idFornecedor);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Supondo que no designer você tenha TextBoxes chamados txtNome, txtCNPJ, txtTelefone, txtEmail, txtEndereco
                        txtNome.Text = reader["nomeFornecedor"].ToString();
                        mskCnpj.Text = reader["cnpjFornecedor"].ToString();
                        txtTelefone.Text = reader["telefoneFornecedor"].ToString();
                        txtEmail.Text = reader["emailFornecedor"].ToString();
                        txtEndereco.Text = reader["enderecoFornecedor"].ToString();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validar campos como desejar (não mostrei aqui)
            string novoNome = txtNome.Text.Trim();
            string novoCNPJ = mskCnpj.Text.Trim();
            string novoTelefone = txtTelefone.Text.Trim();
            string novoEmail = txtEmail.Text.Trim();
            string novoEndereco = txtEndereco.Text.Trim();

            string cs = Database.ConnectionString;

            using (var conn = new SqlConnection(cs))
            using (var cmd = new SqlCommand(
                "UPDATE Fornecedores SET " +
                " nomeFornecedor = @nomeFornecedor, " +
                " cnpjFornecedor = @cnpjFornecedor, " +
                " telefoneFornecedor = @telFornecedor, " +
                " emailFornecedor = @emailFornecedor, " +
                " enderecoFornecedor = @endFornecedor " +
                "WHERE id_fornecedor = @idFornecedor", conn))
            {
                cmd.Parameters.AddWithValue("@nomeFornecedor", novoNome);
                cmd.Parameters.AddWithValue("@cnpjFornecedor", novoCNPJ);
                cmd.Parameters.AddWithValue("@telFornecedor", novoTelefone);
                cmd.Parameters.AddWithValue("@emailFornecedor", novoEmail);
                cmd.Parameters.AddWithValue("@endFornecedor", novoEndereco);
                cmd.Parameters.AddWithValue("@idFornecedor", _idFornecedor);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Fornecedor atualizado com sucesso!",
                            "Sucesso",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
