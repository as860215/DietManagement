using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DietManagement
{
    /// <summary>
    /// 歷史資訊類別
    /// </summary>
    [DataContract]
    public enum HistoryType
    {
        [EnumMember, Description("熱量")]
        Calories = 0,
        [EnumMember, Description("體重")]
        Weight = 1
    }
}
