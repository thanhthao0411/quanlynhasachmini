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
    public partial class frmSP : Form
    {
        public frmSP()
        {
            InitializeComponent();
        }
        string chuoiketnoi = @"Data Source=DESKTOP-2VR92U8;Initial Catalog=QL-NhaSach;Integrated Security=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;

        private void frmSP_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            hienthi();
        }
        public void hienthi()
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = @"select masp, tensp, dongia, soluong from SANPHAM";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                listView1.Items.Add(docdulieu[0].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[1].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[2].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[3].ToString());
                i++;
            }
            ketnoi.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_Click(object sender, EventArgs e)
        {
            txtMasp.Text = listView1.SelectedItems[0].SubItems[0].Text;
            txtTensp.Text = listView1.SelectedItems[0].SubItems[1].Text;
            txtDongia.Text = listView1.SelectedItems[0].SubItems[2].Text;
            txtSoluong.Text = listView1.SelectedItems[0].SubItems[3].Text;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMasp.TextLength == 0 || txtTensp.TextLength == 0 || txtSoluong.TextLength == 0 || txtDongia.TextLength == 0)
            {
                DialogResult m = MessageBox.Show(" Chưa điền đầy đủ thông tin! ", " Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                listView1.Items.Clear();
                ketnoi.Open();
                sql = @"insert into SANPHAM(masp, tensp, dongia, soluong) 
            VALUES ('" + txtMasp.Text + @"', N'" + txtTensp.Text + @"', '" + txtDongia.Text + @"', '" + txtSoluong.Text + @"')";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                ketnoi.Close();
                hienthi();
                DialogResult ms = MessageBox.Show(" Thêm thành công! ", " Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = @"UPDATE SANPHAM set
                    masp = '" + txtMasp.Text + @"',
                    tensp = N'" + txtTensp.Text + @"',
                    dongia = '" + txtDongia.Text + @"',
                    soluong = '" + txtSoluong.Text + @"' WHERE (masp = '" + txtMasp.Text + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hienthi();
            DialogResult ms = MessageBox.Show(" Sửa thành công! ", " Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = @"DELETE FROM SANPHAM WHERE (masp = '" + txtMasp.Text + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hienthi();
            DialogResult ms = MessageBox.Show(" Xóa thành công! ", " Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult ms = MessageBox.Show("Bạn có muốn thoát không? ", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ms == DialogResult.Yes)
            {
                this.Close();

            }
        }
    }
}
