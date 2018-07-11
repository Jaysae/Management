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
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = Application.StartupPath + "//Longhorn.ssk";
        }

        private void button1_Click(object sender, EventArgs e)
        {      
            try
            {
                if (this.textBox1.Text.Trim() == "")
                {
                    MessageBox.Show("员工id不能为空");
                }
                else if (this.textBox5.Text.Trim() == "")
                {
                    MessageBox.Show("员工姓名不能为空");

                }
                else { 
                String sql = "insert into Data(id,name,sex,phone,dizhi,datatime)  values('" + this.textBox1.Text.Trim() + "','" + this.textBox5.Text.Trim() + "','" + (this.radioButton1.Checked ? "男" : "女") + "','" + this.textBox4.Text.Trim() + "','" + this.textBox6.Text.Trim() + "','" + this.dateTimePicker1.Text.Trim() + "' )";
                MySqlDataReader dr = Database.Dr(sql);
                if (dr.Read())
                {        
                  MessageBox.Show("请换个姿势");  
                }
                else
                {
                    MessageBox.Show("插入成功");
                    this.textBox1.Text = "";
                    this.textBox4.Text = "";
                    this.textBox5.Text = "";
                    this.textBox6.Text = "";
                }
                }
            }
            catch
            {
                MessageBox.Show("连接数据库的姿势不对");
                Database.Close();
            }
            Database.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           this.textBox1.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";

        }

        private void Add_Load(object sender, EventArgs e)
        {
         
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "")
            {
                label7.Text = "id不能为空";
                label7.ForeColor = Color.Red;
            }
            else
            { 
            try
            {

                String sql = "select *from users where id = '" + this.textBox1.Text.Trim() + "'";
                MySqlDataReader dr = Database.Dr(sql);
                if (dr.Read())
                {
                    if (dr["id"].ToString() == this.textBox1.Text.ToString())
                    {
                        label7.Text = "id已存在";
                        label7.ForeColor = Color.Red;
                    }
                }
                else
                {
                    label7.Text = "✓";
                    label7.ForeColor = Color.Green;
                }
            }
            catch
            {
                MessageBox.Show("连接数据库的姿势不对");
                Database.Close();
            }
            }
            Database.Close();
        }

        private void textBox5_MouseLeave(object sender, EventArgs e)
        {

            if (this.textBox5.Text == "")
            {
                label8.Text = "用户名不能为空";
                label8.ForeColor = Color.Red;
            }
            else
            {
                try
                {

                    String sql = "select *from data where name = '" + this.textBox5.Text.Trim() + "'";
                    MySqlDataReader dr = Database.Dr(sql);
                    if (dr.Read())
                    {
                        if (dr["name"].ToString() == this.textBox5.Text.ToString())
                        {
                            label8.Text = "用户名已存在";
                            label8.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        label8.Text = "✓";
                        label8.ForeColor = Color.Green;
                    }
                }
                catch
                {
                    MessageBox.Show("连接数据库的姿势不对");
                    Database.Close();
                }
            }
            Database.Close();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
