using AutoMapper;
using BanDienThoai.Data;
using BanQuanAo.Models;
using BanQuanAo.Reponsitoreis.Interface;
using Microsoft.EntityFrameworkCore;

namespace BanQuanAo.Reponsitoreis
{
    public class HomeReponsitory: IHomeReponsitory
    {
        private readonly BanQuanAoContext _context;
        private readonly IMapper _mapper;

        public HomeReponsitory(BanQuanAoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<DanhmucModel>> GetAll()
        {
            var danhmuc = await _context.Danhmucs!
                .Where(dm => dm.TrangThai.HasValue && dm.TrangThai.Value == true) // Filter to include only records with Trangthai = 1
                .ToListAsync();

            return _mapper.Map<List<DanhmucModel>>(danhmuc);
        }
        public async Task<List<DanhmucWithLoaiSPModel>> GetCategoriesWithProductTypesAsync()
        {
            var result = await _context.Danhmucs!
                .Where(dm => dm.TrangThai == true)
                .Select(dm => new DanhmucWithLoaiSPModel
                {
                    ID = dm.ID,
                    TenDM = dm.TenDM,
                    LoaiSPs = dm.LoaiSP
                        .Where(lsp => lsp.TrangThai == true)
                        .Select(lsp => new LoaiSPModel
                        {
                            ID = lsp.ID,
                            TenLoai = lsp.TenLoai,
                            TrangThai = lsp.TrangThai,
                            Danhmucid = lsp.Danhmucid
                        })
                        .ToList()
                })
                .ToListAsync();

            return result;
        }

        public async Task<List<SanphamModel>> SearchSanpham(string keyword)
        {
            var result = await _context.Sanphams!
                .Where(p => p.TenSP!.Contains(keyword))
                .Select(p => new SanphamModel
                {
                    ID = p.ID,
                    TenSP = p.TenSP,
                    Anh = p.Anh,
                    Mota = p.Mota,
                    Gia = p.Gia,
                    GiaKM = p.GiaKM,
                    Trangthai = p.Trangthai,
                    Danhgia = p.Danhgia
                })
                .ToListAsync();

            return result;
        }

        public async Task<List<SanphamModel>> GetSanphamByLoaiSp(int loaiSpId)
        {
            var result = await _context.Sanphams!
                .Where(p => p.LoaiSpid == loaiSpId)
                .Select(p => new SanphamModel
                {
                    ID = p.ID,
                    TenSP = p.TenSP,
                    Anh = p.Anh,
                    Mota = p.Mota,
                    Gia = p.Gia,
                    GiaKM = p.GiaKM,
                    Trangthai = p.Trangthai,
                    Danhgia = p.Danhgia
                })
                .ToListAsync();

            return result;
        }

        public async Task<List<SanphamModel>> SearchSanphamAsync(string keyword)
        {
            var matchingSanphams = await _context.Sanphams!
                .Where(s => EF.Functions.Like(s.TenSP!, $"%{keyword}%"))
                .ToListAsync();
            return _mapper.Map<List<SanphamModel>>(matchingSanphams);
        }

        public async Task<List<SanphamModel>> SearchSanphamAsync(string keyword, int pageNumber, int pageSize)
        {
            var sanphams = await _context.Sanphams!
                .Where(p => EF.Functions.Like(p.TenSP!, $"%{keyword}%"))
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return _mapper.Map<List<SanphamModel>>(sanphams);
        }



        public async Task<List<SanphamModel>> GetTop10KhuyenMaiAsync()
        {
            var sanphams = await _context.Sanphams!
                 .Where(sp => sp.GiaKM > 0)
                .OrderByDescending(sp => sp.Ngaydang)
                .Take(10)
                .ToListAsync();

            return _mapper.Map<List<SanphamModel>>(sanphams);
        }



        public async Task<List<SanphamModel>> GetTop10MoiNhatAsync()
        {

            var sanphams = await _context.Sanphams!

                .OrderByDescending(sp => sp.Ngaydang)
                .Take(10)
                .ToListAsync();

            return _mapper.Map<List<SanphamModel>>(sanphams);
        }
    }
}
