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
    public partial class frmHD : Form
    {
        public frmHD()
        {
            InitializeComponent();
        }
        string chuoiketnoi = @"Data Source=DESKTOP-2VR92U8;Initial Catalog=QL-NhaSach;Integrated Security=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;
        void ComboBoxLoad()
        {
            ketnoi.Open();
            sql = @"Select * from TAIKHOAN";
            thuchien = new SqlCommand(sql, ketnoi);
            var dr = thuchien.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            cbbUser.DisplayMember = "username";
            cbbUser.DataSource = dt;
            ketnoi.Close();
            ketnoi.Open();
            sql= @"Select * from SANPHAM";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            var dt1 = new DataTable();
            dt1.Load(docdulieu);
            cbbMsp.DisplayMember = "masp";
            cbbMsp.DataSource = dt1;
            ketnoi.Close();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
       
        private void frmHD_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ComboBoxLoad();
            hienthi();
        }
        public void hienthi()
        {
            listView1.Items.Clear();
            ketnoi.Open();
            
            sql = @"select mahd, username, ngayban from HOADON";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                listView1.Items.Add(docdulieu[0].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[1].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[2].ToString());
                i++;
            }
            ketnoi.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.txtMahd.Clear();
            
            txtMahd.Focus();
        }
        private void listView1_Click(object sender, EventArgs e)
        {
            txtMahd.Text = listView1.SelectedItems[0].SubItems[0].Text;
            cbbUser.Text = listView1.SelectedItems[0].SubItems[1].Text;
            dtpNgaylap.Text = listView1.SelectedItems[0].SubItems[2].Text;
            hienthi2();
            hienthi();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = @"insert into HOADON(mahd, username, ngayban) 
            VALUES ('" + txtMahd.Text + @"', '" + cbbUser.Text + @"', '" + dtpNgaylap.Text + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hienthi();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult ms = MessageBox.Show("Bạn có muốn thoát không? ", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ms == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = @"DELETE FROM HOADON WHERE (mahd = '" + txtMahd.Text + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hienthi();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void hienthi2()
        {
            listView1.Items.Clear();
            ketnoi.Open();

            sql = @"select mahd, masp, soluong, dongia, thanhtien from CTHOADON where mahd = '"+txtMahd.Text+"'";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                listView2.Items.Add(docdulieu[0].ToString());
                listView2.Items[i].SubItems.Add(docdulieu[1].ToString());
                listView2.Items[i].SubItems.Add(docdulieu[2].ToString());
                listView2.Items[i].SubItems.Add(docdulieu[3].ToString());
                listView2.Items[i].SubItems.Add(docdulieu[4].ToString());
                i++;
            }
            ketnoi.Close();
        }
        private void listView2_Click(object sender, EventArgs e)
        {
            txtmahd1.Text = listView2.SelectedItems[0].SubItems[0].Text;
            cbbMsp.Text = listView2.SelectedItems[0].SubItems[1].Text;
            txtSoluong.Text = listView2.SelectedItems[0].SubItems[2].Text;
            txtDongia.Text = listView2.SelectedItems[0].SubItems[3].Text;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
                listView1.Items.Clear();
                ketnoi.Open();
                sql = @"insert into CTHOADON(mahd, masp, soluong, dongia) 
            VALUES ('" + txtMahd.Text + @"', '" + cbbMsp.Text + @"', '" + txtSoluong.Text + @"', '" + txtDongia.Text + @"')";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                ketnoi.Close();

                hienthi2();
                hienthi();
         
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lblThanhtien_Click(object sender, EventArgs e)
        {

        }

        private void txtDongia_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtmahd1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
