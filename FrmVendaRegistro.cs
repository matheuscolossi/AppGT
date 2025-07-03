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
    public partial class FrmVendaRegistro : Form
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GearTrackConnection"].ConnectionString);
        private TextBox txtTotal;
        public FrmVendaRegistro()
        {
            InitializeComponent();
            CarregarProdutos();
            ConfigurarDataGrid();
            txtTotal = new TextBox
            {
                Location = new Point(10, 300),
                Size = new Size(100, 20)
            };
            this.Controls.Add(txtTotal);
        }
        private void CarregarProdutos()
        {
            SqlCommand cmd = new SqlCommand("SELECT id_produto, nomePro FROM Produtos", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBoxProduto.DataSource = dt;
            comboBoxProduto.DisplayMember = "nomePro";
            comboBoxProduto.ValueMember = "id_produto";
        }
        private void ConfigurarDataGrid()
        {
            dataGridView1.Columns.Add("ProdutoId", "ProdutoId");
            dataGridView1.Columns.Add("Nome", "Produto");
            dataGridView1.Columns.Add("Quantidade", "Quantidade");
            dataGridView1.Columns.Add("PrecoVenda", "Preço de Venda");
            dataGridView1.Columns.Add("Subtotal", "Subtotal");

        }
        private decimal ObterPrecoVendaProduto(int produtoId)
        {
            SqlCommand cmd = new SqlCommand("SELECT precoVenda FROM Produtos WHERE id_produto = @id", conn);
            cmd.Parameters.AddWithValue("@id", produtoId);
            conn.Open();
            decimal preco = Convert.ToDecimal(cmd.ExecuteScalar());
            conn.Close();
            return preco;
        }


        private void FrmVendaRegistro_Load(object sender, EventArgs e)
        {

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (comboBoxProduto.SelectedItem == null || numericQuantidade.Value < 1)
            {
                MessageBox.Show("Selecione um produto e uma quantidade válida.");
                return;
            }

            int produtoId = (int)comboBoxProduto.SelectedValue;
            string nome = comboBoxProduto.Text;
            int qtd = (int)numericQuantidade.Value;
            decimal precoVenda = ObterPrecoVendaProduto(produtoId);
            decimal subtotal = qtd * precoVenda;

            dataGridView1.Rows.Add(produtoId, nome, qtd, precoVenda.ToString("F2"), subtotal.ToString("F2"));
            AtualizarTotal();
        }
        private void AtualizarTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Subtotal"].Value != null)
                    total += Convert.ToDecimal(row.Cells["Subtotal"].Value);
            }

            textBoxTotal.Text = total.ToString("C", new System.Globalization.CultureInfo("pt-BR"));
        }

        // Replace all occurrences of 'dgvItens' with 'dataGridView1' in the method 'button1_Click'  
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int novaIdVenda;

                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GearTrackConnection"].ConnectionString))
                {
                    conn.Open();

                    using (var cmdVenda = new SqlCommand("INSERT INTO Venda (dataVenda) OUTPUT INSERTED.id_venda VALUES (@dataVenda)", conn))
                    {
                        cmdVenda.Parameters.AddWithValue("@dataVenda", DateTime.Now);
                        novaIdVenda = (int)cmdVenda.ExecuteScalar();
                    }

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string nomeProduto = row.Cells["Nome"].Value.ToString();
                        int quantidade = Convert.ToInt32(row.Cells["Quantidade"].Value);
                        decimal precoVenda = Convert.ToDecimal(row.Cells["PrecoVenda"].Value);

                        int idProduto;
                        using (var cmdProduto = new SqlCommand("SELECT id_produto FROM Produtos WHERE nomePro = @nome", conn))
                        {
                            cmdProduto.Parameters.AddWithValue("@nome", nomeProduto);
                            idProduto = (int)cmdProduto.ExecuteScalar();
                        }

                        using (var cmdItem = new SqlCommand("INSERT INTO ItemVenda (id_venda, id_produto, quantidade, precoVenda) VALUES (@id_venda, @id_produto, @quantidade, @precoVenda)", conn))
                        {
                            cmdItem.Parameters.AddWithValue("@id_venda", novaIdVenda);
                            cmdItem.Parameters.AddWithValue("@id_produto", idProduto);
                            cmdItem.Parameters.AddWithValue("@quantidade", quantidade);
                            cmdItem.Parameters.AddWithValue("@precoVenda", precoVenda);
                            cmdItem.ExecuteNonQuery();
                        }
                        using (var cmdEstoque = new SqlCommand("UPDATE Produtos SET quantidade_estoque = quantidade_estoque - @qtd WHERE id_produto = @id", conn))
                        {
                            cmdEstoque.Parameters.AddWithValue("@qtd", quantidade);
                            cmdEstoque.Parameters.AddWithValue("@id", idProduto);
                            cmdEstoque.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Venda registrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Rows.Clear();
                AtualizarTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar venda: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            decimal total = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Subtotal"].Value != null)
                    total += Convert.ToDecimal(row.Cells["Subtotal"].Value);
            }

            textBoxTotal.Text = total.ToString("F2"); // ou "C2" se quiser formatar com R$
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBoxTotal_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
