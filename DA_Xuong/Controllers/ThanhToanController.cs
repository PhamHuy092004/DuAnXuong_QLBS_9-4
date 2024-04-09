using DA_Xuong.Database;
using DA_Xuong.Models;
using Microsoft.AspNetCore.Mvc;

namespace DA_Xuong.Controllers
{
    public class ThanhToanController : Controller
    {
        private readonly ApplicationDBContext _db;

        public ThanhToanController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult ThanhToan()
        {
            var giohangitems = (from giohang in _db.GIOHANG
                                join sach in _db.SACH on giohang.IDSACH equals sach.IDSACH
                                select new GIOHANGITEMS
                                {
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
    }
}
