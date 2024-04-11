using DA_Xuong.Database;
using DA_Xuong.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DA_Xuong.Controllers
{
    public class ChiTietSachController : Controller
    {
        private readonly ApplicationDBContext _db;

        public ChiTietSachController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult ChiTietSach(int id)
        {
            var sach = _db.SACH
                .Include(s => s.TacGia)
                .FirstOrDefault(s => s.IDSACH == id);

            if (sach == null)
            {
                return NotFound(); 
            }

            return View(sach);
        }
        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            var existingItem = _db.GIOHANG.FirstOrDefault(item => item.IDSACH == id);
            if (existingItem == null)
            {
                // Item doesn't exist, so add it to the cart
                GIOHANG newItem = new GIOHANG
                {
                    IDSACH = id,
                    SOLUONG = 1,
                    IDNGUOIDUNG = 1 // You may need to change this depending on your user authentication logic
                };
                _db.GIOHANG.Add(newItem);
                _db.SaveChanges();
                TempData["SuccessMessage"] = "Sản phẩm đã được thêm vào giỏ hàng thành công.";
            }
            else
            {
                TempData["ErrorMessage"] = "Sản phẩm đã có trong giỏ hàng.";
            }

            return RedirectToAction("ChiTietSach", new { id = id });

        }

    }
}
