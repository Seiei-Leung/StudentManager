using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;// 引入读取配置文件类所在的命名空间

namespace DAL
{
    public class SQLHelper
    {
        public static string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();

        /// <summary>
        /// 增，删，改
        /// </summary>
        /// <param name="sql"></param>
        public static int executeNonQuery(string sql)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            try
            {
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                // 写入日志
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 获取单一数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetSingleResult(string sql)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result;
            }
            catch (Exception ex)
            {
                // 写入日志
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 获取 结果集 的查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static MySqlDataReader getReader(string sql)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            try
            {
                conn.Open();
                MySqlDataReader result = cmd.ExecuteReader(CommandBehavior.CloseConnection); // 关闭数据库链接
                return result;
            }
            catch (Exception ex)
            {
                // 写入日志
                throw ex;
                conn.Close();
            }
        }
    }
}
