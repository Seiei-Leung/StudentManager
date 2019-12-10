using Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StudentClassService
    {
        /// <summary>
        /// 获取所有班级
        /// </summary>
        /// <returns></returns>
        public List<StudentClass> getAll() {
            string sql = "select id, className from studentClass";
            MySqlDataReader reader = SQLHelper.getReader(sql);
            List<StudentClass> studentClassList = new List<StudentClass>();
            while(reader.Read()) {
                studentClassList.Add(new StudentClass()
                {
                    id = Convert.ToInt32(reader["id"]),
                    className = reader["className"].ToString()
                });
            }
            reader.Close();
            return studentClassList;
        }
    }
}
