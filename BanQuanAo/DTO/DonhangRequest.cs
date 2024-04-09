using BanQuanAo.Models;

namespace BanQuanAo.DTO
{
    public class DonhangRequest
    {
        public DonhangModel? DonhangModel { get; set; }
        public IEnumerable<CTDonhangModel>? ChitietDonhangModels { get; set; }
        public KhachhangModel? KhachhangModel { get; set; }
        
    }
}
