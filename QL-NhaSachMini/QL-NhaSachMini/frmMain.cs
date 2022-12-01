using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QL_NhaSachMini
{
    public partial class frmMain : Form
    {
        private string username;
        private string password;
        frmLogin m;
        public frmMain()
        {
            InitializeComponent();

        }
        public frmMain(frmLogin m)
        {
            if (m.quyenk != "admin")
            {
                tmiAccount.Enabled = false;
            }

            InitializeComponent();
            
        }

      
        private void frmMain_Load(object sender, EventArgs e)
        {
            DialogResult ms = MessageBox.Show("Xin chào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public frmMain(string user, string ten, string pass, string type) : this()
        {
            

        }

        private void tmiAccount_Click(object sender, EventArgs e)
        {
            
        }

        private void tmiAccount_Click_1(object sender, EventArgs e)
        {
            frmTK f = new frmTK();
            f.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin f = new frmLogin();
            f.Show();
        }

        private void quảnLýSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSP f = new frmSP();
            f.Show();
        }

        private void thayĐổiThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void lậpHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHD f = new frmHD();
            f.Show();
        }
    }
}
