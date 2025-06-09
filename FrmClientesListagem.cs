using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoIntegradorLojaGearTrack;
using System.Data.SqlClient;




namespace ProjetoIntegradorLojaGearTrack
{
    
    public partial class FrmClientesListagem : Form
    {
        private readonly string cs = Database.ConnectionString;
        public FrmClientesListagem()
        {
            InitializeComponent();
            Load += FrmClientesListagem_Load;
        }

        private void FrmClientesListagem_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }
        private void CarregarGrid()
        {
            using (var conn = new SqlConnection(cs))
            using (var cmd = new SqlCommand(
                "SELECT id_cliente, nomeCliente, cpfCliente, telefoneCliente, emailCliente, enderecoCliente FROM Clientes",
                conn))
            {
                conn.Open();
                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dgvClientes.DataSource = dt;
            }
            dgvClientes.Columns["id_cliente"].HeaderText = "ID Cliente";
            dgvClientes.Columns["nomeCliente"].HeaderText = "Nome";
            dgvClientes.Columns["cpfCliente"].HeaderText = "CPF";
            dgvClientes.Columns["telefoneCliente"].HeaderText = "Telefone";
            dgvClientes.Columns["emailCliente"].HeaderText = "E-mail";
            dgvClientes.Columns["enderecoCliente"].HeaderText = "Endereço";
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             if (dgvClientes.CurrentRow == null) return;
             int id = (int)dgvClientes.CurrentRow.Cells["id_cliente"].Value;
             var frm = new FrmClienteEdicao(id);
             if (frm.ShowDialog() == DialogResult.OK)
             CarregarGrid();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null) return;
            int id = (int)dgvClientes.CurrentRow.Cells["id_cliente"].Value;
            if (MessageBox.Show(
                    "Confirmar exclusão?", "Confirmação",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                using (var conn = new SqlConnection(cs))
                using (var cmd = new SqlCommand(
                    "DELETE FROM Clientes WHERE id_cliente = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                CarregarGrid();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void panelBotoes_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
    }

