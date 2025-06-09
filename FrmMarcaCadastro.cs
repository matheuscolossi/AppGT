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
    public partial class FrmMarcaCadastro : Form
    {
        public FrmMarcaCadastro()
        {
            InitializeComponent();
        }

        private void FrmMarcaCadastro_Load(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click_Click(object sender, EventArgs e)
        {
            using (var conn = new SqlConnection(Database.ConnectionString))
            using (var cmd = new SqlCommand("INSERT INTO Marcas (nomeMarcas) VALUES (@n)", conn))
            {
                cmd.Parameters.AddWithValue("@n", txtNomeMarca.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Marca cadastrada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
