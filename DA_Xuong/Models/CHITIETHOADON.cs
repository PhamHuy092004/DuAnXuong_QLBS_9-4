using System.ComponentModel.DataAnnotations;
namespace DA_Xuong.Models
{
    public class CHITIETHOADON
    {
        [Key]
        public int IDCHITIETHOADON { get; set; }
        public int IDHOADON { get; set; }
        public int IDSACH {  get; set; }
        public int SOLUONG {  get; set; }
    }
}
