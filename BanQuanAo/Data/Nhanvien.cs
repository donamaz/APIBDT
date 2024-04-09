using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BanDienThoai.Data
{
    [Table("NhanVien")]
    public class Nhanvien
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string? TenNV { get; set; }
        [MaxLength(100)]
        public string? Diachi { get; set; }
        [MaxLength(100)]
        public string? GioiTinh { get; set; } // Đã sửa thành string để lưu giới tính
        [MaxLength(100)]
        public string? Email { get; set; }
        [MaxLength(20)]
        public string? SDT { get; set; }
    }
}

