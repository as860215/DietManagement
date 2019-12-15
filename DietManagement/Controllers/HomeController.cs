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
    }
}
