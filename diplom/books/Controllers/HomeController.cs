using books;
using diplom_Dasha.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace diplom_Dasha.Controllers
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
            // ������� �������� ������
            MydbContext db = new MydbContext();
            // �������� �� �� ��� ������� Book
            var books_ = db.Books;
            // �������� ��� ������� � ������������ �������� Books � ViewBag
            ViewBag.Books = books_;
            // ���������� �������������
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        /*
        public IActionResult Entry()
        {
            return View();
        }
        */

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
