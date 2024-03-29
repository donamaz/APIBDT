using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BanDienThoai.Data
{
    [Table("CTdonhang")]
    public class Chitietdonhang
    {
        [Key]
        public int Id { get; set; }
        [Range(0, 100)]
        public int Soluong { get; set; }

        [Range(0, double.MaxValue)]
        public double Gia { get; set; }


        
        public virtual int? Donhangid { get; set; }     
        public virtual int? Sanphamid { get; set; }
    }
}
