using System.ComponentModel.DataAnnotations;
namespace DA_Xuong.Models
{
    public class GIOHANG
    {
        [Key]
        public int IDGIOHANG { get; set; }
        public int IDSACH { get; set; }
        public int IDNGUOIDUNG { get; set; }
        public int SOLUONG { get; set; }
    }
}
