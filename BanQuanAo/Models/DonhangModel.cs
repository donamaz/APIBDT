using System.ComponentModel.DataAnnotations;

namespace BanQuanAo.Models
{
    public class DonhangModel
    {
        public int Id { get; set; }
        public string? Diachi { get; set; }
        public string? Ghichu { get; set; }
        public string? PTthanhtoan { get; set; }
        public double Tongtien { get; set; }
        public DateTime Ngaydat { get; set; }
        public int? KhachhangId { get; set; }

       
    }
    public class KhachhangModel
    {
        public int Id { get; set; }
        public string? TenKH { get; set; }
        public string? Diachi { get; set; }
        public string? Email { get; set; }
        public string? SDT { get; set; }
    }
    public class CTDonhangModel
    {
        public int Id { get; set; }
        public int Soluong { get; set; }
        public double Gia { get; set; }
        public string? KichCo { get; set; }
        public int DonhangId { get; set; }
        public int SanphamId { get; set; }
        
    }
}
