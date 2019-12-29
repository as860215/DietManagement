using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DietManagement.Controllers
{
    /// <summary>
    /// 商店
    /// </summary>
    public class MarketController : Controller
    {
        /// <summary>
        /// 讀取商店主檔
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("MainLoad", Name = "Market_MainLoad")]
        public IActionResult MainLoad()
        {
            var market = new MarketHandle().GetMarketType();
            return PartialView("../Home/Detail/_MarketMain", market);
        }

        /// <summary>
        /// 讀取類別明細
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("DetailLoad", Name = "Market_DetailLoad")]
        public IActionResult DetailLoad(string elemantName)
        {
            var detail = new MarketHandle().GetMarketDetailByName(elemantName);
            return PartialView("../Home/Detail/_MarketDetail", detail);
        }
    }
}
