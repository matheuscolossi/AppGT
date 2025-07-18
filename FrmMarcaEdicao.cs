﻿using System;
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
    public partial class FrmMarcaEdicao : Form
    {
        private readonly int _idMarca;
        public FrmMarcaEdicao(int id)
        {
            InitializeComponent();
            _idMarca = id;
            CarregarDados();
        }
        private void CarregarDados()
        {
            using (var conn = new SqlConnection(Database.ConnectionString))
            using (var cmd = new SqlCommand("SELECT nomeMarcas FROM Marcas WHERE id_marcas = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", _idMarca);
                conn.Open();
                txtNomeMarca.Text = cmd.ExecuteScalar() as string;
            }
        }

        private void FrmMarcaEdicao_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var conn = new SqlConnection(Database.ConnectionString))
            using (var cmd = new SqlCommand("UPDATE Marcas SET nomeMarcas = @n WHERE id_marcas = @id", conn))
            {
                cmd.Parameters.AddWithValue("@n", txtNomeMarca.Text);
                cmd.Parameters.AddWithValue("@id", _idMarca);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Marca atualizada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
