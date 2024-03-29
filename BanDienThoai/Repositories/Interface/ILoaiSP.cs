using BanDienThoai.Models;

namespace BanDienThoai.Repositories.Interface
{
    public interface ILoaiSP
    {
        public Task<List<LoaiSPModel>> GetAll();
        public Task<LoaiSPModel> GetByid(int id);
        public Task<int> AddLoaissp(LoaiSPModel loaiSP);
        public Task UpdateLoaissp(int id,LoaiSPModel loaiSP);
        public Task DeleteLoaissp(int id);
    }
}
