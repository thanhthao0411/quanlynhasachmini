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
    public partial class frmChangePersional : Form
    {
        public frmChangePersional()
        {
            InitializeComponent();
        }
        string chuoiketnoi = @"Data Source=DESKTOP-2VR92U8;Initial Catalog=QL-NhaSach;Integrated Security=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;

        public void  hienthi()
        {
            ketnoi.Open();
            sql = @"select masp, tensp, dongia, soluong from SANPHAM";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                 
            }
            ketnoi.Close();
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnXaxNhan_Click(object sender, EventArgs e)
        {

        }
    }
}
