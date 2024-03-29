using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BanDienThoai.Data
{
    [Table("NhanVien")]
    public class Nhanvien
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(100)]
        public string? TenNV { get; set; }
        [MaxLength(100)]
        public int Diachi { get; set; }
        [MaxLength(100)]
        public int GioiTinh { get; set; }
        [MaxLength(100)]
        public int Email { get; set; }
        [MaxLength(20)]
        public int SDT { get; set; }
    }
}

