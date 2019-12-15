using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DietManagement
{
    /// <summary>
    /// 歷史資訊
    /// </summary>
    [DataContract]
    public class History
    {
        /// <summary>
        /// 歷史資訊編號
        /// </summary>
        [DataMember]
        public string HistoryId { get; set; }
        /// <summary>
        /// 成員編號
        /// </summary>
        [DataMember]
        public string MemberId { get; set; }
        /// <summary>
        /// 歷史資訊類別
        /// </summary>
        [DataMember]
        public HistoryType HistoryType { get; set; }
        /// <summary>
        /// 數值
        /// </summary>
        [DataMember]
        public decimal Value { get; set; }
        /// <summary>
        /// 資料日期
        /// </summary>
        [DataMember]
        public DateTime DataDate { get; set; }
    }
}
