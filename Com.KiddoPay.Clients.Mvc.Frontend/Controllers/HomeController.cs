using Com.KiddoPay.Clients.Mvc.Frontend.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Com.KiddoPay.Clients.Mvc.Frontend.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [Authorize]
        public IActionResult Claims()
        {
            ViewData["Message"] = "Your Claims Page.";

            return View();
        }

        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var discoveryClient = new DiscoveryClient("http://localhost:5000");
            var doc = await discoveryClient.GetAsync();

            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var client = new HttpClient();
            client.SetBearerToken(accessToken);
            var content = await client.GetStringAsync(doc.UserInfoEndpoint);

            ViewBag.Json = JObject.Parse(content).ToString();

            return View();
        }

        public IActionResult Logout()
        {
            //await HttpContext.SignOutAsync("Cookies");
            //await HttpContext.SignOutAsync("oidc");
            return new SignOutResult(new[] { "Cookies", "oidc" });
            //return new SignOutResult(new string[] { "Cookies", "oidc" });
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
