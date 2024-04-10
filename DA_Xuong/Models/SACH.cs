using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DA_Xuong.Models
{
    public class SACH
    {
        [Key]
        public int IDSACH {  get; set; }
        public string TIEUDE { get; set; }
        public int IDTACGIA { get; set; }
        public double GIA { get; set; }
        public DateTime NGAYXUATBAN { get; set; }
        public string MOTA { get; set; }
        public int SOLUONG { get; set; }
        public string TRANGTHAI { get; set; }
        public string HINHANH { get; set; }

        [ForeignKey("IDTACGIA")] 
        public TACGIA TacGia { get; set; } 
    }
}
