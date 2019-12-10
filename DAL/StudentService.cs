using Models;
using Models.ext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class StudentService
    {
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="student"></param>
        public void insert(Student student)
        {
            string sql = "insert into student (classId, birthday, img, studentName, sex) values ('{0}', '{1}', '{2}', '{3}', '{4}')";
            sql = string.Format(sql, student.classId, student.birthday, student.img, student.studentName, student.sex);
            SQLHelper.executeNonQuery(sql);
        }

        /// <summary>
        /// 根据专业获取学生列表
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public List<StudentExt> getStudentExtByClassId(int classId)
        {
            string sql = "select a.img, a.birthday, a.studentName, a.studentId, a.sex, b.className ";
            sql += "from student a left join studentClass b on a.classId = b.id ";
            sql += "where b.id = '" + classId + "'";
            MySqlDataReader reader = SQLHelper.getReader(sql);
            List<StudentExt> studentList = new List<StudentExt>();
            while (reader.Read())
            {
                StudentExt studentExt = new StudentExt()
                {
                    img = reader["img"].ToString(),
                    birthday = Convert.ToDateTime(reader["birthday"]),
                    sex = reader["sex"].ToString(),
                    studentId = Convert.ToInt32(reader["studentId"]),
                    studentName = reader["studentName"].ToString(),
                    className = reader["className"].ToString()
                };
                studentList.Add(studentExt);
            }
            return studentList;
        }
    }
}
