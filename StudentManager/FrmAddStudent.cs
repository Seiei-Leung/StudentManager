using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Models;

namespace StudentManager
{
    public partial class FrmAddStudent : Form
    {

        private StudentService studentService = new StudentService();

        private StudentClassService studentClassService = new StudentClassService();


        public FrmAddStudent()
        {
            InitializeComponent();
            // 设置班级下拉选择
            this.comboBox1.DataSource = studentClassService.getAll();
            this.comboBox1.DisplayMember = "className";
            this.comboBox1.ValueMember = "id";
            this.comboBox1.SelectedIndex = -1; // -1 表示没有选中数值，默认为 1
            // Picturebox控件大小不变，图片自动调整大小以适应控件的大小，图片完全显示，且图片长宽比例与控件长宽比例一致。
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; 
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            // 初始化 OpenFileDialog 对象
            OpenFileDialog dialog = new OpenFileDialog();
            // 设置筛选文件，竖号之前的为筛选框的显示文本，之后的为筛选文本格式
            dialog.Filter = "图片文件(*.png;*.jpg;*.bmp;*.jpeg)|*.png;*.jpg;*.bmp;*.jpeg";
            // 是否按了确定
            if (dialog .ShowDialog() == DialogResult.OK)
            {
                string fileName = dialog.FileName;
                Image image = Image.FromFile(fileName);
                this.pictureBox1.Image = image;
            }
        }

        /// <summary>
        /// 点击提交按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // 检验数据
            if (this.textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("姓名不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!this.radioButton1.Checked && !this.radioButton2.Checked)
            {
                MessageBox.Show("性别不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("专业不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string dataOfImage = null;
            if (this.pictureBox1.Image != null)
            {
                dataOfImage = SerializeObjectToString.SerializeObject(this.pictureBox1.Image);
            }
            Student student = new Student() {
               studentName = this.textBox1.Text.Trim(),
               sex = this.radioButton1.Checked ? "男" : "女",
               birthday = Convert.ToDateTime(this.dateTimePicker1.Text),
               classId = Convert.ToInt32(this.comboBox1.SelectedValue),
               img = dataOfImage
            };
            try
            {
                studentService.insert(student);
                // 询问是否继续添加，如果是，就清空
                DialogResult dialogResult = MessageBox.Show("是否继续添加", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    foreach (Control item in this.Controls)
                    {
                        if (item is PictureBox) {
                            PictureBox pictureBox = (PictureBox)item;
                            pictureBox.Image = null;
                        }
                        else if (item is TextBox)
                        {
                            TextBox textBox = (TextBox)item;
                            textBox.Text = "";
                        }
                        else if (item is RadioButton)
                        {
                            RadioButton radioButton = (RadioButton)item;
                            radioButton.Checked = false;
                        }
                        else if (item is ComboBox)
                        {
                            ComboBox comboBox = (ComboBox)item;
                            comboBox.SelectedIndex = -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("插入数据发生异常" + ex.Message, "警告");
            }
        }

    }
}
