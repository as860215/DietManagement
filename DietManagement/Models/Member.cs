using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DietManagement
{
    /// <summary>
    /// 成員
    /// </summary>
    [DataContract]
    public class Member
    {
        /// <summary>
        /// 成員編號
        /// </summary>
        [DataMember]
        public string MemberId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// 性別
        /// </summary>
        [DataMember]
        public Gender? Gender { get; set; }
        /// <summary>
        /// 暱稱
        /// </summary>
        [DataMember]
        public string Nickname { get; set; }
        /// <summary>
        /// 帳號
        /// </summary>
        [DataMember]
        public string Account { get; set; }
        /// <summary>
        /// 密碼
        /// </summary>
        [DataMember]
        public string Password { get; set; }
        /// <summary>
        /// 身高
        /// </summary>
        [DataMember]
        public int? Height { get; set; }
        /// <summary>
        /// 體重
        /// </summary>
        [DataMember]
        public int? Weight { get; set; }
        /// <summary>
        /// 電話
        /// </summary>
        [DataMember]
        public string Phone { get; set; }
        /// <summary>
        /// Mail
        /// </summary>
        [DataMember]
        public string Mail { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        [DataMember]
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [DataMember]
        public string Address { get; set; }
    }
}
