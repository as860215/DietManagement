using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DietManagement
{
    /// <summary>
    /// 性別
    /// </summary>
    [DataContract]
    public enum Gender
    {
        [EnumMember, Description("男生")]
        Man = 0,
        [EnumMember, Description("女生")]
        Woman = 1
    }
}
