using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
            using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
            {
                string query = @"
            SELECT 
                id_produto, 
                nomePro, 
                descricaoPro, 
                precoCompra, 
                precoVenda, 
                quantidade_estoque, 
                id_categoria, 
                id_marca 
            FROM Produtos";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    var dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    dgvProdutos.DataSource = dt;
                }

                dgvProdutos.Columns["id_produto"].HeaderText = "ID";
                dgvProdutos.Columns["nomePro"].HeaderText = "Nome";
                dgvProdutos.Columns["descricaoPro"].HeaderText = "Descrição";
                dgvProdutos.Columns["precoCompra"].HeaderText = "Preço de Compra";
                dgvProdutos.Columns["precoVenda"].HeaderText = "Preço de Venda";
                dgvProdutos.Columns["quantidade_estoque"].HeaderText = "Estoque";
                dgvProdutos.Columns["id_categoria"].HeaderText = "Categoria";
                dgvProdutos.Columns["id_marca"].HeaderText = "Marca";
            }

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
            if (dgvProdutos.CurrentRow != null && dgvProdutos.CurrentRow.Index >= 0)
            {
                int idProduto = Convert.ToInt32(dgvProdutos.CurrentRow.Cells["id_produto"].Value);

                DialogResult result = MessageBox.Show("Deseja realmente excluir o produto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GearTrackConnection"].ConnectionString))
                    {
                        conn.Open();

                        SqlTransaction transacao = conn.BeginTransaction();

                        try
                        {
                            // Exclui primeiro da tabela ItemVenda
                            using (var cmd1 = new SqlCommand("DELETE FROM ItemVenda WHERE id_produto = @id", conn, transacao))
                            {
                                cmd1.Parameters.AddWithValue("@id", idProduto);
                                cmd1.ExecuteNonQuery();
                            }

                            // Exclui da tabela ItemCompra
                            using (var cmd2 = new SqlCommand("DELETE FROM ItemCompra WHERE IdProduto = @id", conn, transacao))
                            {
                                cmd2.Parameters.AddWithValue("@id", idProduto);
                                cmd2.ExecuteNonQuery();
                            }

                            // Por fim, exclui da tabela Produtos
                            using (var cmd3 = new SqlCommand("DELETE FROM Produtos WHERE id_produto = @id", conn, transacao))
                            {
                                cmd3.Parameters.AddWithValue("@id", idProduto);
                                cmd3.ExecuteNonQuery();
                            }

                            transacao.Commit();

                            MessageBox.Show("Produto excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CarregarGrid(); // Atualiza a lista
                        }
                        catch (Exception ex)
                        {
                            transacao.Rollback();
                            MessageBox.Show("Erro ao excluir produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um produto para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}



