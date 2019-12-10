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
            // 不能直接使用 Application.Run 方法打开登录窗口，Application.Run 方法会直接将 登录窗口 作为主线程，此时如果关闭了登陆窗口，就会导致整个程序关闭
            FrmUserLogin frmUserLogin = new FrmUserLogin();
            // 调用 ShowDialog 显示登录窗口，获取登录结果，不能使用 Show 方法，假如使用 Show 方法，程序就会直接运行下去，即此时会打开两个窗口
            DialogResult result = frmUserLogin.ShowDialog();

            // 获取 登录窗口 返回的信息
            if (result == DialogResult.OK)
            {
                Application.Run(new FrmMain()); // 主线程窗口
            }
            else
            {
                Application.Exit(); // 退出整个程序
            }
        }
    }
}
