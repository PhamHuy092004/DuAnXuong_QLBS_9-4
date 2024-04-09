using Microsoft.AspNetCore.Mvc;

namespace DA_Xuong.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
