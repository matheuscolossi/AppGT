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
    public partial class FrmVendasHistorico : Form
    {
        public FrmVendasHistorico()
        {
            InitializeComponent();
        }
        private void CarregarHistoricoVendas()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GearTrackConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                V.id_venda AS [ID Venda],
                V.dataVenda AS [Data],
                P.nomePro AS [Produto],
                IV.quantidade AS [Qtd],
                IV.precoVenda AS [Preço Unitário],
                (IV.quantidade * IV.precoVenda) AS [Subtotal]
            FROM Venda V
            INNER JOIN ItemVenda IV ON V.id_venda = IV.id_venda
            INNER JOIN Produtos P ON IV.id_produto = P.id_produto
            ORDER BY V.dataVenda DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewHistorico.DataSource = dt;
            }
        }
        private void FrmVendasHistorico_Load(object sender, EventArgs e)
        {
            CarregarHistoricoVendas();
        }

        private void dataGridViewHistorico_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridViewHistorico.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma venda para excluir.");
                return;
            }

            int idVenda = Convert.ToInt32(dataGridViewHistorico.SelectedRows[0].Cells["ID Venda"].Value);

            DialogResult confirm = MessageBox.Show("Deseja realmente excluir esta venda?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                string connStr = ConfigurationManager.ConnectionStrings["GearTrackConnection"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    // Primeiro exclui os itens da venda (ItemVenda)
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM ItemVenda WHERE id_venda = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idVenda);
                        cmd.ExecuteNonQuery();
                    }

                    // Depois exclui a venda (Venda)
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Venda WHERE id_venda = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idVenda);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Venda excluída com sucesso!");
                CarregarHistoricoVendas(); // Atualiza o grid
            }
        }
    }
}
