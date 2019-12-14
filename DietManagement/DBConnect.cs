using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DietManagement
{
    public class DBConnect
    {
        public string sqlCommand;

        public SqlConnection conn { get; set; }

        /// <summary>
        /// 建構子
        /// </summary>
        public DBConnect()
        {
            using (var sr = new StreamReader("setting.config"))
            {
                sqlCommand = sr.ReadToEnd();
            }
            conn = new SqlConnection();
            conn.connOpen(sqlCommand);
        }
    }
}
