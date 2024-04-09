using System.ComponentModel.DataAnnotations;

namespace DA_Xuong.Models
{
    public class CHITIETHINHANH
    {
        [Key]
        public int IDHINHANH { get; set; }
        public int IDSACH {  get; set; }
        public string HINHANH { get; set; }
    }
}
