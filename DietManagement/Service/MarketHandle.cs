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

        /// <summary>
        /// 根據元素名稱取得同類別的商品
        /// </summary>
        /// <param name="elementName"></param>
        /// <returns></returns>
        public List<MarketDetail> GetMarketDetailByName(string elementName)
        {
            using (conn)
            {
                var sql = $@"SELECT * FROM MarketDetail WHERE ElementName = @elementName";
                return conn.Query<MarketDetail>(sql, new { elementName }).ToList();
            }
        }
    }
}
