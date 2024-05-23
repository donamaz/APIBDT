namespace BanQuanAo.Models
{
    public class DanhmucWithLoaiSPModel
    {
        public int ID { get; set; }
        public string? TenDM { get; set; }
        public List<LoaiSPModel> LoaiSPs { get; set; } = new List<LoaiSPModel>();
    }
}
