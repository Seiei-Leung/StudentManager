using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


// 打印 Excel
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using Models.ext;
using System.IO;

namespace StudentManager.ExcelPrint
{
    class StudentPrint
    {
        public static void ExecutePrint(StudentExt studentExt)
        {
            // 定义Excel 工作簿
            Microsoft.Office.Interop.Excel.Application excelApp = new Application();

            // 获取已创建的工作路径
            string pathOfExcel = Environment.CurrentDirectory + "\\studentInfo.xls";

            // 将现有工作簿加入已定义的工作簿集合中
            excelApp.Workbooks.Add(pathOfExcel);

            // 获取第一个工作表
            Worksheet workSheet = (Worksheet)excelApp.Worksheets[1];

            /**
             * 写入数据
             */
            // 文字设置
            workSheet.Cells[4, 6] = studentExt.studentName;
            workSheet.Cells[6, 6] = studentExt.sex;
            workSheet.Cells[8, 6] = studentExt.className;
            workSheet.Cells[10, 6] = studentExt.birthday;
            // 图片设置
            if (studentExt.img.Length != 0)
            {
                // 获取图片信息
                Image img = (Image)SerializeObjectToString.DeserializeObject(studentExt.img);
                // 在默认文件路径里存储图片
                // 如果根目录路径已经有图片存在，则删除它
                if (File.Exists(Environment.CurrentDirectory + "\\studentInfo.jpg"))
                {
                    File.Delete(Environment.CurrentDirectory + "\\studentInfo.jpg");
                }
                // 保存到根目录路径
                img.Save(Environment.CurrentDirectory + "\\studentInfo.jpg");
                // 将图片插入到 Excel 中
                // 接受第一个参数为文件路径，最后的是坐标
                workSheet.Shapes.AddPicture(
                    Environment.CurrentDirectory + "\\studentInfo.jpg",
                    MsoTriState.msoFalse,
                    MsoTriState.msoCTrue,
                    10, 10, 140, 130
                    );
                // 导入成功之后，删除图片
                File.Delete(Environment.CurrentDirectory + "\\studentInfo.jpg");
            }

            // 打印预览
            excelApp.Visible = true;
            excelApp.Sheets.PrintPreview();

            // 释放对象
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            excelApp = null;
        }
    }
}
