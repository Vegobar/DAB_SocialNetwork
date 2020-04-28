using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialNetworking_DAB3_handin.Models;
using SocialNetworking_DAB3_handin.Repository;
using SocialNetworking_DAB3_handin.ViewModels;

namespace SocialNetworking_DAB3_handin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsersRepository _dataAccessProvider = new UserseRespository();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(User_Login user)
        {
            if (user.IsLoggedIn)
                return View();
            else
                return Content("Fuck af, du skal logge ind!");
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
