using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class AdminService
    {
        public static Admin login(string userId, string pw)
        {
            string sql = "select name from admin where userId = '{0}' and pw = '{1}'";
            sql = string.Format(sql, userId, pw);
            MySqlDataReader reader = SQLHelper.getReader(sql);
            Admin admin = null;
            if (reader.Read())
            {
                admin = new Admin()
                {
                    userId = Convert.ToInt32(userId),
                    pw = pw,
                    name = reader["name"].ToString()
                 };
            }
            reader.Close();
            return admin;
        }
    }
}
