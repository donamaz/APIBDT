using BanDienThoai.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BanQuanAo.Data
{
    [Table("Mau")]
    public class Mau
    {
        [Key]
        public int id { get; set; }
        [MaxLength(100)]
        public string? Maus { get; set; } 
        [MaxLength(20)]
        public bool? TrangThai { get; set; }

        public virtual ICollection<Sanpham> Sanphams { get; set; }
        public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; }
    }
}
