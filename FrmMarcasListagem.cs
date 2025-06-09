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
    public partial class FrmMarcasListagem : Form
    {
        public FrmMarcasListagem()
        {
            InitializeComponent();
            Load += (s, e) => CarregarGrid();
        }

        private void FrmMarcasListagem_Load(object sender, EventArgs e)
        {
           
        }
        public void CarregarGrid()
        {
            using (var conn = new SqlConnection(Database.ConnectionString))
            using (var cmd = new SqlCommand("SELECT id_marcas, nomeMarcas FROM Marcas", conn))
            {
                conn.Open();
                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dgvMarcas.DataSource = dt;
            }
            dgvMarcas.Columns["id_marcas"].HeaderText = "ID";
            dgvMarcas.Columns["nomeMarcas"].HeaderText = "Nome";
        }

        private void dgvMarcas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvMarcas.CurrentRow == null) return;
            int id = (int)dgvMarcas.CurrentRow.Cells["id_marcas"].Value;
            using (var frm = new FrmMarcaEdicao(id))
                if (frm.ShowDialog() == DialogResult.OK)
                    CarregarGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvMarcas.CurrentRow == null) return;
            int id = (int)dgvMarcas.CurrentRow.Cells["id_marcas"].Value;
            if (MessageBox.Show("Confirma exclusão?", "Excluir",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var conn = new SqlConnection(Database.ConnectionString))
                using (var cmd = new SqlCommand(
                    "DELETE FROM Marcas WHERE id_marcas=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                CarregarGrid();
            }
        }
    }
    }

