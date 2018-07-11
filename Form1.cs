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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = Application.StartupPath + "//Longhorn.ssk";
            if (role == "管理员")
            {
                添加员工信息ToolStripMenuItem.Visible = true;
                管理员工信息ToolStripMenuItem.Visible = true;
                新建ToolStripMenuItem.Visible = false;
            }
            else {
                添加员工信息ToolStripMenuItem.Visible = false;
                管理员工信息ToolStripMenuItem.Visible = false;
                新建ToolStripMenuItem.Visible = false;
                toolStripButton1.Visible = false;
                toolStripButton2.Visible = false;
            }

        }
        public static String th = "";
        public static String role = "";
        public static int id = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            
            Text = "欢迎"+th+"登陆！ 员工ID:"+id; 
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {               //判断窗口是否打开过
            foreach (Form childForm in this.MdiChildren)
            {   
                //判断打开的子窗体镇南关,是否存在该子窗体
                if (childForm is z_c)
                {
                    //说明有打开过的窗口

                    childForm.Visible = true;
                    //设置活动窗口
                    childForm.Activate();
                    //获得焦点
                    childForm.Focus();
                    //窗口最大化
                    //childForm.WindowState = FormWindowState.Maximized;
                    return ;
                }
            }
            z_c zc = new z_c();

            zc.MdiParent = this;
            zc.Show();
            //窗口最大化
            //zc.WindowState = FormWindowState.Maximized;
           // Mdiparent
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                //判断打开的子窗体镇南关,是否存在该子窗体
                if (childForm is Inquire)
                {
                    //说明有打开过的窗口

                    childForm.Visible = true;
                    //设置活动窗口
                    childForm.Activate();
                    //获得焦点
                    childForm.Focus();
                    //窗口最大化
                    childForm.WindowState = FormWindowState.Maximized;
                    return;
                }
            }

            Inquire cx = new Inquire();

            cx.MdiParent = this;
            cx.Show();
            //窗口最大化
            //cx.WindowState = FormWindowState.Maximized;
            // Mdiparent
        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("注销成功");

            login lo = new login();
            lo.Show();
            this.Hide();
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void 添加员工信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
                       //判断窗口是否打开过
            foreach (Form childForm in this.MdiChildren)
            {   
                //判断打开的子窗体镇南关,是否存在该子窗体
                if (childForm is Add)
                {
                    //说明有打开过的窗口

                    childForm.Visible = true;
                    //设置活动窗口
                    childForm.Activate();
                    //获得焦点
                    childForm.Focus();
                    //窗口最大化
                    //childForm.WindowState = FormWindowState.Maximized;
                    return ;
                }
            }
            Add zc = new Add();

            zc.MdiParent = this;
            zc.Show();
            //窗口最大化
            //zc.WindowState = FormWindowState.Maximized;
           // Mdiparent

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //判断窗口是否打开过
            foreach (Form childForm in this.MdiChildren)
            {
                //判断打开的子窗体镇南关,是否存在该子窗体
                if (childForm is Add)
                {
                    //说明有打开过的窗口

                    childForm.Visible = true;
                    //设置活动窗口
                    childForm.Activate();
                    //获得焦点
                    childForm.Focus();
                    //窗口最大化
                    //childForm.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            Add zc = new Add();

            zc.MdiParent = this;
            zc.Show();
            //窗口最大化
            //zc.WindowState = FormWindowState.Maximized;
            // Mdiparent
        }

        private void 管理员工信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //判断窗口是否打开过
            foreach (Form childForm in this.MdiChildren)
            {
                //判断打开的子窗体镇南关,是否存在该子窗体
                if (childForm is Manage)
                {
                    //说明有打开过的窗口

                    childForm.Visible = true;
                    //设置活动窗口
                    childForm.Activate();
                    //获得焦点
                    childForm.Focus();
                    //窗口最大化
                    //childForm.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            Manage gl = new Manage();

            gl.MdiParent = this;
            gl.Show();
            //窗口最大化
            //zc.WindowState = FormWindowState.Maximized;
            // Mdiparent
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                //判断打开的子窗体镇南关,是否存在该子窗体
                if (childForm is Manage)
            {
                //说明有打开过的窗口

                childForm.Visible = true;
                //设置活动窗口
                childForm.Activate();
                //获得焦点
                childForm.Focus();
                //窗口最大化
                //childForm.WindowState = FormWindowState.Maximized;
                return;
            }
        }
        Manage gl = new Manage();

        gl.MdiParent = this;
            gl.Show();
            //窗口最大化
            //zc.WindowState = FormWindowState.Maximized;
            // Mdiparent
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
