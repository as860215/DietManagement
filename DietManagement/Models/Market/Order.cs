using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DietManagement
{
    /// <summary>
    /// 訂單
    /// </summary>
    [DataContract]
    public class Order
    {
        /// <summary>
        /// 訂單編號
        /// </summary>
        [DataMember]
        public string OrderId { get; set; }
        /// <summary>
        /// 訂購人成員編號
        /// </summary>
        [DataMember]
        public string OrderMemberId { get; set; }
        /// <summary>
        /// 收件人姓名
        /// </summary>
        [DataMember]
        public string RecipientName { get; set; }
        /// <summary>
        /// 收件人電話
        /// </summary>
        [DataMember]
        public string RecipientPhone { get; set; }
        /// <summary>
        /// 收件人地址
        /// </summary>
        [DataMember]
        public string RecipientAddress { get; set; }
        /// <summary>
        /// 收件人Email
        /// </summary>
        [DataMember]
        public string RecipientMail { get; set; }
        /// <summary>
        /// 訂單細節
        /// </summary>
        [DataMember]
        public string Detail { get; set; }
        /// <summary>
        /// 訂單金額
        /// </summary>
        [DataMember]
        public int Price { get; set; }
    }
}
