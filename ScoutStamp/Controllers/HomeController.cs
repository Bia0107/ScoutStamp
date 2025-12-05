using System.Diagnostics;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc;
using ScoutStamp.Models;

namespace ScoutStamp.Controllers
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

        public IActionResult Produto()
        {
            return View();
        }

        public IActionResult Fornecedor()
        {
            return View();
        }

        public IActionResult Pedido()
        {
            return View();
        }

        public IActionResult Cliente()
        {
            return View();
        }

        public IActionResult Login()
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
