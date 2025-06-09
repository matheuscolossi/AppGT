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

namespace ProjetoIntegradorLojaGearTrack
{
    public partial class FrmClienteEdicao : Form
    {
        private int idCliente;
        public FrmClienteEdicao(int id)
        {
            InitializeComponent();
            idCliente = id;
            CarregarDados();
        }
        private void CarregarDados()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GearTrackConnection"].ConnectionString))
            using (var cmd = new SqlCommand("SELECT nomeCliente,cpfCliente,telefoneCliente,emailCliente,enderecoCliente FROM Clientes WHERE id_cliente = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", idCliente);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                    if (dr.Read())
                    {
                        txtNomeCliente.Text = dr["nomeCliente"].ToString();
                        mskCpfCliente.Text = dr["cpfCliente"].ToString();
                        mskTelefoneCliente.Text = dr["telefoneCliente"].ToString();
                        txtEmailCliente.Text = dr["emailCliente"].ToString();
                        txtEnderecoCliente.Text = dr["enderecoCliente"].ToString();
                    }
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtNomeCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GearTrackConnection"].ConnectionString))
                using (var cmd = new SqlCommand("UPDATE Clientes SET nomeCliente = @n, cpfCliente = @c, telefoneCliente = @t, emailCliente = @e, enderecoCliente = @d WHERE id_cliente = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@n", txtNomeCliente.Text);
                    cmd.Parameters.AddWithValue("@c", mskCpfCliente.Text);
                    cmd.Parameters.AddWithValue("@t", mskTelefoneCliente.Text);
                    cmd.Parameters.AddWithValue("@e", txtEmailCliente.Text);
                    cmd.Parameters.AddWithValue("@d", txtEnderecoCliente.Text);
                    cmd.Parameters.AddWithValue("@id", idCliente);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Cliente atualizado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar cliente: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmClienteEdicao_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
