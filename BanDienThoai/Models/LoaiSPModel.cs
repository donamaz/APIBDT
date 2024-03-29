using System.ComponentModel.DataAnnotations;

namespace BanDienThoai.Models
{
    public class LoaiSPModel
    {
       
        public int ID { get; set; }
        [MaxLength(100)]
        public string? TenLoai { get; set; }
        [MaxLength(30)]
        public string? TrangThai { get; set; }
    }
}
