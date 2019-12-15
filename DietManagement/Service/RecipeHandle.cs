using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietManagement
{
    /// <summary>
    /// 食譜
    /// </summary>
    public class RecipeHandle : DBConnect
    {
        /// <summary>
        /// 以卡路里查詢食譜
        /// </summary>
        /// <param name="max">最大值</param>
        /// <param name="min">最小值</param>
        /// <returns></returns>
        public List<Recipe> GetRecipeByCalories(int max , int min)
        {
            using (conn)
            {
                var sql = $@"select * from Recipe where Calories <= '{max}' AND Calories >= '{min}'";
                return conn.Query<Recipe>(sql).ToList();
            }
        }
    }
}
