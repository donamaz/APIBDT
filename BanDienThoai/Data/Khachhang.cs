using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BanDienThoai.Data
{
    [Table("Khachhang")]
    public class Khachhang
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string? TenKH { get; set; }
        [MaxLength(100)]
        public string? Diachi { get; set; }
        [MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(20)]
        public string? SDT { get; set; }


        public virtual IEnumerable<Donhang> Donhang { get; set; } = new List<Donhang>();
    }
}
