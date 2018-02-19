//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Com.KiddoPay.Clients.Mvc.Frontend.Models;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Authentication;

//namespace Com.KiddoPay.Clients.Mvc.Frontend.Controllers
//{
//    public class LogoutController : Controller
//    {
//        public IActionResult Index()
//        {
//            return View();
//        }

//        public IActionResult About()
//        {
//            ViewData["Message"] = "Your application description page.";

//            return View();
//        }

//        public IActionResult Contact()
//        {
//            ViewData["Message"] = "Your contact page.";

//            return View();
//        }

//        [Authorize]
//        public IActionResult Claims()
//        {
//            ViewData["Message"] = "Your Claims Page.";

//            return View();
//        }
//        public async Task<IActionResult> Logout()
//        {
//            await HttpContext.SignOutAsync("Cookies");
//            await HttpContext.SignOutAsync("oidc");
//            return new SignOutResult(new string[] { "Cookies", "oidc" });
//        }

//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }
//    }
//}
