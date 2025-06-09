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
    public partial class FrmProdutosListagem : Form
    {
        public FrmProdutosListagem()
        {
            InitializeComponent();
            Load += (s, e) => CarregarGrid();
            btnEditar.Click += (s, e) => Editar();
            btnExcluir.Click += (s, e) => Excluir();
            btnAtualizar.Click += (s, e) => CarregarGrid();
        }
        public void CarregarGrid()
        {
            using (var conn = new SqlConnection(Database.ConnectionString))
            using (var cmd = new SqlCommand(
                "SELECT id_produto, nomePro, descricaoPro, precoPro, quantidade_estoque, id_categoria, id_marca FROM Produtos", conn))
            {
                conn.Open();
                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dgvProdutos.DataSource = dt;
            }

            dgvProdutos.Columns["id_produto"].HeaderText = "ID";
            dgvProdutos.Columns["nomePro"].HeaderText = "Nome";
            dgvProdutos.Columns["descricaoPro"].HeaderText = "Descrição";
            dgvProdutos.Columns["precoPro"].HeaderText = "Preço";
            dgvProdutos.Columns["quantidade_estoque"].HeaderText = "Estoque";
            dgvProdutos.Columns["id_categoria"].HeaderText = "Categoria";
            dgvProdutos.Columns["id_marca"].HeaderText = "Marca";
        }
        private void Editar()
        {
            if (dgvProdutos.CurrentRow == null) return;
            int id = (int)dgvProdutos.CurrentRow.Cells["id_produto"].Value;
            using (var frm = new FrmProdutoEdicao(id))
                if (frm.ShowDialog() == DialogResult.OK)
                    CarregarGrid();
        }

        private void Excluir()
        {
           
        }

        private void FrmProdutosListagem_Load(object sender, EventArgs e)
        {

        }

        private void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.CurrentRow == null) return;
            int id = (int)dgvProdutos.CurrentRow.Cells["id_produto"].Value;
            if (MessageBox.Show("Confirma exclusão?", "Excluir",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var conn = new SqlConnection(Database.ConnectionString))
                using (var cmd = new SqlCommand(
                    "DELETE FROM Produtos WHERE id_categoria=@id", conn))
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
