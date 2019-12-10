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
using Models.ext;
using StudentManager.ExcelPrint;

namespace StudentManager
{
    public partial class FormStudentDetail : Form
    {
        private StudentExt studentExt1;
        public FormStudentDetail()
        {
            InitializeComponent();
        }

        public FormStudentDetail(StudentExt studentExt)
        {
            InitializeComponent();
            this.label2.Text = studentExt.studentName;
            if (studentExt.img.Length != 0)
            {
                this.pictureBox1.Image = (Image)SerializeObjectToString.DeserializeObject(studentExt.img);
            }
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            studentExt1 = studentExt;
        }

        private void FormStudentDetail_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentPrint.ExecutePrint(studentExt1);
        }
    }
}
