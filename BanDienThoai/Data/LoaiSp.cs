using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BanDienThoai.Data
{
    [Table("Loaisp")]
    public class LoaiSp
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(100)]
        public string? TenLoai { get; set; }
        [MaxLength(30)]
        public string? TrangThai { get; set; }




        public virtual IEnumerable<Sanpham> Sanpham { get; set; }=new List<Sanpham>(); 
    }
}
