using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DietManagement
{
    /// <summary>
    /// 購物車
    /// </summary>
    [DataContract]
    public class Cart
    {
        /// <summary>
        /// 成員編號
        /// </summary>
        [DataMember]
        public string MemberId { get; set; }

        /// <summary>
        /// 商品明細編號
        /// </summary>
        [DataMember]
        public string DetailId { get; set; }

        /// <summary>
        /// 數量
        /// </summary>
        [DataMember]
        public int? Count { get; set; }
    }
}
