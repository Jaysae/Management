using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace main
{
    class Database
    {
        private static String connetStr = "server=localhost;user=root;password=yszm; database=user;";

        public static MySqlConnection conn = new MySqlConnection(connetStr); //打开数据库建立一个数据库连接对象conn

        public static MySqlCommand sqlcmd = new MySqlCommand(); //定义命令

        public static void Open()
        {
            conn.Open();
        }

        public static void Close()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        public static bool RunSql (String Strsql)
        {
            Close();
            Open();
            try
            {
                sqlcmd = new MySqlCommand(Strsql,conn);
                sqlcmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                MessageBox.Show( "数据库错误");
                Close();
                return false;
            }
        }
        public static MySqlDataReader Dr( String Strsql)
        {
            Close();
            Open();
                sqlcmd = new MySqlCommand(Strsql, conn);
                MySqlDataReader Odr = sqlcmd.ExecuteReader();
                return Odr;

        }
        public static MySqlDataAdapter Adapter( String Strsql)
        {
          
            Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter(Strsql,conn);  
            return adapter;

        }
        public static Image Resetsize(string filename, int width, int height)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            Image image = Image.FromStream(fs);
            
            fs.Close();
            
            // 源图宽度及高度   
            int imageWidth = image.Width;
            int imageHeight = image.Height;
            // 生成的缩略图实际宽度及高度   
            int btWidth = width;
            int btHeight = height;
            // 生成的缩略图在上述"画布"上的位置   
            int X = 0;
            int Y = 0;
            // 根据源图及欲生成的缩略图尺寸,计算缩略图的实际尺寸及其在"画布"上的位置   
            if (btHeight * imageWidth > btWidth * imageHeight)
            {
                btHeight = imageHeight * width / imageWidth;
                Y = (height - btHeight) / 2;
            }
            else
            {
                btWidth = imageWidth * height / imageHeight;
                X = (width - btWidth) / 2;
            }
            // 创建画布   
            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            // 指定高质量的双三次插值法。执行预筛选以确保高质量的收缩。此模式可产生质量最高的转换图像。   
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // 指定高质量、低速度呈现。   
            g.SmoothingMode = SmoothingMode.HighQuality;
            // 在指定位置并且按指定大小绘制指定的 Image 的指定部分。   
            g.DrawImage(image, new Rectangle(X, Y, btWidth, btHeight), new Rectangle(0, 0, imageWidth, imageHeight), GraphicsUnit.Pixel);
            //释放资源     
            g.Dispose();
            
            return bmp;
        }

    }
}
