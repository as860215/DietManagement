using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DietManagement.Models;

namespace DietManagement.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// 登入
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return PartialView("");
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
        public IActionResult Registered()
        {
            return PartialView("");
        }

        /// <summary>
        /// 使用者資訊
        /// </summary>
        /// <returns></returns>
        public IActionResult User()
        {
            return PartialView("");
        }
    }
}
