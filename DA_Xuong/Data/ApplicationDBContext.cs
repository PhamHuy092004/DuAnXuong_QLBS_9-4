using DA_Xuong.Models;
using Microsoft.EntityFrameworkCore;

namespace DA_Xuong.Database
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<SACH> SACH { get; set; }
        public DbSet<LOAISACH> LOAISACH { get; set;}
        public DbSet<TACGIA> TACGIA { get; set;}
        public DbSet<CHITIETTHELOAI> CHITIETTHELOAI { get; set; }
        public DbSet<CHITIETHINHANH> CHITIETHINHANH { get; set; }
        public DbSet<GIOHANG> GIOHANG { get; set; }
        public DbSet<TAIKHOAN> TAIKHOAN { get; set; } 
    }
}
