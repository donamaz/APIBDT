using AutoMapper;
using BanDienThoai.Data;
using BanQuanAo.Data;
using BanQuanAo.Models;
using BanQuanAo.Reponsitoreis.Interface;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BanQuanAo.Reponsitoreis
{
    public class LoaiSPReponsitory : ILoaiSPReponsitory
    {
        private readonly BanQuanAoContext _context;
        private readonly IMapper _mapper;

        public LoaiSPReponsitory(BanQuanAoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddLoaissp(LoaiSPModel loaiSP)
        {
            var newLoaiSP = _mapper.Map<LoaiSP>(loaiSP);
            _context.LoaiSps!.Add(newLoaiSP);
            await _context.SaveChangesAsync();

            return newLoaiSP.ID;
        
        }

        public async Task DeleteLoaissp(int id)
        {
            var deletlsp = _context.LoaiSps!.SingleOrDefault(loaisp => loaisp.ID == id);
            if (deletlsp != null)
            {
                _context.LoaiSps!.Remove(deletlsp);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<LoaiSPModel>> GetAll()
        {
            var Loaisp = await _context.LoaiSps!.ToListAsync();
            return _mapper.Map<List<LoaiSPModel>>(Loaisp);
        }

        public async Task<LoaiSPModel> GetByid(int id)
        {
            var loaisp = await _context.LoaiSps!.FindAsync(id);
            return _mapper.Map<LoaiSPModel>(loaisp);
        }

        public async Task UpdateLoaissp(int id, LoaiSPModel loaiSP)
        {
            if (id == loaiSP.ID)
            {
                var updatelsp = _mapper.Map<LoaiSP>(loaiSP);
                _context.LoaiSps!.Update(updatelsp);
                await _context.SaveChangesAsync();
                 _mapper.Map<LoaiSPModel>(updatelsp);
            }
            
        }
    }
}
