using BanDienThoai.Models;

namespace BanDienThoai.Repositories.Interface
{
    public interface ISanpham
    {
        public Task<List<SanphamModel>> GetAll();
        public Task<SanphamModel> GetByid(int id);
        public Task<int> Addsanpham(SanphamModel sanpham);
        public Task Updatesanpham(int id, SanphamModel sanpham);
        public Task Deletesanpham(int id);
        public Task<List<SanphamModel>> SearchSanpham(string keyword);
        public Task<List<SanphamModel>> SearchSanphamAsync(string keyword);
        public Task<List<SanphamModel>> GetSanphamByLoaiSp(int loaiSpId);

    }
}
