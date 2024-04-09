using System.ComponentModel.DataAnnotations;
namespace DA_Xuong.Models
{
    public class CHITIETTHELOAI
    {
    [Key]
        public int IDCHITIETTHELOAI {  get; set; }
        public int IDSACH {  get; set; }
        public int IDTHELOAI { get; set; }
    }
}
