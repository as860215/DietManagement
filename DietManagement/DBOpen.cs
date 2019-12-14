using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DietManagement
{
    public static class DBOpen
    {
        /// <summary>
        /// 開啟連線
        /// </summary>
        public static void connOpen(this SqlConnection conn,string sqlCommand)
        {
            conn.ConnectionString = sqlCommand;
            conn.Open();
        }
    }
}
