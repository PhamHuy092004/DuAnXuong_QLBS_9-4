using System.ComponentModel.DataAnnotations;
namespace DA_Xuong.Models
{
    public class Project
    {
        [Key]
        public int ID_Sach { get; set; }
        public string HinhAnh { get; set; }
        public string TenSach { get; set; }
        public string TacGia { get; set; }
        public int GiaSach { get; set; }
        public string LoaiSach { get; set; }
        public string MoTa { get; set; }
    }
}
