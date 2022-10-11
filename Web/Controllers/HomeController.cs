using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Helpers;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private SessionsHelpers _session;
        public HomeController(ILogger<HomeController> logger, SessionsHelpers sessions)
        {
            _logger = logger;
            _session = sessions;
        }

        public IActionResult Index(ErrorModel error)
        {
            if(!_session.IsSessionActive("usuarioActivo"))
            {
               return RedirectToAction("Login", "UserAccount");
            }
            return View(error);
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