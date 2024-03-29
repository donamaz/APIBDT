using AutoMapper;
using BanDienThoai.Data;
using BanDienThoai.Models;
using BanDienThoai.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BanDienThoai.Repositories
{
    public class LoaiSPReponsitory : ILoaiSP
    {
        private readonly BandienthoaiContext _context;
        private readonly IMapper _mapper;

        public LoaiSPReponsitory(BandienthoaiContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<LoaiSPModel>> GetAll()
        {
            var Loaisp = await _context.loaiSps!.ToListAsync();
            return _mapper.Map<List<LoaiSPModel>>(Loaisp); 
        }

        public async Task<LoaiSPModel> GetByid(int id)
        {
            var loaisp =await _context.loaiSps!.FindAsync(id);
            return _mapper.Map<LoaiSPModel>(loaisp);
        }
        public  async Task<int> AddLoaissp(LoaiSPModel loaiSP)
        {
           var newloaisp =_mapper.Map<LoaiSp>(loaiSP);
            _context.loaiSps!.Add(newloaisp);
            await _context.SaveChangesAsync();
            return newloaisp.ID;
        }

        public async Task DeleteLoaissp(int id)
        {
            var deletlsp =_context.loaiSps!.SingleOrDefault(loaisp => loaisp.ID == id);
            if (deletlsp!=null) {
                _context.loaiSps!.Remove(deletlsp);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateLoaissp(int id, LoaiSPModel loaiSP)
        {
            if (id==loaiSP.ID)
            {
                var updatelsp = _mapper.Map<LoaiSp>(loaiSP);
                _context.loaiSps!.Update(updatelsp);
                await _context.SaveChangesAsync();
            }
        }
    }
}
