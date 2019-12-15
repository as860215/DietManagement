using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace DietManagement
{
    /// <summary>
    /// 食譜
    /// </summary>
    [DataContract]
    public class Recipe
    {
        /// <summary>
        /// 食譜編號
        /// </summary>
        [DataMember]
        public string RecipeId { get; set; }
        /// <summary>
        /// 熱量
        /// </summary>
        [DataMember]
        public int Calories { get; set; }
        /// <summary>
        /// 食物清單JSON
        /// </summary>
        [DataMember]
        public string FoodsJson{ get; set; }

        /// <summary>
        /// 食物清單
        /// </summary>
        public RecipeFood Foods
        {
            get => JsonConvert.DeserializeObject<RecipeFood>(FoodsJson);
            set => JsonConvert.SerializeObject(value);
        }
    }
    /// <summary>
    /// 食物清單JSON用
    /// </summary>
    public class RecipeFood
    {
        public List<string> FoodId { get; set; }
    }
}
