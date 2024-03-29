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
        public double Tongtien{ get; set; }

        public DateTime Ngaynhap { get; set; }

        public Hoadonnhap()
        {
            // Set Ngaynhap to the current date and time when an instance is created
            Ngaynhap = DateTime.Now;
        }


        
        public virtual NhaCungCap? NhaCungCapid { get; set; }



        public virtual IEnumerable<Chitietdonnhap> Chitietdonnhap { get; set; } = new List<Chitietdonnhap>();
        
    }
}
