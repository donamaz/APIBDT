using BanQuanAo.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BanDienThoai.Data
{
    [Table("Chitietdonnhap")]
    public class Chitietdonnhap
    {
        [Key]
        public int Id { get; set; }
        [Range(0, 100)]
        public int Soluong { get; set; }

        [Range(0, double.MaxValue)]
        public double Gia { get; set; }

        public int? HoadonnhapId { get; set; }
        public virtual Hoadonnhap? Hoadonnhap { get; set; }

        public int? SanphamId { get; set; }
        public virtual Sanpham? Sanpham { get; set; }
    }
}
