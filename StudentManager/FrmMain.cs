using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace StudentManager
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            this.toolStripStatusLabel3.Text = Program.currentAdmin.name; // 显示用户名
            // 代码设置 panel 背景图
            this.panel1.BackgroundImage = Image.FromFile("./static/img/mainBackgroundImg.jpg");
            // 设置版本号
            this.toolStripStatusLabel1.Text = "版本：V" + ConfigurationSettings.AppSettings["version"].ToString();
        }

        /// <summary>
        /// 打开内嵌子窗体
        /// </summary>
        /// <param name="formObj"></param>
        private void openForm(Form formObj)
        {
            formObj.TopLevel = false; // 将子窗体设置为非顶级控件
            formObj.WindowState = FormWindowState.Maximized; // 设置子窗口最大化
            formObj.FormBorderStyle = FormBorderStyle.None; // 消除子窗口边框
            this.panel1.Controls.Add(formObj); // 添加到 panel1 中，此时 formObj 的父窗体 parent 已经设置为 panel1
            formObj.Show(); // 显示子窗体
        }

        /// <summary>
        /// 关闭内嵌子窗体
        /// </summary>
        private void closeForm()
        {
            // 循环面板 Contorls 列表，将窗体关闭并移出
            foreach (Control itemOfControl in this.panel1.Controls) {
                if (itemOfControl is Form)
                {
                    Form formObj = (Form)itemOfControl;
                    formObj.Close();
                    this.panel1.Controls.Remove(itemOfControl);
                }
            }
        }


        /// <summary>
        /// panel 切换到新增学生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            closeForm();
            FrmAddStudent frmAddStudent = new FrmAddStudent();
            openForm(frmAddStudent);
        }

        /// <summary>
        /// 关闭窗体前的询问
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("是否退出程序", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Cancel)
            {
                e.Cancel = true; // 取消关闭
            }
        }

        /// <summary>
        /// 打开学生管理窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            closeForm();
            FrmManagerStudents frmManagerStudents = new FrmManagerStudents();
            openForm(frmManagerStudents);
        }


    }
}
