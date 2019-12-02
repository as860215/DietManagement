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
            //var member = new MemberHandle().GetMember("1");
            return View(new Member());
        }
    }
}
