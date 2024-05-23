using BanQuanAo.Models;

namespace BanQuanAo.Reponsitoreis.Interface
{
    public interface ISanphamReponsitory
    {
        public Task<List<SanphamModel>> GetAll();
        public Task<SanphamModel> GetByid(int id);
        public Task<int> Addsanpham(SanphamModel sanpham);
        public Task Updatesanpham(int id, SanphamModel sanpham);
        public Task Deletesanpham(int id);
        public Task<List<SanphamModel>> SearchSanpham(string keyword);
        public Task<List<SanphamModel>> SearchSanphamAsync(string keyword);
        public Task<List<SanphamModel>> GetSanphamByLoaiSp(int loaiSpId);
        public Task<List<SanphamModel>> SearchSanphamAsync(string keyword, int pageNumber, int pageSize);

        public Task<List<SanphamModel>> GetTop10KhuyenMaiAsync();
        public Task<List<SanphamModel>> GetTop10MoiNhatAsync();
    }
}
