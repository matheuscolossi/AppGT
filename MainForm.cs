using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProjetoIntegradorLojaGearTrack
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked_2(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked_3(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked_4(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void fORNCToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked_5(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void cADASTRARCLEINTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            var frmCad = new FrmClienteCadastro
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panel3.Controls.Add(frmCad);
            frmCad.Show();
        }

        private void cADASTRARMARCASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            var frm = new FrmMarcaCadastro
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panel3.Controls.Add(frm);
            frm.Show();
        }

        private void cLIENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eDITARCLIENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1) Obtenha o ID do cliente selecionado
            int id = ObterClienteSelecionado();

            // 2) Passe esse ID para o construtor
            var frm = new FrmClienteEdicao(id);
            frm.ShowDialog();

            // 3) (Opcional) Recarregue a lista após fechar
            // Se você estiver usando o panel3, chame CarregarGrid() no form de listagem
        }
        private int ObterClienteSelecionado()
        {
            // localiza o form de listagem que está no panel3
            var frmList = panel3.Controls
                                .OfType<FrmClientesListagem>()
                                .FirstOrDefault();
            if (frmList == null)
                throw new InvalidOperationException("Abra a lista de clientes primeiro.");

            // pega o DataGridView
            var dgv = frmList.Controls
                             .OfType<DataGridView>()
                             .FirstOrDefault();
            if (dgv?.CurrentRow == null)
                throw new InvalidOperationException("Selecione uma linha primeiro.");

            return Convert.ToInt32(dgv.CurrentRow.Cells["id_cliente"].Value);
        }
        private void eXCLUIRCLIENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmClienteExclusao();
            frm.ShowDialog();
        }

        private void lISTARCLIENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            var frm = new FrmClientesListagem
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panel3.Controls.Add(frm);
            frm.Show();
        }

        private void cADASTRARCATEGORIASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            var frmCad = new FrmCategoriaCadastro
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panel3.Controls.Add(frmCad);
            frmCad.Show();
        }

        private void eDITARCATEGORIASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void eXCLUIRCATEGORIASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmCategoriaExclusao();
            frm.ShowDialog();
        }

        private void lISTARCATEGORIASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            var frmList = new FrmCategoriasListagem
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panel3.Controls.Add(frmList);
            frmList.Show();
        }

       // PRODUTOS // 
        private void eXCLUIRPRODUTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmProdutoExclusao();
            frm.ShowDialog();
        }
        
        private void eDITARPRODUTOSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void lISTARPRODUTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            var frm = new FrmProdutosListagem
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panel3.Controls.Add(frm);
            frm.Show();
        }

        private void cADASTRARPRODUTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            var frm = new FrmProdutoCadastro
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panel3.Controls.Add(frm);
            frm.Show();
        }

        private void mARCASToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eDITARMARCASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void eXCLUIRMARCASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmMarcaExclusao();
            frm.ShowDialog();
        }

        private void lISTARMARCASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            var frmList = new FrmMarcasListagem
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panel3.Controls.Add(frmList);
            frmList.Show();
        }

        private void cADASTRARFORNECEDORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            var frmCad = new FrmFornecedorCadastro
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panel3.Controls.Add(frmCad);
            frmCad.Show();
        }
        

        private void eDITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void eXCLUIRFORNECEDORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmFornecedorExclusao();
            frm.ShowDialog();
        }

        private void lISTARFORNECEDORESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            var frmList = new FrmFornecedoresListagem
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panel3.Controls.Add(frmList);
            frmList.Show();

        }

        private void rEGISTRARCOMPRAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            var frmCad = new FrmCompraRegistro
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panel3.Controls.Add(frmCad);
            frmCad.Show();
        }

        private void hISTÓRICODECOMPRASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            var frmCad = new FrmComprasHistorico
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panel3.Controls.Add(frmCad);
            frmCad.Show();
        }

        private void rEGISTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            var frmCad = new FrmVendaRegistro
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panel3.Controls.Add(frmCad);
            frmCad.Show();
        }

        private void hISTÓRICODEVENDASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            var frmCad = new FrmVendasHistorico
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panel3.Controls.Add(frmCad);
            frmCad.Show();
        }

        private void vENDASPORPERÍODOToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void eSTOQUEATUALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            var frmCad = new FrmRelatorioEstoqueAtual
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panel3.Controls.Add(frmCad);
            frmCad.Show();
        }

        private void fINANCEIROToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmRelatorioFinanceiro();
            frm.ShowDialog();
        }

        private void cADASTRARUSUÁRIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmUsuarioCadastro();
            frm.ShowDialog();
        }

        private void gERENCIARPERMISSÕESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmUsuarioPermissoes();
            frm.ShowDialog();
        }

        private void fINANCEIROToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            var frmCad = new FrmRelatorioFinanceiro
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panel3.Controls.Add(frmCad);
            frmCad.Show();
        }

        private void cADASTRARUSUÁRIOToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var frm = new FrmUsuarioCadastro();
            frm.ShowDialog();
        }

        private void gERENCIARPERMISSÕESToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var frm = new FrmUsuarioPermissoes();
            frm.ShowDialog();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cATEGORIASToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rELATÓRIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
