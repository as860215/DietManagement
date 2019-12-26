using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DietManagement.Models;

namespace DietManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new Member());
        }

        /// <summary>
        /// 根據取得商店內的食物清單
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("GetShopFoods", Name = "Home_GetShopFoods")]
        public IActionResult GetShopFoods(string shopId)
        {
            var foods = new FoodHandle().GetFoodsByShopId(shopId);
            if (foods.Count == 0)
                return new JsonResult(null);
            return PartialView("../Home/Detail/_FoodSearchShopFood", foods);
        }

        /// <summary>
        /// 查詢食譜
        /// </summary>
        /// <param name="calories">查詢的卡路里</param>
        /// <returns></returns>
        [HttpPost, Route("GetRecipe", Name = "Home_GetRecipe")]
        public IActionResult GetRecipe(int calories)
        {
            var recipe = new RecipeHandle().GetRecipeByCalories(calories + 200, calories - 200);
            if (recipe.Count == 0)
                return new JsonResult(null);
            var recipeDic = recipe.ToDictionary(n => n.RecipeId, n => n);
            var foodDic = new Dictionary<string, List<Food>>();
            recipe.ForEach(n =>
            {
                foodDic.Add(n.RecipeId, new List<Food>());
                n.Foods.FoodId.ForEach(m => {
                    var food = new FoodHandle().GetFoodById(m);
                    foodDic[n.RecipeId].Add(food);
                });
            });

            return PartialView("../Home/Detail/_RecipeResult", (recipeDic, foodDic));
        }

        /// <summary>
        /// 建立指定門市與日期的運動
        /// </summary>
        /// <param name="sport"></param>
        /// <returns></returns>
        [HttpPost, Route("CreateSport", Name = "Home_CreateSport")]
        public IActionResult CreateSport(Sport sport)
        {
            //預設將自己加入
            sport.MemberJoinJson = Newtonsoft.Json.JsonConvert.SerializeObject(new MemberJoin() { MemberId = new List<string>() { sport.MemberId } });
            new SportHandle().InsertSport(sport);
            return new JsonResult(new { sportDate = sport.SportDate.ToString("yyyy/MM/dd"), sportTime = sport.SportDate.ToString("HH") });
        }

        /// <summary>
        /// 搜尋指定門市與日期的運動資料
        /// </summary>
        /// <param name="market">門市</param>
        /// <param name="date">日期</param>
        /// <param name="userId">登入人ID</param>
        /// <returns></returns>
        [HttpPost, Route("SearchSport", Name = "Home_SearchSport")]
        public IActionResult SearchSport(Market market, DateTime date,string userId)
        {
            var sports = new SportHandle().GetSport(market, date);
            return PartialView("../Home/Detail/_SportResult", (sports,userId));
        }

        /// <summary>
        /// 加入別人的運動
        /// </summary>
        /// <param name="sportId"></param>
        /// <param name="userId">登入人ID</param>
        /// <returns></returns>
        [HttpPost, Route("JoinSport", Name = "Home_JoinSport")]
        public IActionResult JoinSport(string sportId, string userId)
        {
            new SportHandle().JoinSport(sportId, userId);
            return Ok();
        }
    }
}
