using BanQuanAo.DTO;
using BanQuanAo.Models;

namespace BanQuanAo.Reponsitoreis.Interface
{
    public interface IDonhangReponsitory
    {
        public Task<IEnumerable<DonhangModel>> GetAllAsync();
        public Task<int> AddDonhang(DonhangModel donhangModel, IEnumerable<CTDonhangModel> chitietDonhangModels, KhachhangModel khachhangModel);
        
        public Task<CTietdonhangRequest> GetHoaDonDetailByIdAsync(int id);
        public Task<bool> DeleteAsync(int id);
       
      
    }
}
