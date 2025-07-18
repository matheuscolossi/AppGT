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
                @"INSERT INTO Produtos (nomePro, descricaoPro, precoCompra, precoVenda, quantidade_estoque, id_categoria, id_marca)
                     VALUES (@nome, @desc, @precoCompra, @precoVenda, @quantidade_estoque, @idCat, @idMarca)", conn))
            {
                cmd.Parameters.AddWithValue("@nome", txtNomeProduto.Text);
                cmd.Parameters.AddWithValue("@desc", txtDescricao.Text);
                cmd.Parameters.AddWithValue("@precoCompra", Convert.ToDecimal(txtPrecoCompra.Text));
                cmd.Parameters.AddWithValue("@precoVenda", Convert.ToDecimal(txtPrecoVenda.Text));
                cmd.Parameters.AddWithValue("@quantidade_estoque", 0);
                cmd.Parameters.AddWithValue("@idCat", (int)cboCategoria.SelectedValue);
                cmd.Parameters.AddWithValue("@idMarca", (int)cboMarca.SelectedValue);

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

        private void cboMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtPrecoVenda_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

