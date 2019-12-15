using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DietManagement.Models;

namespace DietManagement.Controllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="Account">帳號</param>
        /// <param name="Password">密碼</param>
        /// <returns></returns>
        [HttpPost, Route("Login", Name = "Account_Login")]
        public IActionResult Login(string Account,string Password)
        {
            var member = new MemberHandle().Login(Account, Password);
            if(member == null)
            {
                return new JsonResult(null);
            }
            return PartialView("../Home/Account/_loginSuccess", member);
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("Logout", Name = "Account_Logout")]
        public IActionResult Logout()
        {
            return PartialView("../Home/Account/_logoutSuccess");
        }

        /// <summary>
        /// 註冊
        /// </summary>
        /// <returns></returns>
        [HttpPost,Route("Registered",Name = "Account_Registered")]
        public IActionResult Registered(Member member)
        {
            var checkAccount = new MemberHandle().CheckAccount(member.Account);
            if(checkAccount == true)
            {
                return new JsonResult(new { fail= "Account duplicate" });
            }
            new MemberHandle().InsertMember(member);
            return PartialView("../Home/Account/_registeredSuccess");
        }

        /// <summary>
        /// 追蹤
        /// </summary>
        /// <returns></returns>
        public IActionResult Track()
        {
            return PartialView("");
        }
    }
}
