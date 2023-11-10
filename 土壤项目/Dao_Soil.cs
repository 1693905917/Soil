using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace 土壤项目
{
    public class Dao_Soil  //数据库连接
    {
        public SqlConnection conn;

        public SqlConnection getConn()
        {
            //string str = @"Data source=LAPTOP-34I3S1O3\MSSQLSERVERS;Initial Catalog=Soil;User ID=sa;PassWord=123456";
            string str = "Data source=LAPTOP-G4E5D7TN;database=session3;uid=sa;pwd=123456";
            conn = new SqlConnection(str);
            conn.Open();
            return conn;
        }

        public SqlCommand getCommand(string sql)
        {
            SqlCommand command = new SqlCommand(sql, getConn());
            return command;
        }

        //public int executeUpdate(string sql)
        //{
        //    return getCommand(sql).ExecuteNonQuery();
        //}

        public SqlDataReader executeQuery(string sql)
        {
            return getCommand(sql).ExecuteReader();
        }

        //public void close()
        //{
        //    conn.Close();
        //}
    }
}
