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


namespace ProjetoIntegradorLojaGearTrack
{
    public partial class FrmProdutoEdicao : Form
    {
        private readonly int _idProduto;
        public FrmProdutoEdicao(int idProduto)
        {
            InitializeComponent();
            _idProduto = idProduto;
            CarregarDados();
            CarregarCategorias();
            CarregarMarcas();
        }
        private void CarregarCategorias()
        {
            using (var conn = new SqlConnection(Database.ConnectionString))
            using (var da = new SqlDataAdapter(
                "SELECT id_categoria, nomeCategoria FROM Categorias", conn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                cboCategoria.DataSource = dt;
                cboCategoria.ValueMember = "id_categoria";
                cboCategoria.DisplayMember = "nomeCategoria";
                cboCategoria.SelectedIndex = -1;
            }
        }

        private void CarregarMarcas()
        {
            using (var conn = new SqlConnection(Database.ConnectionString))
            using (var da = new SqlDataAdapter(
                "SELECT id_marcas, nomeMarcas FROM Marcas", conn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                cboMarca.DataSource = dt;
                cboMarca.ValueMember = "id_marcas";
                cboMarca.DisplayMember = "nomeMarcas";
                cboMarca.SelectedIndex = -1;
            }
        }

        private void CarregarDados()
        {
            using (var conn = new SqlConnection(Database.ConnectionString))
            using (var cmd = new SqlCommand(
                "SELECT nomePro, descricaoPro, precoCompra, precoVenda, quantidade_estoque, id_categoria, id_marca\r\n " +
                "FROM Produtos WHERE id_produto = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", _idProduto);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                    if (dr.Read())
                    {
                        txtNomeProduto.Text = dr.GetString(0);
                        txtDescricao.Text = dr.IsDBNull(1) ? "" : dr.GetString(1);
                        txtPrecoCompra.Text = dr.GetDecimal(2).ToString("F2");
                        txtPrecoVenda.Text = dr.GetDecimal(3).ToString("F2");
                     

                        cboCategoria.SelectedValue = dr.GetInt32(5);
                        cboMarca.SelectedValue = dr.GetInt32(6);
                    }
            }
        }
        private void FrmProdutoEdicao_Load(object sender, EventArgs e)
        {

        }

        private void txtNomeProduto_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var conn = new SqlConnection(Database.ConnectionString))
            using (var cmd = new SqlCommand(
                "UPDATE Produtos SET nomePro=@n, descricaoPro=@d, precoCompra=@pCompra, precoVenda=@pVenda, quantidade_estoque=@q, " +
"id_categoria=@c, id_marca=@m WHERE id_produto=@id"
, conn))
            {
                cmd.Parameters.AddWithValue("@n", txtNomeProduto.Text);
                cmd.Parameters.AddWithValue("@d", txtDescricao.Text);
                cmd.Parameters.AddWithValue("@pCompra", decimal.Parse(txtPrecoCompra.Text));
                cmd.Parameters.AddWithValue("@pVenda", decimal.Parse(txtPrecoVenda.Text));
                cmd.Parameters.AddWithValue("@q", 0);


                var selectedValue = cboCategoria.SelectedValue;
                if (selectedValue == null)
                {
                    MessageBox.Show("Please select a valid category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                cmd.Parameters.AddWithValue("@c", int.Parse(cboCategoria.SelectedValue.ToString()));
                cmd.Parameters.AddWithValue("@m", int.Parse(cboMarca.SelectedValue.ToString()));
                

                cmd.Parameters.AddWithValue("@id", _idProduto);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Produto atualizado com sucesso", "Sucesso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
