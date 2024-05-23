using BanQuanAo.Models;

namespace BanQuanAo.Reponsitoreis.Interface
{
    public interface IDanhmucReponsitory
    {
        public Task<List<DanhmucModel>> GetAll();
        public Task<DanhmucModel> GetByid(int id);
        public Task<int> AddDanhmuc(DanhmucModel danhmuc);
        public Task UpdateDanhmuc(int id, DanhmucModel danhmuc);
        public Task DeleteDanhmuc(int id);
    }
}
