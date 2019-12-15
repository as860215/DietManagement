using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietManagement
{
    /// <summary>
    /// 歷史資訊
    /// </summary>
    public class HistoryHandle : DBConnect
    {
        /// <summary>
        /// 藉由編號取得歷史資訊
        /// </summary>
        /// <param name="historyId"></param>
        /// <returns></returns>
        public History GetHistoryById(string historyId)
        {
            using (conn)
            {
                var sql = $@"select * from History where HistoryId='{historyId}'";
                return conn.Query<History>(sql).FirstOrDefault();
            }
        }

        /// <summary>
        /// 根據成員編號取得指定月份所有資料
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public List<History> GetMonthHisotry(string memberId,DateTime dateTime,HistoryType historyType)
        {
            var firstDate = dateTime.ToString("yyyy/MM") + "/01";
            var lastDate = dateTime.AddMonths(1).ToString("yyyy/MM") + "/01";
            using (conn)
            {
                var sql = $@"select * from History where MemberId='{memberId}' AND HistoryType='{(int)historyType}' AND DataDate >= '{firstDate}' AND DataDate < '{lastDate}' order by DataDate";
                return conn.Query<History>(sql).ToList();
            }
        }

        /// <summary>
        /// 檢查當天是否有重複紀錄
        /// </summary>
        /// <param name="history"></param>
        /// <returns></returns>
        public History CheckDuplicate(History history)
        {
            using (conn)
            {
                var sql = $@"select * from History where MemberId=@MemberId AND HistoryType=@HistoryType AND DataDate=@DataDate";
                return conn.Query<History>(sql,history).FirstOrDefault();
            }
        }

        /// <summary>
        /// 更新歷史資訊資料
        /// </summary>
        /// <param name="history"></param>
        public void UpdateHistoryData(History history)
        {
            using (conn)
            {
                var sql = $@"UPDATE [dbo].[History]
                               SET [MemberId] = @MemberId
                                  ,[HistoryType] = @HistoryType
                                  ,[Value] = @Value
                                  ,[DataDate] = @DataDate
                             WHERE HistoryId = @HistoryId";
                conn.Execute(sql, history);
            }
        }

        /// <summary>
        /// 新增歷史資訊資料
        /// </summary>
        /// <param name="history">歷史資訊</param>
        public void AddHistoryData(History history)
        {
            history.HistoryId = HistoryIdHelper().ToString("00000000");
            conn.connOpen(sqlCommand);
            using (conn)
            {
                var sql = $@"INSERT INTO [dbo].[History]
                               ([HistoryId]
                               ,[MemberId]
                               ,[HistoryType]
                               ,[Value]
                               ,[DataDate])
                         VALUES
                               (@HistoryId
                               ,@MemberId
                               ,@HistoryType
                               ,@Value
                               ,@DataDate)";
                conn.Execute(sql, history);
            }
        }

        /// <summary>
        /// 歷史資訊流水號小幫手
        /// </summary>
        /// <returns></returns>
        private int HistoryIdHelper()
        {
            using (conn)
            {
                var sql = $@"select top 1 HistoryId from History order by HistoryId desc";
                return conn.Query<int>(sql).FirstOrDefault() + 1;
            }
        }
    }
}
