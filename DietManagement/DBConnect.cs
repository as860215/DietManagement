using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DietManagement
{
    public class DBConnect
    {
        private const string sqlCommand = @"Data Source=DESKTOP-AIS9VBL\SQLEXPRESS;Initial Catalog=DietManagement;User ID=capoo;Pwd=capoo";

        public SqlConnection conn { get; set; }

        public DBConnect()
        {
            conn = new SqlConnection(sqlCommand);
            conn.Open();
        }
    }
}
