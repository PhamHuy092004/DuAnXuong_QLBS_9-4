using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DA_Xuong.Models
{
    public class CHITIETTHELOAI
    {
        [Key]
        public int IDCHITIETTHELOAI { get; set; }

        public int IDSACH { get; set; }
        public int IDLOAISACH { get; set; }

        [ForeignKey("IDSACH")]
        public SACH Sach { get; set; }

        [ForeignKey("IDLOAISACH")]
        public LOAISACH LoaiSach { get; set; }
    }
}
