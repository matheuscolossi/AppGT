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
    public partial class FrmCompraRegistro : Form
    {
        
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GearTrackConnection"].ConnectionString);
        private NumericUpDown numericUpDownQtd;
        private Label lblTotal;
        private TextBox txtTotal;
        private object idCompra;

        public FrmCompraRegistro()
        {
            InitializeComponent();
            CarregarFornecedores();
            CarregarProdutos();
            ConfigurarDataGrid();
            txtTotal = new TextBox
            {
                Location = new Point(10, 300), // Adjust the location as needed
                Size = new Size(100, 20)      // Adjust the size as needed
            };
            this.Controls.Add(txtTotal); // Add it to the form's controls
        }
        
        private void CarregarFornecedores()
        {
            SqlCommand cmd = new SqlCommand("SELECT id_fornecedor, nomeFornecedor FROM Fornecedores", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            comboBoxFornecedor.DataSource = dt;
            comboBoxFornecedor.DisplayMember = "nomeFornecedor";
            comboBoxFornecedor.ValueMember = "id_fornecedor";
        }
        private decimal ObterPrecoProduto(int produtoId)
        {
            SqlCommand cmd = new SqlCommand("SELECT precoCompra FROM Produtos WHERE id_produto = @id", conn);
            cmd.Parameters.AddWithValue("@id", produtoId);
            conn.Open();
            decimal preco = Convert.ToDecimal(cmd.ExecuteScalar());
            conn.Close();
            return preco;
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
            dataGridView1.Columns["ProdutoId"].Visible = false;
            dataGridView1.Columns.Add("Nome", "Produto");
            dataGridView1.Columns.Add("Quantidade", "Quantidade");
            dataGridView1.Columns.Add("PrecoUnitario", "Preço Unitário");
            dataGridView1.Columns.Add("Subtotal", "Subtotal");
        }

        private void FrmCompraRegistro_Load(object sender, EventArgs e)
        {
            
        }

        private int BuscarIdProdutoPeloNome(string nomeProduto)
        {
            SqlCommand cmd = new SqlCommand("SELECT id_produto FROM Produtos WHERE nomePro = @nome", conn);
            cmd.Parameters.AddWithValue("@nome", nomeProduto);
            return (int)cmd.ExecuteScalar();
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT id_fornecedor, nomeFornecedor FROM Fornecedores", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxFornecedor.DataSource = dt;
                comboBoxFornecedor.DisplayMember = "nomeFornecedor";
                comboBoxFornecedor.ValueMember = "id_fornecedor";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (var conn = new SqlConnection(Database.ConnectionString))
            {
                conn.Open();

                int novoIdCompra;
                using (var cmdCompra = new SqlCommand(
                    "INSERT INTO Compra (IdFornecedor, DataCompra) OUTPUT INSERTED.Id VALUES (@idFornecedor, @dataCompra)", conn))
                {
                    cmdCompra.Parameters.AddWithValue("@idFornecedor", comboBoxFornecedor.SelectedValue);
                    cmdCompra.Parameters.AddWithValue("@dataCompra", DateTime.Now);
                    novoIdCompra = (int)cmdCompra.ExecuteScalar();
                }
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    try
                    {
                        string nomeProduto = row.Cells["Nome"].Value.ToString();
                        int quantidade = Convert.ToInt32(row.Cells["Quantidade"].Value);
                        decimal precoUnitario = Convert.ToDecimal(row.Cells["PrecoUnitario"].Value);

                        // Buscar ID do produto
                        int idProduto;
                        using (var cmdProduto = new SqlCommand("SELECT id_produto FROM Produtos WHERE nomePro = @nome", conn))

                        {
                            cmdProduto.Parameters.AddWithValue("@nome", nomeProduto);
                            object result = cmdProduto.ExecuteScalar();

                            if (result == null)
                            {
                                MessageBox.Show("Produto não encontrado: " + nomeProduto);
                                continue;
                            }

                            idProduto = Convert.ToInt32(result);
                        }

                        // Inserir item da compra
                        using (var cmdItem = new SqlCommand(
                            "INSERT INTO ItemCompra (IdCompra, IdProduto, Quantidade, PrecoUnitario) VALUES (@ic,@ip,@q,@p)", conn))
                        {
                            cmdItem.Parameters.AddWithValue("@ic", novoIdCompra);
                            cmdItem.Parameters.AddWithValue("@ip", idProduto);
                            cmdItem.Parameters.AddWithValue("@q", quantidade);
                            cmdItem.Parameters.AddWithValue("@p", precoUnitario);
                            cmdItem.ExecuteNonQuery();
                        }
                        using (var cmdEstoque = new SqlCommand("UPDATE Produtos SET quantidade_estoque = quantidade_estoque + @qtd WHERE id_produto = @id", conn))
                        {
                            cmdEstoque.Parameters.AddWithValue("@qtd", quantidade);
                            cmdEstoque.Parameters.AddWithValue("@id", idProduto);
                            cmdEstoque.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao salvar item da compra: " + ex.Message);
                    }
                }

                MessageBox.Show("Itens da compra salvos com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        private void comboBoxProduto_SelectedIndexChanged(object sender, EventArgs e)
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

            decimal precoUnit = ObterPrecoProduto(produtoId);
            decimal subtotal = qtd * precoUnit;

            dataGridView1.Rows.Add(produtoId, nome, qtd, precoUnit.ToString("F2"), subtotal.ToString("F2"));
            AtualizarTotal();

        }

        private void numericQuantidade_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Subtotal"].Value != null)
                    total += Convert.ToDecimal(row.Cells["Subtotal"].Value);
            }

            textBoxTotal.Text = total.ToString("F2"); // ou "C2" se quiser formatar com R$
        }

        private void textBoxTotal_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
