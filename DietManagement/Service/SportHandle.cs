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
        /// 新增運動
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
                           ,[Market]
                           ,[MemberJoinJson])
                     VALUES
                           (@SportId
                           ,@MemberId
                           ,@SportDate
                           ,@Market
                           ,@MemberJoinJson)";
                conn.Execute(sql, sport);
            }
        }

        /// <summary>
        /// 將成員加入運動
        /// </summary>
        /// <param name="sportId"></param>
        public void JoinSport(string sportId,string joinMemberId)
        {
            var sport = GetSport(sportId);
            var joinMember = sport.MemberJoins.MemberId;
            joinMember.Add(joinMemberId);
            sport.MemberJoinJson = Newtonsoft.Json.JsonConvert.SerializeObject(new MemberJoin() { MemberId = joinMember });

            conn.connOpen(sqlCommand);
            using (conn)
            {
                var sql = $@"UPDATE [dbo].[Sport]
                               SET [MemberJoinJson] = @MemberJoins
                             WHERE [SportId] = @sportId";
                conn.Execute(sql, new { MemberJoins = sport.MemberJoinJson, sportId = sportId});
            }
        }

        /// <summary>
        /// 根據運動編號取得運動資訊
        /// </summary>
        /// <param name="sportId">運動編號</param>
        /// <returns></returns>
        public Sport GetSport(string sportId)
        {
            using (conn)
            {
                var sql = $@"SELECT * FROM Sport
                            WHERE SportId = @sportId";
                return conn.Query<Sport>(sql, new { sportId }).FirstOrDefault();
            }
        }

        /// <summary>
        /// 根據門市和時間取得運動資訊
        /// </summary>
        /// <param name="market">指定門市</param>
        /// <param name="dateTime">指定時間</param>
        /// <returns></returns>
        public List<Sport> GetSport(Market market,DateTime dateTime)
        {
            var dateStart = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
            var dateEnd = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59);
            using (conn)
            {
                var sql = $@"SELECT * FROM Sport
                            WHERE Market = @market
                            AND (SportDate BETWEEN @dateStart AND @dateEnd)";
                return conn.Query<Sport>(sql, new { market, dateStart, dateEnd }).ToList();
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
