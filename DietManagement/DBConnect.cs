using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DietManagement
{
    public class DBConnect
    {
        private const string sqlCommand = @"Data Source=USER-PC\SQLEXPRESS;Initial Catalog=DietManagement;User ID=capoo;Pwd=capoo";

        public SqlConnection conn { get; set; }

        /// <summary>
        /// 建構子
        /// </summary>
        public DBConnect()
        {
            conn = new SqlConnection(sqlCommand);
            conn.Open();
        }
    }
}
