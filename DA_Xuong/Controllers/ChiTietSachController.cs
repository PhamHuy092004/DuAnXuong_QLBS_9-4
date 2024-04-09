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
            if (existingItem != null)
            {
                existingItem.SOLUONG += 1;
                _db.SaveChanges();
            }
            else
            {
                GIOHANG newItem = new GIOHANG
                {
                    IDSACH = id,
                    SOLUONG = 1,
                    IDNGUOIDUNG = 1
                };
                _db.GIOHANG.Add(newItem);
                _db.SaveChanges();
            }

            return RedirectToAction("ChiTietSach", new { id = id });
        }

    }
}
