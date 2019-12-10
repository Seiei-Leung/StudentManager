using DAL;
using Models;
using Models.ext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentManager.ExcelPrint;


namespace StudentManager
{
    public partial class FrmManagerStudents : Form
    {
        private StudentClassService studentClassService = new StudentClassService();

        private StudentService studentService = new StudentService();

        private List<StudentExt> studentExts = new List<StudentExt>();

        /// <summary>
        /// 初始化
        /// </summary>
        public FrmManagerStudents()
        {
            InitializeComponent();
            this.comboBox1.DataSource = studentClassService.getAll();
            this.comboBox1.DisplayMember = "className";
            this.comboBox1.SelectedIndex = -1;
            this.comboBox1.ValueMember = "id";
            // 添加事件
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
        }


        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
                int classId = Convert.ToInt32(this.comboBox1.SelectedValue.ToString());
                try
                {
                    List<StudentExt> studentExtList = studentService.getStudentExtByClassId(classId);
                    this.dataGridView1.DataSource = studentExtList;
                    studentExts = studentExtList;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("获取数据发生错误：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
        }

        // 根据生日排序
        private void button1_Click(object sender, EventArgs e)
        {
            if (studentExts.Count == 0)
            {
                return;
            }
            studentExts.Sort(new CompareOfbirthday());
            this.dataGridView1.DataSource = null; // 需要清空之前的数据，才能刷新数据
            this.dataGridView1.DataSource = studentExts;
        }

        /// <summary>
        /// 显示详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (studentExts.Count == 0)
            {
                return;
            }
            StudentExt studentExt = studentExts[e.RowIndex];
            FormStudentDetail formStudentDetail = new FormStudentDetail(studentExt);
            formStudentDetail.ShowDialog();
        }


    }

    /// <summary>
    /// 升序
    /// IComparer 接口，实现 Compare 接口，用于 sort
    /// </summary>
    class CompareOfbirthday : IComparer<StudentExt>
    {
        public int Compare(StudentExt x, StudentExt y)
        {
            return x.birthday.CompareTo(y.birthday);
        }
    }
}
