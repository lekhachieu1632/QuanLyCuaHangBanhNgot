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
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
        }

        DataSet ds = null;
        SqlDataAdapter da = null;
        DataSet ds1 = null;
        SqlDataAdapter da1 = null;

        void getData()
        {
            string con = @"Data Source=DESKTOP-MOV62CV\MSSQLSERVER01;Initial Catalog=BanhNgot;Integrated Security=True";
            SqlConnection conn = new SqlConnection(con);
            string query = "select * from PhieuNhap";
            string query1 = "select * from PhieuXuat";
            da = new SqlDataAdapter(query, conn);
            ds = new DataSet();
            da1 = new SqlDataAdapter(query1, conn);
            ds1 = new DataSet();
            SqlCommandBuilder sd = new SqlCommandBuilder(da);
            SqlCommandBuilder sd1 = new SqlCommandBuilder(da1);
            da.Fill(ds, "PhieuNhap");
            da1.Fill(ds, "PhieuXuat");
            dataGridView1.DataSource = ds.Tables["PhieuNhap"];
            dataGridView2.DataSource = ds.Tables["PhieuXuat"];
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Tìm kiếm")
            {
                textBox1.ForeColor = Color.FromArgb(0, 0, 0);
                textBox1.Text = String.Empty;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Tìm kiếm")
            {
                textBox2.ForeColor = Color.FromArgb(0, 0, 0);
                textBox2.Text = String.Empty;
            }
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            getData();
            textBox1.ForeColor = Color.FromArgb(126, 126, 126);
            textBox1.Text = "Tìm kiếm";
            textBox2.ForeColor = Color.FromArgb(126, 126, 126);
            textBox2.Text = "Tìm kiếm";
        }

        private void btnTinKiemPN_Click(object sender, EventArgs e)
        {
            try
            {
                string con_str = @"Data Source=DESKTOP-MOV62CV\MSSQLSERVER01;Initial Catalog=BanhNgot;Integrated Security=True";
                SqlConnection conn = new SqlConnection(con_str);
                conn.Open();
                string query = "select * from PhieuNhap where MaPN='" + textBox1.Text + "'  ";
                da = new SqlDataAdapter(query, conn);
                ds = new DataSet();
                SqlCommandBuilder sd = new SqlCommandBuilder(da);
                da.Fill(ds, "PhieuNhap");
                dataGridView1.DataSource = ds.Tables["PhieuNhap"];
            }
            catch
            {
            }
        }

        private void btnTimKiemPX_Click(object sender, EventArgs e)
        {
            try
            {
                string con_str = @"Data Source=DESKTOP-MOV62CV\MSSQLSERVER01;Initial Catalog=BanhNgot;Integrated Security=True";
                SqlConnection conn = new SqlConnection(con_str);
                conn.Open();
                string query = "select * from PhieuXuat where MaPX='" + textBox2.Text + "'  ";
                da = new SqlDataAdapter(query, conn);
                ds = new DataSet();
                SqlCommandBuilder sd = new SqlCommandBuilder(da);
                da.Fill(ds, "PhieuXuat");
                dataGridView2.DataSource = ds.Tables["PhieuXuat"];
            }
            catch
            {
            }
        }

        private void btnCTPN_Click(object sender, EventArgs e)
        {
            PhieuNhap form = new PhieuNhap();
            form.Show();
        }

        private void btnCTPX_Click(object sender, EventArgs e)
        {
            PhieuXuat form = new PhieuXuat();
            form.Show();
        }
    }
}
