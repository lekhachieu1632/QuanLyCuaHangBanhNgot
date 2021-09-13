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

namespace BanhNgot2
{
    public partial class DangNhap1 : Form
    {
        public DangNhap1()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string con_str = @"Data Source=DESKTOP-MOV62CV\MSSQLSERVER01;Initial Catalog=BanhNgot;Integrated Security=True";
            SqlConnection conn = new SqlConnection(con_str);
            conn.Open();
            string Query = " select count(*) from TaiKhoan where UserName ='" + textBox1.Text + "' and Password ='" + textBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(Query, conn);
            int soluong = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            if (soluong == 1)
            {
                //MessageBox.Show("Đăng Nhập Thành Công");
                QuanLy ql = new QuanLy();
                ql.ShowDialog();
            }
            else
            {
                MessageBox.Show("False");
                this.Close();
            }
            conn.Close();
            this.Close();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "UserName")
            {
                textBox1.ForeColor = Color.FromArgb(0, 0, 0);
                textBox1.Text = String.Empty;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                textBox1.ForeColor = Color.FromArgb(126, 126, 126);
                textBox1.Text = "UserName";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.ForeColor = Color.FromArgb(0, 0, 0);
                textBox2.Text = String.Empty;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == String.Empty)
            {
                textBox2.ForeColor = Color.FromArgb(126, 126, 126);
                textBox2.Text = "Password";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DangKy form = new DangKy();
            form.Show();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnZoom_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
