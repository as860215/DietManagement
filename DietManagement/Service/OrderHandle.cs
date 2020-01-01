using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietManagement
{
    /// <summary>
    /// 訂單
    /// </summary>
    public class OrderHandle : DBConnect
    {
        /// <summary>
        /// 新增訂單
        /// </summary>
        /// <param name="order"></param>
        public void AddOrder(Order order)
        {
            order.OrderId = GetOrderId().ToString("00000000");
            conn.connOpen(sqlCommand);
            order.Detail = "";
            order.Price = 0;
            //寫入細節
            new CartHandle().GetCartByMemberId(order.OrderMemberId).ForEach(n =>
            {
                var count = new CartHandle().GetDetailCount(n);
                var detail = new MarketHandle().GetMarketDetailById(n.DetailId);
                order.Detail += $@"[{detail.MarketDetailId}]{detail.Name} x {count};";
                order.Price += detail.Price * count;
            });
            using (conn)
            {
                var sql = $@"INSERT INTO [dbo].[Order]
                                   ([OrderId]
                                   ,[OrderMemberId]
                                   ,[RecipientName]
                                   ,[RecipientPhone]
                                   ,[RecipientAddress]
                                   ,[RecipientMail]
                                   ,[Detail]
                                   ,[Price])
                             VALUES
                                   (@OrderId
                                   ,@OrderMemberId
                                   ,@RecipientName
                                   ,@RecipientPhone
                                   ,@RecipientAddress
                                   ,@RecipientMail
                                   ,@Detail
                                   ,@Price)";
                conn.Execute(sql, order);
            }
        }

        /// <summary>
        /// 訂單編號流水號助手
        /// </summary>
        /// <returns>OrderId流水號</returns>
        private int GetOrderId()
        {
            using (conn)
            {
                var sql = $@"select top 1 OrderId from [Order] order by OrderId desc";
                return conn.Query<int>(sql).FirstOrDefault() + 1;
            }
        }
    }
}
