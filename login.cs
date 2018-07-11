using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
namespace main
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            // this.skinEngine1.SkinFile = "CalmnessColor1.ssk";
            this.skinEngine1.SkinFile = Application.StartupPath + "//Longhorn.ssk";

        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            //Database conn = new Database();

            //MD5Encrypt64 md5 = new MD5Encrypt64();
            //新建数据库对象

          //  conn.sqlcmd.Connection = conn.conn;//设置数据库连接

            //MySqlDataReader dr = sqlcmd.ExecuteReader();
            //bool str = dr.Read();


            String password = this.textBox2.Text.Trim(); 
            String jm = MD5Encrypt64.MD5Encrypt(password); //md5 加密
            try
            {
                // MySqlCommand mycom = conn.CreateCommand(); //利用现有连接创建一个Command，用以执行sql指令

                // conn.conn.Open(); 
                // conn.sqlcmd.CommandText = "select id,user,password,role from users where  user='" + this.textBox1.Text.Trim() + "'";

                // MySqlDataReader dr = conn.sqlcmd.ExecuteReader(); //执行语句

               
                String sql = "select id,user,password,role from users where  user='" + this.textBox1.Text.Trim() + "'";
                MySqlDataReader dr = Database.Dr(sql);

                if (dr.Read()) //如果dr读到了信息返回true；否则返回false             
                {

                    if (dr["password"].ToString() == jm)
                    {
                        Form1.th = dr["user"].ToString();
                        Form1.id = (int)dr["id"];
                        Form1.role = dr["role"].ToString();
                        MessageBox.Show("登录成功！");
                        Form1 log = new Form1();

                        this.Hide();
                        log.Show();
                    }
                    else {
                        MessageBox.Show("登录的姿势不对，请换个姿势2");
                    }
                    
                    
                }
                else {
                    MessageBox.Show("登录的姿势不对，请换个姿势");
                }
            }
            catch {
                MessageBox.Show("连接数据库的姿势不对");
                Database.Close();
            }
            Database.Close();
            //String name = this.textBox1.Text; // 获取里面的值
            //String password = this.textBox2.Text;
            //if (name.Equals("admin") && password.Equals("yszm")) // 判断账号密码
            //{
            //    MessageBox.Show("登录成功");
            //   // this.Hide();
            //    //log.Show();
            //    this.DialogResult = DialogResult.OK;
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("登录失败！");
            //}



        }

        private void button2_Click(object sender, EventArgs e)
        {
            z_c zc = new z_c();
            this.Hide();
            zc.ShowDialog();
           
      

        }

        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
        }

        private void login_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 1;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            unpas unpas = new unpas();
            this.Hide();
            unpas.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(this.textBox1.Text == "")
            {
                pictureBox1.Image = null;
            }
            String sql = "select id from users where user = '" + this.textBox1.Text.Trim() + "'";
            MySqlDataReader dr = Database.Dr(sql);
            if (dr.Read())
            {
                String a = dr["id"].ToString();
                String sqll = "select d.img from data as d,users as u where d.id=u.id and u.id= '"+ a+"'";
                //String sqll = "select img from data where id = '" +a+ "'";
                MySqlDataReader drr = Database.Dr(sqll);
                if (drr.Read())
                {
                    String s = drr["img"].ToString();
                    pictureBox1.Image = Database.Resetsize(s,110,140);  //显示图片
                }
            }

        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                button1_Click(sender, e);
            }
        }
    }
}
