using BanDienThoai.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BanQuanAo.Data
{
    [Table("Size")]
    public class Size
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(100)]
        public string? KichCo { get; set; } // Đổi tên size thành KichCo để tránh từ khóa

        

        public virtual ICollection<Sanpham> Sanphams { get; set; } // Một sản phẩm có thể có nhiều kích cỡ
        public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; }

    }
}
