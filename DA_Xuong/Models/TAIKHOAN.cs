using System.ComponentModel.DataAnnotations;
namespace DA_Xuong.Models
{
    public class TAIKHOAN
    {
        [Key]
        public int IDNGUOIDUNG { get; set; }
        public string TENTAIKHOAN { get; set; }
        public string MATKHAU {  get; set; }
        public int VAITRO {  get; set; }
        public string HOVATEN { get; set; }
        public string SODIENTHOAI { get; set; }
        public string DIACHI {  get; set; }
        public string HINHANH { get; set; }
        public string GIOITINH { get; set; }
        public int TRANGTHAI { get; set; }
    }
}
