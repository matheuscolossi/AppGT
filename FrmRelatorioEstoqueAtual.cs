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
    public partial class FrmRelatorioEstoqueAtual : Form
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GearTrackConnection"].ConnectionString);



        public FrmRelatorioEstoqueAtual()
        {
            InitializeComponent();
            CarregarEstoque();
        }
        private void CarregarEstoque()
        {
            try
            {
                string query = @"
    SELECT 
        p.id_produto AS ID,
        p.nomePro AS Produto,
        c.nomeCategoria AS Categoria,
        m.nomeMarcas AS Marca,
        p.precoVenda AS [Preço Venda],
        p.quantidade_estoque AS [Estoque Atual]
    FROM Produtos p
    JOIN Categorias c ON p.id_categoria = c.id_categoria
    JOIN Marcas m ON p.id_marca = m.id_marcas
    WHERE p.quantidade_estoque > 0";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridViewEstoque.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar estoque: " + ex.Message);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarEstoque();
        }
    

        private void FrmRelatorioEstoqueAtual_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarregarEstoque();
        }
    }
}
