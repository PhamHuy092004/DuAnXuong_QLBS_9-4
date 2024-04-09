using System.ComponentModel.DataAnnotations;
namespace DA_Xuong.Models
{
    public class HOADON
    {
        [Key]
        public int IDHOADON { get; set; }
        public int IDNGUOIDUNG { get; set; }
        public DateTime NGAYTAO { get; set; }
        public double TONGTIEN { get; set; }
        public string TRANGTHAI { get; set; }
    }
}
