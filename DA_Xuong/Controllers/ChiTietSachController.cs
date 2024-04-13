using DA_Xuong.Database;
using DA_Xuong.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

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
            var sachList = _db.SACH.ToList(); 

            ViewBag.sachList = sachList;    

            return View(sach);
        }
        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            var ss = HttpContext.Session.GetInt32("IDNGUOIDUNG");

            if (ss == null)
            {
                // Người dùng không đăng nhập, lưu ID sản phẩm vào session
                var cart = HttpContext.Session.Get<List<int>>("Cart") ?? new List<int>();
                if (!cart.Contains(id))
                {
                    cart.Add(id);
                    HttpContext.Session.Set("Cart", cart);
                    TempData["SuccessMessage"] = "Sản phẩm đã được thêm vào giỏ hàng thành công.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Sản phẩm đã có trong giỏ hàng.";
                }
            }
            else
            {
                // Người dùng đã đăng nhập, lưu sản phẩm vào cơ sở dữ liệu
                var existingItem = _db.GIOHANG.FirstOrDefault(item => item.IDSACH == id && item.IDNGUOIDUNG == ss);
                if (existingItem == null)
                {
                    GIOHANG newItem = new GIOHANG
                    {
                        IDSACH = id,
                        SOLUONG = 1,
                        IDNGUOIDUNG = (int)ss
                    };
                    _db.GIOHANG.Add(newItem);
                    _db.SaveChanges();
                    TempData["SuccessMessage"] = "Sản phẩm đã được thêm vào giỏ hàng thành công.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Sản phẩm đã có trong giỏ hàng.";
                }
            }

            return RedirectToAction("ChiTietSach", new { id = id });
        }



    }
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }

}
