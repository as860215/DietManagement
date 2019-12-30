using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietManagement
{
    /// <summary>
    /// 購物車
    /// </summary>
    public class CartHandle : DBConnect
    {
        /// <summary>
        /// 根據成員編號取得購物車清單
        /// </summary>
        /// <param name="memberId">成員編號</param>
        /// <returns></returns>
        public List<Cart> GetCartByMemberId(string memberId)
        {
            using (conn)
            {
                var sql = $@"SELECT * FROM Cart WHERE MemberId='{memberId}'";
                return conn.Query<Cart>(sql).ToList();
            }
        }

        /// <summary>
        /// 根據成員編號與商品編號取得該商品在此成員購物車的數量
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        private int GetDetailCount(Cart cart)
        {
            using (conn)
            {
                var sql = $@"SELECT Count FROM Cart WHERE MemberId=@MemberId AND DetailId=@DetailId";
                return conn.Query<int>(sql, cart).FirstOrDefault();
            }
        }

        /// <summary>
        /// 更新購物車清單
        /// </summary>
        /// <param name="cart"></param>
        /// <param name="weighted">數量加權值</param>
        public void UpdateCartDetail(Cart cart,int weighted)
        {
            var count = GetDetailCount(cart);
            conn.connOpen(sqlCommand);
            using (conn)
            {
                //Insert
                if(count == 0)
                {
                    cart.Count = weighted;
                    var sql = $@"INSERT INTO [dbo].[Cart]
                                       ([MemberId]
                                       ,[DetailId]
                                       ,[Count])
                                 VALUES
                                       (@MemberId
                                       ,@DetailId
                                       ,@Count)";
                    conn.Execute(sql, cart);
                }
                //Update
                else
                {
                    cart.Count = count + weighted;
                    var sql = $@"UPDATE [dbo].[Cart]
                                   SET [MemberId] = @MemberId
                                      ,[DetailId] = @DetailId
                                      ,[Count] = @Count
                                 WHERE MemberId=@MemberId AND DetailId=@DetailId";
                    conn.Execute(sql,cart);
                }
            }
        }
    }
}
