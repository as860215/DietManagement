using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietManagement
{
    /// <summary>
    /// 商店
    /// </summary>
    public class MarketHandle : DBConnect
    {
        /// <summary>
        /// 取得商店類別主檔
        /// </summary>
        /// <returns></returns>
        public List<MarketType> GetMarketType()
        {
            using (conn)
            {
                var sql = $@"SELECT * FROM MarketType ORDER BY OrderNum";
                return conn.Query<MarketType>(sql).ToList();
            }
        }
    }
}
