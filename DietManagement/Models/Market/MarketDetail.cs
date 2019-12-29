using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietManagement
{
    /// <summary>
    /// 商品
    /// </summary>
    public class MarketDetail
    {
        /// <summary>
        /// 商品編號
        /// </summary>
        public string MarketDetailId { get; set; }

        /// <summary>
        /// 商品名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 商品價格
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// 商品圖片位址
        /// </summary>
        public string Img { get; set; }

        /// <summary>
        /// 元件名稱
        /// </summary>
        public string ElementName { get; set; }
    }
}
