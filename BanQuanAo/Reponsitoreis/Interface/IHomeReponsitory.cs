using BanQuanAo.Models;

namespace BanQuanAo.Reponsitoreis.Interface
{
    public interface IHomeReponsitory
    {
        public Task<List<DanhmucModel>> GetAll();
        Task<List<DanhmucWithLoaiSPModel>> GetCategoriesWithProductTypesAsync();
        public Task<List<SanphamModel>> SearchSanpham(string keyword);
        public Task<List<SanphamModel>> SearchSanphamAsync(string keyword);
        public Task<List<SanphamModel>> GetSanphamByLoaiSp(int loaiSpId);
        public Task<List<SanphamModel>> SearchSanphamAsync(string keyword, int pageNumber, int pageSize);

        public Task<List<SanphamModel>> GetTop10KhuyenMaiAsync();
        public Task<List<SanphamModel>> GetTop10MoiNhatAsync();
    }
}
