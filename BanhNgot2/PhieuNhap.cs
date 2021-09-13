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
    public partial class PhieuNhap : Form
    {
        public PhieuNhap()
        {
            InitializeComponent();
        }

        SqlDataAdapter da = null;
        DataSet ds = null;

        void getData()
        {
            string con = @"Data Source=DESKTOP-MOV62CV\MSSQLSERVER01;Initial Catalog=BanhNgot;Integrated Security=True";
            SqlConnection conn = new SqlConnection(con);
            string query = "select *from PhieuNhap";
            da = new SqlDataAdapter(query, conn);
            ds = new DataSet();
            SqlCommandBuilder sd = new SqlCommandBuilder(da);
            da.Fill(ds, "PhieuNhap");
            dataGridView1.DataSource = ds.Tables["PhieuNhap"];
        }

        private void PhieuNhap_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {
                textBox1.Text = dataGridView1.Rows[i].Cells["MaPN"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[i].Cells["MaNCC"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[i].Cells["MaNV"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[i].Cells["MaBanhNgot"].Value.ToString();
                textBox5.Text = dataGridView1.Rows[i].Cells["GiaNhap"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[i].Cells["NgayNhap"].Value.ToString());
                numericUpDown1.Value = Convert.ToInt32(dataGridView1.Rows[i].Cells["SoLuong"].Value.ToString());
            }
            textBox1.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string con_str = @"Data Source=DESKTOP-MOV62CV\MSSQLSERVER01;Initial Catalog=BanhNgot;Integrated Security=True";
                SqlConnection conn = new SqlConnection(con_str);
                conn.Open();
                string query = "insert into PhieuNhap(MaPN,MaNCC,MaNV,MaBanhNgot,GiaNhap,NgayNhap,SoLuong)values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + dateTimePicker1.Value + "',N'" + numericUpDown1.Value + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Them thanh cong");
                conn.Close();
                getData();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                numericUpDown1.Value = 0;
                textBox1.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Them that bai");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string con_str = @"Data Source=DESKTOP-MOV62CV\MSSQLSERVER01;Initial Catalog=BanhNgot;Integrated Security=True";
                SqlConnection conn = new SqlConnection(con_str);
                conn.Open();
                string query = "update PhieuNhap set MaNCC='" + textBox2.Text + "',MaNv='" + textBox3.Text + "',MaBanhNgot='" + textBox4.Text + "',GiaNhap='" + textBox5.Text + "', SoLuong='" + numericUpDown1.Value + "',NgayNhap='" + dateTimePicker1.Value + "'where MaPN='" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sua thanh cong");
                conn.Close();
                getData();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                numericUpDown1.Value = 0;
                textBox1.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Sua that bai");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string con_str = @"Data Source=DESKTOP-MOV62CV\MSSQLSERVER01;Initial Catalog=BanhNgot;Integrated Security=True";
            SqlConnection conn = new SqlConnection(con_str);
            conn.Open();
            string query = "delete from PhieuNhap where MaPN='" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Xoa thanh cong");
            conn.Close();
            getData();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            numericUpDown1.Value = 0;
            textBox1.Enabled = true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            numericUpDown1.Value = 0;
            textBox1.Enabled = true;
        }
    }
}
