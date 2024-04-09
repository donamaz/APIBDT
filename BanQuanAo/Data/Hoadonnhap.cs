using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BanDienThoai.Data
{
    [Table("Hoadonnhap")]
    public class Hoadonnhap
    {
        [Key]
        public int Id { get; set; }

        [Range(0, double.MaxValue)]
        public double Tongtien { get; set; }

        public DateTime Ngaynhap { get; set; }

        public int? NhaCungCapId { get; set; }
        public virtual NhaCungCap? NhaCungCap { get; set; }

        public virtual ICollection<Chitietdonnhap> Chitietdonnhap { get; set; } = new List<Chitietdonnhap>();

    }
}
