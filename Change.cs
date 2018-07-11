using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace main
{
    public partial class Change : Form
    {
        public Change()
        {
            InitializeComponent();
        }
        public static String id = "";
        public static String name = "";
        public static String sex = "";
        public static String phone = "";
        public static String dizhi = "";
        public static String filename = "";
        public static String image = "";
        public static long fileinfoo = 0;
        public static String path = "";
        public static String filepath = "";

        private void Change_Load(object sender, EventArgs e)
        {
            this.textBox1.Enabled = false;
            this.textBox1.Text = id;
            this.textBox2.Text = name;
            this.textBox3.Text = phone;
            this.textBox4.Text = dizhi;

            pictureBox1.Image = Database.Resetsize(filepath, 50, 60);
            if (sex == "男")
            {
                this.radioButton1.Checked = true;
            }
            else {
                this.radioButton2.Checked = true;
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
                try
                {
                string filename1 = DateTime.Now.Ticks.ToString();//时间戳，保证图片名称不重复
                path = @"D:\\cpp\\c#\\main\\main\\bin\\Debug\\img\\" + filename1 + image;

                String sql = "update data set name = '" + this.textBox2.Text.Trim() + "',sex ='" + (this.radioButton1.Checked ? "男" : "女") + "',phone='" + this.textBox3.Text.Trim() + "',dizhi='" + this.textBox4.Text.Trim() + "',img='" + path+ "' where id ='" + this.textBox1.Text.Trim() + "'";
                MySqlDataReader dr = Database.Dr(sql);
                    if (dr.Read())
                    {
                        MessageBox.Show("请换个姿势");
                    }
                    else
                    {
                        
                    if (fileinfoo > 8192000)
                    {
                        MessageBox.Show("上传的图片不能大于8M");
                    }
                    else
                    {
                        File.Copy(filename, path);//将图片复制到指定文件夹
                        MessageBox.Show("修改成功");
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

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "图片|*.jpg;*.jpeg;*.png;*.gif"; //限制图片格式

            if (file.ShowDialog() == DialogResult.OK)
            {
                filename = file.FileName;//获取文件路径
                                     // filename = file.SafeFileName //获取文件名加后缀
                                     //String[] Data = filename.Split('.');
                                     //image = Data[1]; //获取文件后缀名
                image = Path.GetExtension(filename);  //获取文件后缀名

                pictureBox1.Image = Database.Resetsize(filename, 100, 110);  //显示图片
                FileInfo fileinfo = new FileInfo(filename);
                fileinfoo = fileinfo.Length;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
