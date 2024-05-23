using AutoMapper;
using BanDienThoai.Data;
using BanQuanAo.Data;
using BanQuanAo.Models;
using BanQuanAo.Reponsitoreis.Interface;
using Microsoft.EntityFrameworkCore;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace BanQuanAo.Reponsitoreis
{
    public class SanphamReponsitory : ISanphamReponsitory
    {
        private readonly BanQuanAoContext _context;
        private readonly IMapper _mapper;
        private readonly ILoaiSPReponsitory loaiSP;


        public SanphamReponsitory(BanQuanAoContext context, IMapper mapper, ILoaiSPReponsitory loaiSP)
        {
            this._context = context;
            this._mapper = mapper;
            this.loaiSP = loaiSP;
        }

        public async Task<int> Addsanpham(SanphamModel sanpham)
        {
           
            var newSanpham = _mapper.Map<Sanpham>(sanpham);
            _context.Sanphams!.Add(newSanpham);
            await _context.SaveChangesAsync();

            return newSanpham.ID;
        }

        public async Task Deletesanpham(int id)
        {
            var deletsp = _context.Sanphams!.SingleOrDefault(Sanpham => Sanpham.ID == id);
            if (deletsp != null)
            {
                _context.Sanphams!.Remove(deletsp);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<SanphamModel>> GetAll()
        {
            var sanpham = await _context.Sanphams!.ToListAsync();
            return _mapper.Map<List<SanphamModel>>(sanpham);
        }

        public async Task<SanphamModel> GetByid(int id)
        {
            var sanpham = await _context.Sanphams!.FindAsync(id);
            return _mapper.Map<SanphamModel>(sanpham);
        }



        public async Task Updatesanpham(int id, SanphamModel sanpham)
        {
            if (id == sanpham.ID)
            {
                var updatesp = _mapper.Map<Sanpham>(sanpham);
                _context.Sanphams!.Update(updatesp);
                await _context.SaveChangesAsync();
            }
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
