using BanDienThoai.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BanDienThoai.Data
{
    [Table("Sanpham")]
    public class Sanpham
    {
        [Key]
        public int ID { get; set; }

        [MaxLength (250)]
        public string? TenSP { get; set; }
        [MaxLength (1000)]
        public string? Anh { get; set; }
        [MaxLength(1000)]
        public string? Mota { get; set; }
        [Range(0,double.MaxValue)]
        public double Gia { get; set; }
        [Range(0, double.MaxValue)]
        public double GiaKM { get; set; }
        [MaxLength(20)]
        public string? Trangthai { get; set; }
        [Range(0,5)]
        public int Danhgia { get; set; }
       



        public virtual  int? LoaiSpid { get; set; }



        public virtual IEnumerable<Chitietdonnhap> Chitietdonnhap { get; set; } = new List<Chitietdonnhap>();
        public virtual IEnumerable<Chitietdonhang> Chitietdonhang { get; set; } = new List<Chitietdonhang>();
       
    }
}
