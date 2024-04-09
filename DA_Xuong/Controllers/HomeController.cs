using DA_Xuong.Database;
using DA_Xuong.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DA_Xuong.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDBContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDBContext db)
        {
            _logger = logger;
            _db = db;
        }
        
        public IActionResult Index()
        {
            List<SACH> projects = _db.SACH.ToList();
          
            return View(projects);
           
        }
        
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult SanPham() {
            List<SACH> sachs = _db.SACH.Include(s => s.TacGia).ToList();
            return View(sachs);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
