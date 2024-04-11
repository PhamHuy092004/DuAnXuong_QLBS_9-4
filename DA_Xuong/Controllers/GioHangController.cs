using DA_Xuong.Database;
using DA_Xuong.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DA_Xuong.Controllers
{
    public class GioHangController : Controller
    {
        private readonly ApplicationDBContext _db;
        public GioHangController(ApplicationDBContext db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult UpdateQuantity(int productId, int quantity)
        {
            var product = _db.SACH.FirstOrDefault(p => p.IDSACH == productId);

            if (product == null)
            {
                return NotFound();
            }

            // Update the quantity of the product in the cart
            var cartItem = _db.GIOHANG.FirstOrDefault(item => item.IDSACH == productId);
            if (cartItem != null)
            {
                cartItem.SOLUONG = quantity;
                _db.SaveChanges();
            }

            return RedirectToAction("Index", "GioHang");
        }

        public IActionResult Index()
        {
            var giohangitems = (from giohang in _db.GIOHANG
                                join sach in _db.SACH on giohang.IDSACH equals sach.IDSACH
                                join tacgia in _db.TACGIA on sach.IDTACGIA equals tacgia.IDTACGIA
                                select new GIOHANGITEMS
                                {
                                    TENTACGIA = tacgia.TENTACGIA,
                                    IDGIOHANG = giohang.IDGIOHANG,
                                    IDSACH = giohang.IDSACH,
                                    TIEUDE = sach.TIEUDE,
                                    HINHANH = sach.HINHANH,
                                    GIA = sach.GIA,
                                    SOLUONG = giohang.SOLUONG,
                                    TONG = giohang.SOLUONG * sach.GIA
                                }).ToList();

            return View(giohangitems);
        }
        [HttpPost]
        public IActionResult XoaSanPham(int maSanPham)
        {
            var sanPham = _db.GIOHANG.FirstOrDefault(item => item.IDSACH == maSanPham);
            if (sanPham != null)
            {
                _db.GIOHANG.Remove(sanPham);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
