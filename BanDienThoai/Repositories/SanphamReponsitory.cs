using AutoMapper;
using BanDienThoai.Data;
using BanDienThoai.Models;
using BanDienThoai.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BanDienThoai.Repositories
{
    public class SanphamReponsitory : ISanpham
    {
        
            private readonly BandienthoaiContext _context;
            private readonly IMapper _mapper;
            private readonly ILoaiSP loaiSP;


        public SanphamReponsitory(BandienthoaiContext context, IMapper mapper, ILoaiSP loaiSP)
        {
            this._context = context;
            this._mapper = mapper;
            this.loaiSP = loaiSP;
        }

        public async Task<int> Addsanpham(SanphamModel sanpham)
        {
            var newSanpham = _mapper.Map<Sanpham>(sanpham);

            _context.sanphams!.Add(newSanpham);
            await _context.SaveChangesAsync();

            return newSanpham.ID;
        }

        public async Task Deletesanpham(int id)
        {
            var deletsp = _context.sanphams!.SingleOrDefault(Sanpham => Sanpham.ID == id);
            if (deletsp != null)
            {
                _context.sanphams!.Remove(deletsp);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<SanphamModel>> GetAll()
        {
            var sanpham = await _context.sanphams!.ToListAsync();
            return _mapper.Map<List<SanphamModel>>(sanpham);
        }

        public async Task<SanphamModel> GetByid(int id)
        {
            var sanpham = await _context.sanphams!.FindAsync(id);
            return _mapper.Map<SanphamModel>(sanpham);
        }

       

        public async Task Updatesanpham(int id, SanphamModel sanpham)
        {
            if (id == sanpham.ID)
            {
                var updatesp = _mapper.Map<Sanpham>(sanpham);
                _context.sanphams!.Update(updatesp);
                await _context.SaveChangesAsync();
            }
        }



        public async Task<List<SanphamModel>> SearchSanpham(string keyword)
        {
            var result = await _context.sanphams!
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
            var result = await _context.sanphams!
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
            var matchingSanphams = await _context.sanphams!
                .Where(s => EF.Functions.Like(s.TenSP!, $"%{keyword}%"))
                .ToListAsync();
            return _mapper.Map<List<SanphamModel>>(matchingSanphams);
        }

    }
}
