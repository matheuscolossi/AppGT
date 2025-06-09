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
    public partial class FrmCategoriaCadastro : Form
    {
        public FrmCategoriaCadastro()
        {
            InitializeComponent();
        }

        private void FrmCategoriaCadastro_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new SqlConnection(Database.ConnectionString))
                using (var cmd = new SqlCommand(
                    "INSERT INTO Categorias (nomeCategoria, descricaoCategoria) VALUES (@n,@d)",
                    conn))
                {
                    cmd.Parameters.AddWithValue("@n", txtNomeCategoria.Text);
                    cmd.Parameters.AddWithValue("@d", txtDescricaoCategoria.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Categoria cadastrada com sucesso", "Sucesso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar categoria: " + ex.Message,
                                "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
