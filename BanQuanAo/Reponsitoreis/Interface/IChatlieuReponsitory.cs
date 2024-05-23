using BanQuanAo.Models;

namespace BanQuanAo.Reponsitoreis.Interface
{
    public interface IChatlieuReponsitory
    {
        public Task<List<ChatlieuModel>> GetAll();
        public Task<ChatlieuModel> GetByid(int id);
        public Task<int> AddChatlieu(ChatlieuModel chatlieu);
        public Task Updatechatlieu(int id, ChatlieuModel chatlieu);
        public Task Deletechatlieu(int id);
    }
}
