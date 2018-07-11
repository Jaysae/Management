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
using System.IO;

namespace main
{
    public partial class z_c : Form
    {
        public z_c()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = Application.StartupPath + "//Longhorn.ssk";
        }

        public static String filename = "";
        public static String image = "";
        public static long fileinfoo = 0;
        public static String path = "";
        public static String filepath = "";

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void z_c_Load(object sender, EventArgs e)
        {

        }

        private void z_c_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (this.textBox1.Text.Trim() == "")
            {
                MessageBox.Show("请输入用户名");
                this.textBox1.Focus();
            }
            else if (this.textBox2.Text.Trim() == "")
            {
                MessageBox.Show("请输入密码");
                this.textBox2.Focus();
            }
            else {
                if (this.textBox2.Text.Trim() != this.textBox3.Text.Trim())
                {
                    MessageBox.Show("两次密码必须相同");
                    this.textBox2.Focus();
                }
                else {
                   
                    string password = textBox2.Text.ToString();
                    MD5 md5 = new MD5CryptoServiceProvider();
                    byte[] Data = System.Text.Encoding.Default.GetBytes(password);
                    byte[] md5Data = md5.ComputeHash(Data);
                    md5.Clear();
                    string Newpassword = "";
                    for (int i = 0; i < md5Data.Length; i++)
                    {
                        Newpassword += md5Data[i].ToString("x").PadLeft(2, '0');
                    }
                    this.textBox4.Text = Newpassword;

                    try
                    {
                        string filename1 = DateTime.Now.Ticks.ToString();
                        path = @"D:\\cpp\\c#\\main\\main\\bin\\Debug\\img\\" + filename1 + image;
                        Database.RunSql("insert into data(img,name,sex,bumen) values('" + path+ "','" + this.textBox1.Text.Trim() + "','" + (this.radioButton1.Checked ? "男" : "女") + "','" + this.comboBox2.Text.Trim() + "')");
                        String sql = "insert into users(user,password,role,problem) values('" + this.textBox1.Text.Trim() + "','" + this.textBox4.Text.Trim() + "','员工','" + this.textBox6.Text.Trim() + "')";
                        Database.RunSql(sql);

                        if (fileinfoo > 8192000)
                        {
                            MessageBox.Show("上传的图片不能大于8M");
                        }
                        else
                        {
                            File.Copy(filename, path);//将图片复制到指定文件夹
                            MessageBox.Show("注册成功");
                            login log = new login();

                            this.Hide();
                            log.Show();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("插入出错");
                        Database.Close();
                    }
                    Database.Close();

                }
            }

           

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim() == "")
            {
                label9.Text = "请输入用户名";
                label9.ForeColor = Color.Red;
            }
            else
            {
                try
                {

                    String sql = "select *from users where user = '" + this.textBox1.Text.Trim() + "'";
                    MySqlDataReader dr = Database.Dr(sql);
                    if (dr.Read())
                    {
                        if (dr["user"].ToString() == this.textBox1.Text.ToString())
                        {
                            label9.Text = "账号已存在";
                            label9.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        label9.Text = "✓";
                        label9.ForeColor = Color.Green;
                    }
                }
                catch
                {
                    MessageBox.Show("连接数据库的姿势不对");
                    Database.Close();
                }
                Database.Close();
            }
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
            if (this.textBox2.Text.Trim() == "")
            {
                label11.Text = "请输入密码";
                label11.ForeColor = Color.Red;
            }
            else
            {
                label11.Text = "✓";
                label11.ForeColor = Color.Green;
            }
            }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_MouseLeave(object sender, EventArgs e)
        {
            if (this.textBox2.Text.Trim() != this.textBox3.Text.Trim())
            {
                label10.Text = "密码不相同";
                label10.ForeColor = Color.Red;
            }
            else {
                label10.Text = "✓";
                label10.ForeColor = Color.Green;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "图片|*.jpg;*.jpeg;*.png;*.gif"; //限制图片格式

            if (file.ShowDialog() == DialogResult.OK)
            {
                filename = file.FileName; 
                //获取文件路径
                // filename = file.SafeFileName //获取文件名加后缀
                //String[] Data = filename.Split('.');
                         //image = Data[1]; //获取文件后缀名
                image = Path.GetExtension(filename);  //获取文件后缀名

                pictureBox1.Image = Database.Resetsize(filename,100,150);  //显示图片
                FileInfo fileinfo = new FileInfo(filename);
                fileinfoo = fileinfo.Length;
            }
        }
    }
}
