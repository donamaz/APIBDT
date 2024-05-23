using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BanQuanAo.Data
{
    [Table("Danhmuc")]
    public class Danhmuc
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(100)]
        public string? TenDM { get; set; }
        [MaxLength(30)]
        public bool? TrangThai { get; set; }

        


        public virtual ICollection<LoaiSP> LoaiSP { get; set; } = new List<LoaiSP>();
    }
}
