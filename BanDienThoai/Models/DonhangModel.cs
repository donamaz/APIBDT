using BanDienThoai.Data;
using System.ComponentModel.DataAnnotations;

namespace BanDienThoai.Models
{
    public class DonhangModel
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string? Diachi { get; set; }
        [MaxLength(100)]
        public string? ghichu { get; set; }
        [MaxLength(100)]
        public string? PTthanhtoan { get; set; }
        [Range(0, double.MaxValue)]
        public double Tongtien { get; set; }

        public DateTime Ngaydat { get; set; }

        public DonhangModel()
        {
            // Set Ngaynhap to the current date and time when an instance is created
            Ngaydat = DateTime.Now;
        }
        public  int  Khachhangid { get; set; }
    }
    public class CTDonhangModel
    {
        public int Id { get; set; }
        [Range(0, 100)]
        public int Soluong { get; set; }

        [Range(0, double.MaxValue)]
        public double Gia { get; set; }

        public  int Donhangid { get; set; }
        public  int Sanphamid { get; set; }
    }
    public class KhachhangModel
    {
        public int Id { get; set; }
        [MaxLength(100)] // Xóa hoặc thay thế bằng RangeAttribute nếu cần
        public string? TenKH { get; set; }
        [MaxLength(100)]
        public string? Diachi { get; set; }
        [MaxLength(100)]
        public string? Email { get; set; }

        
        public String? SDT { get; set; }
    }

}
