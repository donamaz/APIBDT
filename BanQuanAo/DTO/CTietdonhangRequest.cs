using BanQuanAo.Models;

namespace BanQuanAo.DTO
{
    public class CTietdonhangRequest
    {
        public DonhangsModel? DonhangModel { get; set; }
        public IEnumerable<CTietDonhangModel>? ChitietDonhangModels { get; set; }
        public KhachhangsModel? KhachhangModel { get; set; }
    }
}
