using DA_Xuong.Database;
using Microsoft.AspNetCore.Mvc;

namespace DA_Xuong.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDBContext _dbContext;
        public AdminController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Manager() 
        {
            return View();
        }
    }
}
