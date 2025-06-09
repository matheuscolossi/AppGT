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
    public partial class FrmProdutoCadastro : Form
    {
        public FrmProdutoCadastro()
        {
            InitializeComponent();
        }

        private void FrmProdutoCadastro_Load(object sender, EventArgs e)
        {
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
                cboCategoria.SelectedIndex = -1; // nenhuma seleção inicial
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
        private void txtNomeCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cboCategoria.SelectedValue == null || cboMarca.SelectedValue == null)
            {
                MessageBox.Show("Selecione uma categoria e uma marca.",
                                "Atenção",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            using (var conn = new SqlConnection(Database.ConnectionString))
            using (var cmd = new SqlCommand(
                "INSERT INTO Produtos (nomePro, descricaoPro, precoPro, quantidade_estoque, id_categoria, id_marca) " +
                "VALUES (@n,@d,@p,@q,@c,@m)", conn))
            {
                cmd.Parameters.AddWithValue("@n", txtNomeProduto.Text);
                cmd.Parameters.AddWithValue("@d", txtDescricao.Text);
                cmd.Parameters.AddWithValue("@p", decimal.Parse(txtPreco.Text));
                cmd.Parameters.AddWithValue("@q", int.Parse(txtQuantidade.Text));
                cmd.Parameters.AddWithValue("@c", (int)cboCategoria.SelectedValue);
                cmd.Parameters.AddWithValue("@m", (int)cboMarca.SelectedValue);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Produto cadastrado com sucesso",
                            "Sucesso",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }

