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

        /// <summary>
        /// 更新購物車
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        [HttpPost, Route("UpdateCart", Name = "Cart_Update")]
        public IActionResult UpdateCart(Cart cart)
        {
            new CartHandle().UpdateCartDetail(cart, 1);
            return Ok("Success");
        }

        /// <summary>
        /// 根據成員編號取得其所有的購物車清單
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        [HttpPost, Route("GetTotalCart", Name = "Cart_GetTotal")]
        public IActionResult GetTotalCart(string memberId)
        {
            var carts = new CartHandle().GetCartByMemberId(memberId);
            return PartialView("../Home/Detail/_Cart", carts);
        }
    }
}
