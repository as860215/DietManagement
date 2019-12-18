using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietManagement
{
    /// <summary>
    /// 運動
    /// </summary>
    public class SportHandle : DBConnect
    {
        /// <summary>
        /// 加入運動
        /// </summary>
        /// <param name="sport"></param>
        public void InsertSport(Sport sport)
        {
            sport.SportId = GetIdHelper().ToString("00000000");
            conn.connOpen(sqlCommand);
            using (conn)
            {
                var sql = $@"INSERT INTO [dbo].[Sport]
                           ([SportId]
                           ,[MemberId]
                           ,[SportDate]
                           ,[Market])
                     VALUES
                           (@SportId
                           ,@MemberId
                           ,@SportDate
                           ,@Market)";
                conn.Execute(sql, sport);
            }

        }

        /// <summary>
        /// 運動流水號助手
        /// </summary>
        /// <returns>運動流水號</returns>
        private int GetIdHelper()
        {
            using (conn)
            {
                var sql = $@"select top 1 SportId from Sport order by SportId desc";
                return conn.Query<int>(sql).FirstOrDefault() + 1;
            }
        }
    }
}
