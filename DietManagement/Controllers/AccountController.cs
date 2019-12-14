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
            return new JsonResult(member);
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        public IActionResult Logout()
        {
            return PartialView("");
        }

        /// <summary>
        /// 註冊
        /// </summary>
        /// <returns></returns>
        [HttpPost,Route("Registered",Name = "Account_Registered")]
        public IActionResult Registered(Member member)
        {
            new MemberHandle().InsertMember(member);
            return Ok();
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
