using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;

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

        /// <summary>
        /// 加入成員清單SON
        /// </summary>
        [DataMember]
        public string MemberJoinJson { get; set; }

        /// <summary>
        /// 加入成員清單
        /// </summary>
        public MemberJoin MemberJoins
        {
            get => JsonConvert.DeserializeObject<MemberJoin>(MemberJoinJson ?? "");
            set => JsonConvert.SerializeObject(value);
        }
    }
    /// <summary>
    /// 加入成員清單JSON用
    /// </summary>
    public class MemberJoin
    {
        [DataMember]
        public List<string> MemberId { get; set; }
    }
}
