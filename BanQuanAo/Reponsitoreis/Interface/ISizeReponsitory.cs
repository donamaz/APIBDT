using BanQuanAo.Models;

namespace BanQuanAo.Reponsitoreis.Interface
{
    public interface ISizeReponsitory
    {
        public Task<List<SizeModel>> GetAll();
        public Task<SizeModel> GetByid(int id);
        public Task<int> AddSize(SizeModel size);
        public Task UpdateSize(int id, SizeModel size);
        public Task DeleteSize(int id);
    }
}
