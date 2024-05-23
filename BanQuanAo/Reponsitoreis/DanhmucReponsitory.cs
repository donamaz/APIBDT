using AutoMapper;
using BanDienThoai.Data;
using BanQuanAo.Data;
using BanQuanAo.Models;
using BanQuanAo.Reponsitoreis.Interface;
using Microsoft.EntityFrameworkCore;

namespace BanQuanAo.Reponsitoreis
{
    public class DanhmucReponsitory : IDanhmucReponsitory
    {
        private readonly BanQuanAoContext _context;
        private readonly IMapper _mapper;

        public DanhmucReponsitory(BanQuanAoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddDanhmuc(DanhmucModel danhmuc)
        {
            var newDanhmuc = _mapper.Map<Danhmuc>(danhmuc);
            _context.Danhmucs!.Add(newDanhmuc);
            await _context.SaveChangesAsync();

            return newDanhmuc.ID;
        }

        public async Task DeleteDanhmuc(int id)
        {
            var deletdm = _context.Danhmucs!.SingleOrDefault(loaisp => loaisp.ID == id);
            if (deletdm != null)
            {
                _context.Danhmucs!.Remove(deletdm);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<DanhmucModel>> GetAll()
        {
            var Danhmuc = await _context.Danhmucs!.ToListAsync();
            return _mapper.Map<List<DanhmucModel>>(Danhmuc);
        }

        public async Task<DanhmucModel> GetByid(int id)
        {
            var danhmuc = await _context.Danhmucs!.FindAsync(id);
            return _mapper.Map<DanhmucModel>(danhmuc);
        }

        public async Task UpdateDanhmuc(int id, DanhmucModel danhmuc)
        {
            if (id == danhmuc.ID)
            {
                var updatedm = _mapper.Map<Danhmuc>(danhmuc);
                _context.Danhmucs!.Update(updatedm);
                await _context.SaveChangesAsync();
                _mapper.Map<DanhmucModel>(updatedm);
            }
        }
    }
}
