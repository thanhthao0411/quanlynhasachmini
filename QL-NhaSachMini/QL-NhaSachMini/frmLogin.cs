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
    public partial class frmLogin : Form
    { 
        public frmLogin()
        {
            InitializeComponent();
        }
        string chuoiketnoi = @"Data Source=DESKTOP-2VR92U8;Initial Catalog=QL-NhaSach;Integrated Security=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        string quyen;
        public string quyenk
        {
            get { return quyen; }
            set { quyen = value; }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
 
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            sql = @"Select * from TAIKHOAN where username ='" + txtUsername.Text + "' and password ='" + txtPassword.Text + "'";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
           
            if (docdulieu.Read() == true) 
            {
                
                
                this.Hide();
                frmMain f = new frmMain();
                f.Show();
            }
            else
            {
                DialogResult ms = MessageBox.Show("Không đúng tài khoản và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtUsername.Focus();
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult ms = MessageBox.Show("Bạn có muốn thoát không? ", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ms == DialogResult.Yes)
            {
                this.Close();
            }
        }

       
    }
}
