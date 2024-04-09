using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BanDienThoai.Data
{
    [Table("Donhang")]
    public class Donhang
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string? Diachi { get; set; }
        [MaxLength(100)]
        public string? Ghichu { get; set; }
        [MaxLength(100)]
        public string? PTthanhtoan { get; set; }
        [Range(0, double.MaxValue)]
        public double Tongtien { get; set; }

        public DateTime Ngaydat { get; set; }

        public int? KhachhangId { get; set; }
        public virtual Khachhang? Khachhang { get; set; }

        public virtual ICollection<Chitietdonhang> Chitietdonhang { get; set; } = new List<Chitietdonhang>();
    }
}
