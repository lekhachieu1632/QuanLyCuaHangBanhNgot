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
    public partial class PhieuXuat : Form
    {
        public PhieuXuat()
        {
            InitializeComponent();
        }

        SqlDataAdapter da = null;
        DataSet ds = null;

        void getData()
        {
            string con = @"Data Source=DESKTOP-MOV62CV\MSSQLSERVER01;Initial Catalog=BanhNgot;Integrated Security=True";
            SqlConnection conn = new SqlConnection(con);
            string query = "select *from PhieuXuat";
            da = new SqlDataAdapter(query, conn);
            ds = new DataSet();
            SqlCommandBuilder sd = new SqlCommandBuilder(da);
            da.Fill(ds, "PhieuXuat");
            dataGridView1.DataSource = ds.Tables["PhieuXuat"];
        }

        private void PhieuXuat_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {
                textBox1.Text = dataGridView1.Rows[i].Cells["MaPX"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[i].Cells["MaNCC"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[i].Cells["MaNV"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[i].Cells["MaKH"].Value.ToString();
                textBox5.Text = dataGridView1.Rows[i].Cells["MaBanhNgot"].Value.ToString();
                textBox6.Text = dataGridView1.Rows[i].Cells["GiaBan"].Value.ToString();
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
                string query = "insert into PhieuXuat(MaPX,MaNCC,MaNV,MaKH,MaBanhNgot,GiaBan,NgayNhap,SoLuong)values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + dateTimePicker1.Value + "','" + numericUpDown1.Value + "')";
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
                textBox6.Text = "";
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
                string query = "update PhieuXuat set MaNCC='" + textBox2.Text + "',MaNv='" + textBox3.Text + "',MaKH='" + textBox4.Text + "',MaBanhNgot='" + textBox5.Text + "',GiaBan='" + textBox6.Text + "', SoLuong='" + numericUpDown1.Value + "',NgayXuat='" + dateTimePicker1.Value + "'where MaPX='" + textBox1.Text + "'";
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
                textBox6.Text = "";
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
            string query = "delete from PhieuXuat where MaPX='" + textBox1.Text + "'";
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
            textBox6.Text = "";
            numericUpDown1.Value = 0;
            textBox1.Enabled = true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            getData();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            numericUpDown1.Value = 0;
            textBox1.Enabled = true;
        }
    }
}
