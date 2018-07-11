using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace main
{
    public partial class Manage : Form
    {
       

        public Manage()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            refresh(null);

        }
       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            
            DataGridViewColumn  column = dataGridView1.Columns[e.ColumnIndex];
            if (column is DataGridViewButtonColumn) {
                
                int R = row.Index;
                String C = column.Name;

            if (C == "编辑")
            {
                    //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()); //获取第二列值 
                Change.filepath = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();  
                Change.id = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                Change.name = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                Change.sex = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                Change.phone = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                Change.dizhi = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

                Change change = new Change();
                this.Hide();
                change.MdiParent = this.MdiParent;
                change.Show();
            }
            else 
                {
                try
                {
                       
                        String sql = "delete from data where id='" + dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() + "'";
                        MySqlDataReader dr = Database.Dr(sql); 

                    if (dr.Read()) //如果dr读到了信息返回true；否则返回false             
                    {
                        MessageBox.Show("删除的姿势不对，请换个姿势");
                    }
                    else
                    {
                        MessageBox.Show("删除成功");
                            
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

        }

        private void Manage_Load(object sender, EventArgs e)
        {
            string query;
            query = "select * from data";
            
            MySqlDataAdapter adapter = Database.Adapter(query);  //数据适配器  

            DataTable P_dt = new DataTable(); //数据表
            adapter.Fill(P_dt);       //将查询到数据填充到数据表

            this.dataGridView1.DataSource = P_dt; //绑定DataGridView

            Database.Close();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            String sql = "select img from data where id='" + dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() + "'";
            MySqlDataReader dr = Database.Dr(sql);
            if (e.ColumnIndex == 2)
            {
                if (e.Value == null)
                {
                    if (dr.Read()) //如果dr读到了信息返回true；否则返回false             
                    {
                        String ad = dr["img"].ToString();

                        Image result = Database.Resetsize(ad,50,60);
                        // Image result = Image.FromFile(@"D:\cpp\c#\main\main\bin\Debug\img\1.png"); 
                        e.Value = result;
                        e.FormattingApplied = true;
                        
                    }
                   
                }
            }
            Database.Close();


        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        //刷新数据
        private void refresh(string nodeText)
        {
            string query;
            Database conn = new Database(); //连接数据库

            switch (nodeText)
            {
                case "人事部":
                case "技术部":
                case "资源部":
                    query = "select * from data where bumen ='" + nodeText + "'";
                    break;
                case "男":
                case "女":
                    query = "select * from data where sex = '" + nodeText + "'";
                    break;
                default:
                    query = "select * from data";
                    break;
            }

            MySqlDataAdapter adapter = Database.Adapter(query);  //数据适配器  

            DataTable P_dt = new DataTable(); //数据表
            adapter.Fill(P_dt);       //将查询到数据填充到数据表

            this.dataGridView1.DataSource = P_dt; //绑定DataGridView

            Database.Close();

        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if ((sender as TreeView) != null)
            {
                treeView1.SelectedNode = treeView1.GetNodeAt(e.X, e.Y);

                refresh(treeView1.SelectedNode.Text);
               // MessageBox.Show(treeView1.SelectedNode.Text, "节点名");
            }

        }
    }
}
