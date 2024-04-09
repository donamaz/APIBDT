using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BanDienThoai.Data
{
    [Table("New")]
    public class Baiviet
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        public string? Tieude { get; set; }
        [MaxLength(1000)]
        public string? Noidung { get; set; }
        public DateTime Ngaydang { get; set; }

        public Baiviet()
        {
            // Set Ngaydang to the current date and time when an instance is created
            Ngaydang = DateTime.Now;
        }
    }
}
