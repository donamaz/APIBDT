using AutoMapper;
using BanDienThoai.Data;
using BanQuanAo.Data;
using BanQuanAo.Models;
using BanQuanAo.Reponsitoreis.Interface;
using Microsoft.EntityFrameworkCore;

namespace BanQuanAo.Reponsitoreis
{
    public class MauReponsitory : IMauReponsitory
    {
        private readonly BanQuanAoContext _context;
        private readonly IMapper _mapper;

        public MauReponsitory(BanQuanAoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Addmau(MauModel mau)
        {
            var newcl = _mapper.Map<Mau>(mau);
            _context.Maus!.Add(newcl);
            await _context.SaveChangesAsync();

            return newcl.id;
        }

        public async Task Deletemau(int id)
        {
            var deletl = _context.Maus!.SingleOrDefault(mau => mau.id == id);
            if (deletl != null)
            {
                _context.Maus!.Remove(deletl);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<MauModel>> GetAll()
        {
            var s = await _context.Maus!.ToListAsync();
            return _mapper.Map<List<MauModel>>(s);
        }

        public async Task<MauModel> GetByid(int id)
        {
            var s = await _context.Maus!.FindAsync(id);
            return _mapper.Map<MauModel>(s);
        }

        public async Task Updatemau(int id, MauModel mau)
        {
            if (id == mau.id)
            {
                var updates = _mapper.Map<Mau>(mau);
                _context.Maus!.Update(updates);
                await _context.SaveChangesAsync();
                _mapper.Map<MauModel>(updates);
            }
        }
    }
}
