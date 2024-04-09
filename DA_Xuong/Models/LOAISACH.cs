using System.ComponentModel.DataAnnotations;

namespace DA_Xuong.Models
{
    public class LOAISACH
    {
        [Key]
        public int IDLOAISACH { get; set; }
        public string TENLOAISACH { get; set; }

    }
}
