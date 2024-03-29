using System.ComponentModel.DataAnnotations;

namespace BanDienThoai.Models
{
    public class SanphamModel
    {
        public int ID { get; set; }

        [MaxLength(250)]
        public string? TenSP { get; set; }

        [MaxLength(1000)]
        public string? Anh { get; set; }

        [MaxLength(1000)]
        public string? Mota { get; set; }

        [Range(0, double.MaxValue)]
        public double Gia { get; set; }

        [Range(0, double.MaxValue)]
        public double GiaKM { get; set; }

        [MaxLength(20)]
        public string? Trangthai { get; set; }

        [Range(0, 5)]
        public int Danhgia { get; set; }
        
        

        // Thêm thuộc tính để ánh xạ với LoaiSpid trong Sanpham
        public virtual int? LoaiSpid { get; set; }

    }
}
