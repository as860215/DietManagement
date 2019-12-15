using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DietManagement
{
    /// <summary>
    /// 商店
    /// </summary>
    [DataContract]
    public class Shop
    {
        /// <summary>
        /// 商店編號
        /// </summary>
        [DataMember]
        public string ShopId { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}
