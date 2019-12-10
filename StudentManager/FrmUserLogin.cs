using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using DAL;

namespace StudentManager
{
    public partial class FrmUserLogin : Form
    {
        public FrmUserLogin()
        {
            InitializeComponent();
            this.userName.Text = "123";
            this.pw.Text = "123";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 登录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string userId = this.userName.Text.Trim();
            string pw = this.pw.Text.Trim();
            if (userId.Length == 0)
            {
                MessageBox.Show("请输入用户账号", "登录信息提示");
                this.userName.Focus();
                return;
            }
            if (this.pw.Text.Length == 0)
            {
                MessageBox.Show("请输入用户密码", "登录信息提示");
                this.pw.Focus();
                return;
            }
            if (!RegexUtil.isInteger(userId))
            {
                MessageBox.Show("用户账号必须为纯数字", "登录信息提示");
                this.userName.Focus();
                this.userName.SelectAll();
                return;
            }
            Admin admin = AdminService.login(userId, pw);
            if (admin == null)
            {
                MessageBox.Show("账号或密码错误");
                return;
            }
            else
            {
                Program.currentAdmin = admin;
                this.DialogResult = DialogResult.OK; // 在程序中一旦设置 DialogResult 的值，接下来就会自动执行close()的方法，所以其实没有必要写this.close()
            }
            
        }

        private void userName_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.userName.Text.Length == 0)
            {
                return;
            }
            // 13 为 Enter 按键的代码，如果检测到按键为 Enter，则聚焦密码输入框
            if (e.KeyValue == 13)
            {
                this.pw.Focus();
            }
        }

        private void pw_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.pw.Text.Length == 0)
            {
                return;
            }
            if (e.KeyValue == 13)
            {
                this.button1_Click(null, null);
            }
        }

    }
}
