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
    public partial class FrmRelatorioFinanceiro : Form
    {
        public FrmRelatorioFinanceiro()
        {
            InitializeComponent();
        }

        private void FrmRelatorioFinanceiro_Load(object sender, EventArgs e)
        {
            decimal totalGasto = 0;
            decimal totalFaturado = 0;

            using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
            {
                conn.Open();

                // Total Gasto
                using (SqlCommand cmdGasto = new SqlCommand("SELECT ISNULL(SUM(Quantidade * PrecoUnitario), 0) FROM ItemCompra", conn))
                {
                    totalGasto = Convert.ToDecimal(cmdGasto.ExecuteScalar());
                }

                // Total Faturado
                using (SqlCommand cmdFaturado = new SqlCommand("SELECT ISNULL(SUM(Quantidade * PrecoVenda), 0) FROM ItemVenda", conn))
                {
                    totalFaturado = Convert.ToDecimal(cmdFaturado.ExecuteScalar());
                }

                conn.Close();
            }

            txtTotalGasto.Text = totalGasto.ToString("C2");
            txtTotalFaturado.Text = totalFaturado.ToString("C2");
            txtLucroBruto.Text = (totalFaturado - totalGasto).ToString("C2");
        }
    }
    }

