using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace main
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new login());

            //login login = new login();

            //login.ShowDialog();
            //if (login.DialogResult == DialogResult.OK)
            //{
            //    Application.Run(new Form1());
            //}
            //else
            //{
            //   return;
            //}
           

            //    Application.Run(new login());


        }
    }
}
