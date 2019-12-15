using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DietManagement
{
    /// <summary>
    /// 食物
    /// </summary>
    [DataContract]
    public class Food
    {
        /// <summary>
        /// 食物編號
        /// </summary>
        [DataMember]
        public string FoodId { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// 卡路里
        /// </summary>
        [DataMember]
        public int Calories { get; set; }
        /// <summary>
        /// 對應商店名稱
        /// </summary>
        [DataMember]
        public string ShopId { get; set; }
    }
}
