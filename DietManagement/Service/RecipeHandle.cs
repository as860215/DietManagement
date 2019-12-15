﻿using Dapper;
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
        /// 取得食物清單
        /// </summary>
        /// <returns></returns>
        public List<Food> GetFood()
        {
            using (conn)
            {
                var sql = $@"select * from Food";
                return conn.Query<Food>(sql).ToList();
            }
        }

        /// <summary>
        /// 透過商店編號取得食物清單
        /// </summary>
        /// <param name="shopId">商店編號</param>
        /// <returns></returns>
        public List<Food> GetFoodsByShopId(string shopId)
        {
            using (conn)
            {
                var sql = $@"select * from Food where ShopId='{shopId}'";
                return conn.Query<Food>(sql).ToList();
            }
        }

        /// <summary>
        /// 取得商店清單
        /// </summary>
        /// <returns></returns>
        public List<Shop> GetShop()
        {
            using (conn)
            {
                var sql = $@"select * from Shop";
                return conn.Query<Shop>(sql).ToList();
            }
        }
    }
}
