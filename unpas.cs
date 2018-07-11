using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace main
{
    public partial class unpas : Form
    {
        public unpas()
        {
            InitializeComponent();
        }

        private String th = "";

        private void button1_Click(object sender, EventArgs e)
        {
            th = this.textBox1.Text.Trim();
            try
            {
                
                String sql = "select user,problem from users where  user='" + this.textBox1.Text.Trim() + "' and problem ='" + this.textBox2.Text.Trim() + "'";
                MySqlDataReader dr = Database.Dr(sql); //执行语句

                if (dr.Read()) //如果dr读到了信息返回true；否则返回false             
                {
                    MessageBox.Show("检测成功,请输入新密码");
                    label4.Visible = true;
                    textBox3.Visible = true;
                    button2.Visible = true;
                    button1.Visible = false;
                    label1.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    label5.Visible = false;
                    label6.Visible = false;
                    label7.Visible = false;
                    comboBox1.Visible = false;
                    textBox1.Visible = false;
                    textBox2.Visible = false;

                }
                else
                {
                    MessageBox.Show("检测的姿势不对，请换个姿势");
                }
            }
            catch
            {
                MessageBox.Show("连接数据库的姿势不对");
                Database.Close();
            }
            Database.Close();
        }

        private void unpas_Load(object sender, EventArgs e)
        {

        }

        private void unpas_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String password = this.textBox3.Text.Trim();
            String jm = MD5Encrypt64.MD5Encrypt(password);
            try
            {
                
                String sql = "update users  set  password = '" + jm + "' where user = '" + th + "'";
                MySqlDataReader dr = Database.Dr(sql); //执行语句

                if (dr.Read()) //如果dr读到了信息返回true；否则返回false             
                {
                    MessageBox.Show("检测的姿势不对，请换个姿势");
                }
                else
                {
                    MessageBox.Show("修改成功");
                    login login = new login();
                    this.Hide();
                    login.Show();
                }
            }
            catch
            {
                MessageBox.Show("连接数据库的姿势不对");
                Database.Close();
            }
            Database.Close();
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim() == "")
            {
                label5.Text = " 请输入用户名";
                label5.ForeColor = Color.Red;
            }
            else if (this.textBox1.Text.Trim()!= "")
            {
                label5.Text = " *";
                label5.ForeColor = Color.Red;
            }
             if(this.textBox2.Text.Trim() == "")
            {
                label7.Text = " 答案不能为空";
                label7.ForeColor = Color.Red;
            }else if (this.textBox2.Text.Trim()!="")
                {
                label7.Text = " *";
                label7.ForeColor = Color.Red;

            }

            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
