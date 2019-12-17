using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DietManagement
{
    /// <summary>
    /// 門市
    /// </summary>
    [DataContract]
    public enum Market
    {
        [EnumMember, Description("台北門市")]
        Taipei = 0,
        [EnumMember, Description("台中門市")]
        Taichung = 1,
        [EnumMember, Description("高雄門市")]
        Kaohsiung = 2
    }
}
