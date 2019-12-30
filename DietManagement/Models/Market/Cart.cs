using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietManagement
{
    /// <summary>
    /// 購物車
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// 成員編號
        /// </summary>
        public string MemberId { get; set; }

        /// <summary>
        /// 商品明細編號
        /// </summary>
        public string DetailId { get; set; }

        /// <summary>
        /// 數量
        /// </summary>
        public int? Count { get; set; }
    }
}
