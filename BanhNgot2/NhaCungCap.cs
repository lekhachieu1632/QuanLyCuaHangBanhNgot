﻿using System;
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
    public partial class NhaCungCap : Form
    {
        public NhaCungCap()
        {
            InitializeComponent();
        }

        DataSet ds = null;
        SqlDataAdapter da = null;

        void getData()
        {
            string con = @"Data Source=DESKTOP-MOV62CV\MSSQLSERVER01;Initial Catalog=BanhNgot;Integrated Security=True";
            SqlConnection conn = new SqlConnection(con);
            string query = "select *from NhaCungCap";
            da = new SqlDataAdapter(query, conn);
            ds = new DataSet();
            SqlCommandBuilder sd = new SqlCommandBuilder(da);
            da.Fill(ds, "NhaCungCap");
            dataGridView1.DataSource = ds.Tables["NhaCungCap"];
        }

        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {
                textBox1.Text = dataGridView1.Rows[i].Cells["MaNCC"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[i].Cells["TenNCC"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[i].Cells["SoDienThoai"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[i].Cells["DiaChi"].Value.ToString();
                textBox5.Text = dataGridView1.Rows[i].Cells["Email"].Value.ToString();
            }
            textBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string con_str = @"Data Source=DESKTOP-MOV62CV\MSSQLSERVER01;Initial Catalog=BanhNgot;Integrated Security=True";
                SqlConnection conn = new SqlConnection(con_str);
                conn.Open();
                string query = "insert into NhaCungCap(MaNCC,TennCC,SoDienThoai,DiaChi,Email)values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                getData();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox1.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Them that bai");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string con_str = @"Data Source=DESKTOP-MOV62CV\MSSQLSERVER01;Initial Catalog=BanhNgot;Integrated Security=True";
                SqlConnection conn = new SqlConnection(con_str);
                conn.Open();
                string query = "update NhaCungCap set TenNCC='" + textBox2.Text + "',SoDienThoai='" + textBox3.Text + "',DiaChi='" + textBox4.Text + "',Email='" + textBox5.Text + "'where MaNCC='" + textBox1.Text + "'";
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
                textBox1.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Sua that bai");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string con_str = @"Data Source=DESKTOP-MOV62CV\MSSQLSERVER01;Initial Catalog=BanhNgot;Integrated Security=True";
            SqlConnection conn = new SqlConnection(con_str);
            conn.Open();
            string query = "delete from NhaCngCap where MaNCC='" + textBox1.Text + "'";
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
            textBox1.Enabled = true;
        }



        private void guna2Button1_Click(object sender, EventArgs e)
        {
            getData();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox1.Enabled = true;
            textBox6.ForeColor = Color.FromArgb(126, 126, 126);
            textBox6.Text = "Tìm kiếm";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string con_str = @"Data Source=DESKTOP-MOV62CV\MSSQLSERVER01;Initial Catalog=BanhNgot;Integrated Security=True";
                SqlConnection conn = new SqlConnection(con_str);
                conn.Open();
                string query = "Select *from NhaCungCap where MaNCC='" + textBox6.Text + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                da = new SqlDataAdapter(query, conn);
                ds = new DataSet();
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Fill(ds, "NhaCungCap");
                dataGridView1.DataSource = ds.Tables["NhaCungCap"];
            }
            catch
            {
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text == "Tìm kiếm")
            {
                textBox6.ForeColor = Color.FromArgb(0, 0, 0);
                textBox6.Text = String.Empty;
            }
        }
    }
}
