using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;


namespace ProjetoIntegradorLojaGearTrack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        public bool emptyFields()
        {
            if (login_username.Text == "" || login_password.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager
                .ConnectionStrings["GearTrackConnection"]
                .ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                string query = @"
            SELECT COUNT(*) 
            FROM Users 
            WHERE Username = @username 
              AND Password = @password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", login_username.Text);
                    cmd.Parameters.AddWithValue("@password", login_password.Text);
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        // esconde o login
                        this.Hide();
                        // abre o MainForm de forma modal
                        var main = new MainForm();
                        main.ShowDialog();
                        // fecha o Form1 (login)
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Usuário ou senha inválidos");
                    }
                }
            }
            }
        

        private void login_registerBtn_Click(object sender, EventArgs e)
        {
            RehsiterForm regForm = new RehsiterForm();
            regForm.Show();

            this.Hide();
        }

        private void login_showPass_CheckedChanged(object sender, EventArgs e)
        {
            login_password.PasswordChar = login_showPass.Checked ? '\0' : '*';
        }

        private void pbMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        
    }

        private void pbMaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void pbFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
