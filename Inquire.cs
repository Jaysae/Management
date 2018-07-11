using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace main
{
    public partial class Inquire : Form
    {
        public Inquire()
        {
            InitializeComponent();
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            string query;
            query = "select * from data where id like '%" + this.textBox1.Text.Trim() + "%' OR  name like '%" + this.textBox1.Text.Trim() + "%' OR sex like '%" + this.textBox1.Text.Trim() + "%' OR phone like '%" + this.textBox1.Text.Trim() + "%' OR dizhi like '%" + this.textBox1.Text.Trim() + "%' OR datatime like '%" + this.textBox1.Text.Trim() + "%'";

           
            MySqlDataAdapter adapter = Database.Adapter(query);

            DataTable P_dt = new DataTable(); //数据表
            adapter.Fill(P_dt);       //将查询到数据填充到数据表

            this.dataGridView1.DataSource = P_dt; //绑定DataGridView

            Database.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

           

           
        }

        private void chaxun_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //string query;
            //Database conn = new Database(); //连接数据库
            //query = "select * from data where id like '%" + this.textBox1.Text.Trim() + "%' OR  name like '%" + this.textBox1.Text.Trim() + "%' OR sex like '%" + this.textBox1.Text.Trim() + "%' OR phone like '%" + this.textBox1.Text.Trim() + "%' OR dizhi like '%" + this.textBox1.Text.Trim() + "%' OR datatime like '%" + this.textBox1.Text.Trim() + "%'";

            //conn.conn.Open();
            //MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn.conn);  //数据适配器  

            //DataTable P_dt = new DataTable(); //数据表
            //adapter.Fill(P_dt);       //将查询到数据填充到数据表

            //this.dataGridView1.DataSource = P_dt; //绑定DataGridView

            //conn.conn.Close();
            string query;
            query = "select * from data where id like '%" + this.textBox1.Text.Trim() + "%' OR  name like '%" + this.textBox1.Text.Trim() + "%' OR sex like '%" + this.textBox1.Text.Trim() + "%' OR phone like '%" + this.textBox1.Text.Trim() + "%' OR dizhi like '%" + this.textBox1.Text.Trim() + "%' OR datatime like '%" + this.textBox1.Text.Trim() + "%'";

           
            MySqlDataAdapter adapter = Database.Adapter(query);

            DataTable P_dt = new DataTable(); //数据表
            adapter.Fill(P_dt);       //将查询到数据填充到数据表

            this.dataGridView1.DataSource = P_dt; //绑定DataGridView

            Database.Close();
        }
    }
}
