using BanDienThoai.Models;

namespace BanDienThoai.Repositories.Interface
{
    public interface IDonhang
    {
        public Task<int> AddDonhang(DonhangModel donhangModel, IEnumerable<CTDonhangModel> chitietDonhangModels, KhachhangModel khachhangModel);
    }
}
