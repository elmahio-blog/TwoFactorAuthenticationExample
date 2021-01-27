using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using TwoFactorAuthenticationExample.Models;

namespace TwoFactorAuthenticationExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            if (CurrentUser.PreviousUser != null)
            {
                if (CurrentUser.PreviousUser.TwoFactorEnabled)
                {
                    return Redirect("/twofactorauthentication/authorize");
                }
                else
                {
                    CurrentUser.SignedInUser = CurrentUser.PreviousUser;
                }
            }
            else
            {
                CurrentUser.SignedInUser = new CurrentUser { Email = "foo@bar.com", TwoFactorEnabled = false };
            }

            return Redirect("/");
        }

        public IActionResult Logout()
        {
            CurrentUser.PreviousUser = CurrentUser.SignedInUser;
            CurrentUser.SignedInUser = null;
            return Redirect("/");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
