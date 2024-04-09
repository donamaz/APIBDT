using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BanDienThoai.Data
{
    [Table("NhaCungCap")]
    public class NhaCungCap
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string? TenNCC { get; set; }
        [MaxLength(100)]
        public string? Diachi { get; set; }
        [MaxLength(100)]
        public string? Email { get; set; }
        [MaxLength(20)]
        public string? SDT { get; set; }

        public virtual ICollection<Hoadonnhap> Hoadonnhap { get; set; } = new List<Hoadonnhap>();
    }
}
