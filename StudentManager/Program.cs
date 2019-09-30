using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace StudentManager
{
    static class Program
    {
        // 相当于全局变量
        public static Admin currentAdmin = null; // 当前用户

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 显示登录窗口
            FrmUserLogin frmUserLogin = new FrmUserLogin();
            DialogResult result = frmUserLogin.ShowDialog(); // 显示登录窗口，获取登录结果

            if (result == DialogResult.OK)
            {
                Application.Run(new FrmMain()); // 主线程窗口
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
