using BanDienThoai.Models;

namespace BanDienThoai.DTO
{
    public class DonhangRequest
    {
        public DonhangModel? DonhangModel { get; set; }
        public IEnumerable<CTDonhangModel>? ChitietDonhangModels { get; set; }
        public KhachhangModel? KhachhangModel { get; set; }
    }
}
