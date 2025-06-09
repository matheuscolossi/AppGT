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
    public partial class FrmCategoriasListagem : Form
    {
        public FrmCategoriasListagem()
        {
            InitializeComponent();
            Load += (s, e) => CarregarGrid();
        }
        private void CarregarGrid()
        {
            using (var conn = new SqlConnection(Database.ConnectionString))
            using (var cmd = new SqlCommand(
                "SELECT id_categoria,nomeCategoria,descricaoCategoria FROM Categorias",
                conn))
            {
                conn.Open();
                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dgvCategorias.DataSource = dt;
            }
            dgvCategorias.Columns["id_categoria"].HeaderText = "ID Categoria";
            dgvCategorias.Columns["nomeCategoria"].HeaderText = "Nome";
            dgvCategorias.Columns["descricaoCategoria"].HeaderText = "Descrição";

        }

        private void FrmCategoriasListagem_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow == null) return;
            int id = (int)dgvCategorias.CurrentRow.Cells["id_categoria"].Value;
            using (var frm = new FrmCategoriaEdicao(id))
                if (frm.ShowDialog() == DialogResult.OK)
                    CarregarGrid();
        }

        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow == null) return;
            int id = (int)dgvCategorias.CurrentRow.Cells["id_categoria"].Value;
            if (MessageBox.Show("Confirma exclusão?", "Excluir",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            using (var conn = new SqlConnection(Database.ConnectionString))
            {
                conn.Open();

                using (var cmdDel = new SqlCommand(
                    "DELETE FROM Produtos WHERE id_categoria = @cid", conn))
                {
                    cmdDel.Parameters.AddWithValue("@cid", id);
                    cmdDel.ExecuteNonQuery();
                }

              
                using (var cmd = new SqlCommand(
                    "DELETE FROM Categorias WHERE id_categoria = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }

            CarregarGrid();
        }

        private void panelBotoes_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
