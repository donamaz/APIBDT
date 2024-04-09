using AutoMapper;
using BanDienThoai.Data;
using BanQuanAo.Data;
using BanQuanAo.Models;
using BanQuanAo.Reponsitoreis.Interface;
using Microsoft.EntityFrameworkCore;

namespace BanQuanAo.Reponsitoreis
{
    public class SizeReponsitory : ISizeReponsitory
    {
        private readonly BanQuanAoContext _context;
        private readonly IMapper _mapper;

        public SizeReponsitory(BanQuanAoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddSize(SizeModel size)
        {
            var Size = _mapper.Map<Size>(size);
            _context.Sizes!.Add(Size);
            await _context.SaveChangesAsync();

            return Size.ID;
        }

        public async Task DeleteSize(int id)
        {
            var size = _context.Sizes!.SingleOrDefault(size => size.ID == id);
            if (size != null)
            {
                _context.Sizes!.Remove(size);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<SizeModel>> GetAll()
        {
            var size = await _context.Sizes!.ToListAsync();
            return _mapper.Map<List<SizeModel>>(size);
        }

        public async Task<SizeModel> GetByid(int id)
        {
            var size = await _context.Sizes!.FindAsync(id);
            return _mapper.Map<SizeModel>(size);
        }

        public async Task UpdateSize(int id, SizeModel size)
        {
            if (id == size.ID)
            {
                var updatesize = _mapper.Map<Size>(size);
                _context.Sizes!.Update(updatesize);
                await _context.SaveChangesAsync();
                _mapper.Map<Size>(updatesize);
            }
        }
    }
}
