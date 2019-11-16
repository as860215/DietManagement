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
    public class Member
    {
        /// <summary>
        /// 成員編號
        /// </summary>
        public string MemmberId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 性別
        /// </summary>
        public bool Gender { get; set; }
        /// <summary>
        /// 暱稱
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// 帳號
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 身高
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// 體重
        /// </summary>
        public int Weight { get; set; }
        /// <summary>
        /// 電話
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Mail
        /// </summary>
        public string Mail { get; set; }
    }
}
