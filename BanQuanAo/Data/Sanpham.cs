using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BanDienThoai.Data;

namespace BanQuanAo.Data
{
    [Table("Sanpham")]
    public class Sanpham
    {
        [Key]
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
        public bool? Trangthai { get; set; }
        [Range(0, 5)]
        public int Danhgia { get; set; }
        public DateTime Ngaydang { get; set; }

        public Sanpham()
        {
            // Set Ngaydang to the current date and time when an instance is created
            Ngaydang = DateTime.Now;
        }

        public virtual int? LoaiSpid { get; set; }

        public virtual LoaiSP LoaiSP { get; set; } // Khóa ngoại tham chiếu đến bảng LoaiSP

        public virtual int? Sizeid { get; set; }

        public virtual Size? Size { get; set; } // Khóa ngoại tham chiếu đến bảng Sanpham
        public virtual ICollection<Chitietdonnhap> Chitietdonnhap { get; set; } // Danh sách các chi tiết đơn nhập của sản phẩm
        public virtual ICollection<Chitietdonhang> Chitietdonhang { get; set; } // Danh sách các chi tiết đơn hàng của sản phẩm

    }
}
