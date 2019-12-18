using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DietManagement
{
    /// <summary>
    /// 運動
    /// </summary>
    [DataContract]
    public class Sport
    {
        /// <summary>
        /// 運動編號
        /// </summary>
        [DataMember]
        public string SportId { get; set; }
        /// <summary>
        /// 建立者成員編號
        /// </summary>
        [DataMember]
        public string MemberId { get; set; }
        /// <summary>
        /// 運動日期
        /// </summary>
        [DataMember]
        public DateTime SportDate { get; set; }
        /// <summary>
        /// 對應門市名稱
        /// </summary>
        [DataMember]
        public Market Market { get; set; }
    }
}
