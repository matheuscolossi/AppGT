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
    public partial class FrmComprasHistorico : Form
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GearTrackConnection"].ConnectionString);
        public FrmComprasHistorico()
        {
            InitializeComponent();
        }

        private void FrmComprasHistorico_Load(object sender, EventArgs e)
        {
           
            using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
            {
                conn.Open();

                string query = @"
SELECT 
    c.Id AS [ID Compra],
    f.nomeFornecedor AS [Fornecedor],
    c.DataCompra AS [Data da Compra],
    ISNULL(SUM(ic.Quantidade * ic.PrecoUnitario), 0) AS [Total da Compra],
    ISNULL(SUM(ic.Quantidade), 0) AS [Quantidade Total]
FROM Compra c
INNER JOIN Fornecedores f ON f.id_fornecedor = c.IdFornecedor
LEFT JOIN ItemCompra ic ON ic.IdCompra = c.Id
GROUP BY c.Id, f.nomeFornecedor, c.DataCompra
ORDER BY c.Id DESC
";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewHistorico.AutoGenerateColumns = true;
                dataGridViewHistorico.DataSource = dt;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (dataGridViewHistorico.SelectedRows.Count > 0)
            {
                int idCompra = Convert.ToInt32(dataGridViewHistorico.SelectedRows[0].Cells["ID Compra"].Value);

                DialogResult result = MessageBox.Show("Deseja realmente excluir essa compra?", "Confirmação", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GearTrackConnection"].ConnectionString))
                    {
                        conn.Open();

                        // Primeiro apaga os itens relacionados
                        SqlCommand cmd1 = new SqlCommand("DELETE FROM ItemCompra WHERE IdCompra = @id", conn);
                        cmd1.Parameters.AddWithValue("@id", idCompra);
                        cmd1.ExecuteNonQuery();

                        // Depois apaga a compra
                        SqlCommand cmd2 = new SqlCommand("DELETE FROM Compra WHERE Id = @id", conn);
                        cmd2.Parameters.AddWithValue("@id", idCompra);
                        cmd2.ExecuteNonQuery();

                        conn.Close();
                    }

                    MessageBox.Show("Compra excluída com sucesso.");
                    FrmComprasHistorico_Load(null, null); // Recarrega os dados
                }
            }
            else
            {
                MessageBox.Show("Selecione uma compra para excluir.");
            }

        }

        private void dataGridViewHistorico_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
