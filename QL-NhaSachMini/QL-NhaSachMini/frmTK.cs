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
    public partial class frmTK : Form
    {
        public frmTK()
        {
            InitializeComponent();
        }
        string chuoiketnoi = @"Data Source=DESKTOP-2VR92U8;Initial Catalog=QL-NhaSach;Integrated Security=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void frmTK_Load_1(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            hienthi();
        }
        public void hienthi()
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = @"select username, ten, password, loaitk from TAIKHOAN";
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
        private void listView1_Click(object sender, EventArgs e)
        {
            txtUser.Text = listView1.SelectedItems[0].SubItems[0].Text;
            txtTen.Text = listView1.SelectedItems[0].SubItems[1].Text;
            txtPass.Text = listView1.SelectedItems[0].SubItems[2].Text;
            cbbLoaitk.Text = listView1.SelectedItems[0].SubItems[3].Text;
        }
        
        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            DialogResult ms = MessageBox.Show("Bạn có muốn thoát không? ", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ms == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            if (txtUser.TextLength == 0 || txtPass.TextLength == 0 || txtTen.TextLength == 0)
            {
                DialogResult m = MessageBox.Show(" Chưa điền đầy đủ thông tin! ", " Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                listView1.Items.Clear();
                ketnoi.Open();
                sql = @"insert into TAIKHOAN(username, ten, password, loaitk) 
            VALUES ('" + txtUser.Text + @"', N'" + txtTen.Text + @"', '" + txtPass.Text + @"', '" + cbbLoaitk.Text + @"')";
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
            sql = @"UPDATE TAIKHOAN set
                    username = '" + txtUser.Text + @"',
                    ten = N'" + txtTen.Text + @"',
                    password = '" + txtPass.Text + @"',
                    loaitk = '" + cbbLoaitk.Text + @"' WHERE (username = '" + txtUser.Text + @"')";
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
            sql = @"DELETE FROM TAIKHOAN WHERE (username = '" + txtUser.Text + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hienthi();
            DialogResult ms = MessageBox.Show(" Xóa thành công! ", " Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
