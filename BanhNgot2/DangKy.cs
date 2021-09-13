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
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
        }

        DataSet ds = null;
        SqlDataAdapter da = null;

        void getData()
        {
            string con = @"Data Source=DESKTOP-MOV62CV\MSSQLSERVER01;Initial Catalog=BanhNgot;Integrated Security=True";
            SqlConnection conn = new SqlConnection(con);
            string query = "select *from TaiKhoan";
            da = new SqlDataAdapter(query, conn);
            ds = new DataSet();
            SqlCommandBuilder sd = new SqlCommandBuilder(da);
            da.Fill(ds, "TaiKhoan");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string con_str = @"Data Source=DESKTOP-MOV62CV\MSSQLSERVER01;Initial Catalog=BanhNgot;Integrated Security=True";
                SqlConnection conn = new SqlConnection(con_str);
                conn.Open();
                string query = "insert into TaiKhoan(UserName,Password)values('" + textBox1.Text + "','" + textBox2.Text + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Them thanh cong");
                conn.Close();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Them that bai");
            }
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnZoom_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
