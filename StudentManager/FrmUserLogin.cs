using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManager
{
    public partial class FrmUserLogin : Form
    {
        public FrmUserLogin()
        {
            InitializeComponent();
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



        }
    }
}
