using BanQuanAo.Models;

namespace BanQuanAo.Reponsitoreis.Interface
{
    public interface IMauReponsitory
    {
        public Task<List<MauModel>> GetAll();
        public Task<MauModel> GetByid(int id);
        public Task<int> Addmau(MauModel mau);
        public Task Updatemau(int id, MauModel mau);
        public Task Deletemau(int id);
    }
}
