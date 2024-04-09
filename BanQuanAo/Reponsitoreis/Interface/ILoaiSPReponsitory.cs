using BanQuanAo.Models;

namespace BanQuanAo.Reponsitoreis.Interface
{
    public interface ILoaiSPReponsitory
    {
        public Task<List<LoaiSPModel>> GetAll();
        public Task<LoaiSPModel> GetByid(int id);
        public Task<int> AddLoaissp(LoaiSPModel loaiSP);
        public Task UpdateLoaissp(int id, LoaiSPModel loaiSP);
        public Task DeleteLoaissp(int id);
    }
}
