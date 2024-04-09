using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace DA_Xuong.Models
{
    public class GIOHANGITEMS
    {
        [Key]
        public int IDGIOHANG { get; set; }
        public int IDSACH { get; set; }
        public int IDNGUOIDUNG { get; set; }
        public int SOLUONG { get; set; }
        public string TIEUDE { get; set; }
        public string HINHANH { get; set; }
        public double GIA { get; set; }
        public double TONG { get; set; }
    }
}
