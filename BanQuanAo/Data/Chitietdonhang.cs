using BanQuanAo.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BanDienThoai.Data
{
    [Table("CTdonhang")]
    public class Chitietdonhang
    {
        [Key]
        public int Id { get; set; }
        [Range(0, 100)]
        public int Soluong { get; set; }

        [Range(0, double.MaxValue)]
        public double Gia { get; set; }
        [MaxLength(100)]
        public string? KichCo { get; set; } // Đổi tên size thành KichCo để tránh từ khóa
        public int DonhangId { get; set; }
        public virtual Donhang? Donhang { get; set; }

        public int SanphamId { get; set; }
        public virtual Sanpham? Sanpham { get; set; }
    }
}
