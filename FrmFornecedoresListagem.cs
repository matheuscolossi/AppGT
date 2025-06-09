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
    public partial class FrmFornecedoresListagem : Form
    {
        private readonly string cs = Database.ConnectionString;

        public FrmFornecedoresListagem()
        {
            InitializeComponent();
            Load += (s, e) => CarregarGrid();
            btnAtualizar.Click += (s, e) => CarregarGrid();
           

        }
        public void CarregarGrid()
        {
            using (var conn = new SqlConnection(Database.ConnectionString))
            using (var cmd = new SqlCommand(
                "SELECT id_fornecedor,nomeFornecedor,cnpjFornecedor,telefoneFornecedor,emailFornecedor,enderecoFornecedor FROM Fornecedores",
                conn))
            {
                conn.Open();
                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dgvFornecedores.DataSource = dt;
            }
            dgvFornecedores.Columns["id_fornecedor"].HeaderText = "ID";
            dgvFornecedores.Columns["nomeFornecedor"].HeaderText = "Nome";
            dgvFornecedores.Columns["cnpjFornecedor"].HeaderText = "CNPJ";
            dgvFornecedores.Columns["telefoneFornecedor"].HeaderText = "Telefone";
            dgvFornecedores.Columns["emailFornecedor"].HeaderText = "E-mail";
            dgvFornecedores.Columns["enderecoFornecedor"].HeaderText = "Endereço";
        }
        private void FrmFornecedoresListagem_Load(object sender, EventArgs e)
        {

        }

        private void panelBotoes_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvFornecedores.CurrentRow == null) return;
            int id = (int)dgvFornecedores.CurrentRow.Cells["id_fornecedor"].Value;
            if (MessageBox.Show(
                "Confirmar exclusão?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                ) == DialogResult.Yes)
            {
                using (var conn = new SqlConnection(cs))
                using (var cmd = new SqlCommand("DELETE FROM Fornecedores WHERE id_fornecedor = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                CarregarGrid();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvFornecedores.CurrentRow == null) return;
            int id = (int)dgvFornecedores.CurrentRow.Cells["id_fornecedor"].Value;
            using (var frm = new FrmFornecedorEdicao(id))
                if (frm.ShowDialog() == DialogResult.OK)
                    CarregarGrid();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {

        }
    }
}
