using DA_Xuong.Database;
using DA_Xuong.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DA_Xuong.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDBContext _dbContext;
        public AccountController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            
            var ss = HttpContext.Session.GetInt32("IDNGUOIDUNG");
            if (ss != null)
            {
                return RedirectToAction("Index", "Sale");
            }
            else
            {
                var db = _dbContext.TAIKHOAN.ToList();
                return View(db);
            }
        }

        [HttpPost]
        public IActionResult Login(string emaildn, string matKhaudn)
        {
            var user = _dbContext.TAIKHOAN.FirstOrDefault(u => u.TENTAIKHOAN == emaildn && u.MATKHAU == matKhaudn);
            if (user != null)
            {
                if (user.VAITRO != 2)
                {
                    // Xác thực thành công
                    HttpContext.Session.SetString("TENTAIKHOAN", user.TENTAIKHOAN);
                    HttpContext.Session.SetInt32("IDNGUOIDUNG", user.IDNGUOIDUNG);
                    return RedirectToAction("Index", "Home");
                    //return RedirectToAction("Index", "Customer", new { area = "Customer" });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Email hoặc mật khẩu không đúng.");
                    return View("Index", "Account");
                }
            }
            else
            {
                // Xác thực không thành công, thiết lập thông báo lỗi và trả về view Login
                ModelState.AddModelError(string.Empty, "Email hoặc mật khẩu không đúng.");
                return View("Index", "Account");
            }
        }

        [HttpPost]
        public IActionResult CreateAccount(string email, string matKhau, string xacNhanMatKhau)
        {
            if (ModelState.IsValid)
            {
                if (matKhau != xacNhanMatKhau)
                {
                    ModelState.AddModelError("xacNhanMatKhau", "Mật khẩu xác nhận không trùng khớp");
                    return View("Index", "Account");
                }
                if (_dbContext.TAIKHOAN.Any(tk => tk.TENTAIKHOAN == email))
                {
                    ModelState.AddModelError("email", "Tên tài khoản đã tồn tại. Vui lòng chọn tên khác!");
                    return View("Index", "Account");
                }

                var tk = new TAIKHOAN
                {
                    TENTAIKHOAN = email,
                    MATKHAU = matKhau,
                    VAITRO = 0,
                    HOVATEN = null,
                    SODIENTHOAI = null,
                    DIACHI = null,
                    HINHANH = null,
                    GIOITINH = null,
                    TRANGTHAI = 1
                };
                _dbContext.TAIKHOAN.Add(tk);
                try
                {
                    // Thực hiện các thao tác thay đổi trên cơ sở dữ liệu
                    _dbContext.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    // Truy cập inner exception để biết chi tiết lỗi
                    var innerException = ex.InnerException;
                    while (innerException != null)
                    {
                        ViewBag.ErrorMessage = innerException.Message;
                        innerException = innerException.InnerException;
                    }
                    // Xử lý lỗi cụ thể tại đây nếu cần
                    return View("Index", "Account");
                    // Xử lý lỗi cụ thể tại đây nếu cần
                }

                return RedirectToAction("Index", "Home");
            }
            return View("Index", "Home");
        }
    }
}
