using DA_Xuong.Database;
using Microsoft.AspNetCore.Mvc;

namespace DA_Xuong.Areas.Customer.Controllers
{
	[Area("Customer")]
	public class CustomerController : Controller
	{
		private readonly ApplicationDBContext _dbContext;
		public CustomerController(ApplicationDBContext dbContext)
		{
			_dbContext = dbContext;
		}
		public IActionResult Index()
		{
			return View();
		}
	}
}
