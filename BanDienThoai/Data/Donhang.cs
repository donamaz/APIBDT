using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BanDienThoai.Data
{
    [Table("Donhang")]
    public class Donhang
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string? Diachi { get; set; }
        [MaxLength(100)]
        public string? ghichu { get; set; }
        [MaxLength(100)]
        public string? PTthanhtoan{ get; set; }
        [Range(0, double.MaxValue)]
        public double Tongtien { get; set; }

        public DateTime Ngaydat { get; set; }

        public Donhang()
        {
            // Set Ngaynhap to the current date and time when an instance is created
            Ngaydat = DateTime.Now;
        }





     
        public virtual int? Khachhangid { get; set; }



        
        public virtual IEnumerable<Chitietdonhang> Chitietdonhang { get; set; } = new List<Chitietdonhang>();
    }
}
