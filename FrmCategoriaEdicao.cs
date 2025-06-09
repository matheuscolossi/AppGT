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
    public partial class FrmCategoriaEdicao : Form
    {
        private readonly int _idCategoria;
        public FrmCategoriaEdicao(int id)
        {
            InitializeComponent();
            _idCategoria = id;
            CarregarDados();
        }
        private void CarregarDados()
        {
            using (var conn = new SqlConnection(Database.ConnectionString))
            using (var cmd = new SqlCommand(
                "SELECT nomeCategoria, descricaoCategoria FROM Categorias WHERE id_categoria = @id",
                conn))
            {
                cmd.Parameters.AddWithValue("@id", _idCategoria);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                    if (dr.Read())
                    {
                        txtNomeCategoria.Text = dr.GetString(0);
                        txtDescricaoCategoria.Text = dr.GetString(1);
                    }
            }
        }


        private void FrmCategoriaEdicao_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var conn = new SqlConnection(Database.ConnectionString))
            using (var cmd = new SqlCommand(
                "UPDATE Categorias " +
                "SET nomeCategoria = @n, descricaoCategoria = @d " +
                "WHERE id_categoria = @id", conn))
            {
                cmd.Parameters.AddWithValue("@n", txtNomeCategoria.Text);
                cmd.Parameters.AddWithValue("@d", txtDescricaoCategoria.Text);
                cmd.Parameters.AddWithValue("@id", _idCategoria);  // campo que guarda o id
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Categoria atualizada com sucesso", "Sucesso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
