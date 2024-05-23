using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BanQuanAo.Data
{
    [Table("Chatlieu")]
    public class Chatlieu
    {
        [Key]
        public int id { get; set; }
        [MaxLength(100)]
        public string? Chatlieus{ get; set; } // Đổi tên size thành KichCo để tránh từ khóa
        [MaxLength(20)]
        public bool? TrangThai { get; set; }

        public virtual ICollection<Sanpham> Sanphams { get; set; } // Một sản phẩm có thể có nhiều kích cỡ
    }
}
