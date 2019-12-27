using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietManagement
{
    /// <summary>
    /// 商店分類
    /// </summary>
    public class MarketType
    {
        /// <summary>
        /// 商店分類編號
        /// </summary>
        public string MarketTypeId { get; set; }

        /// <summary>
        /// 分類名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 依附的商店分類編號
        /// </summary>
        public string AttachId { get; set; }

        /// <summary>
        /// 套用到前端ID的名稱
        /// </summary>
        public string ElementName { get; set; }
        
        /// <summary>
        /// 順序
        /// </summary>
        public int? OrderNum { get; set; }
    }
}
