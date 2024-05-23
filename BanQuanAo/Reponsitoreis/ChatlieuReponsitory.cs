using AutoMapper;
using BanDienThoai.Data;
using BanQuanAo.Data;
using BanQuanAo.Models;
using BanQuanAo.Reponsitoreis.Interface;
using Microsoft.EntityFrameworkCore;

namespace BanQuanAo.Reponsitoreis
{
    public class ChatlieuReponsitory : IChatlieuReponsitory
    {
        private readonly BanQuanAoContext _context;
        private readonly IMapper _mapper;

        public ChatlieuReponsitory(BanQuanAoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddChatlieu(ChatlieuModel chatlieu)
        {
            var newcl = _mapper.Map<Chatlieu>(chatlieu);
            _context.Chatlieus!.Add(newcl);
            await _context.SaveChangesAsync();

            return newcl.id;
        }

        public async Task Deletechatlieu(int id)
        {
            var deletl = _context.Chatlieus!.SingleOrDefault(chatlieu => chatlieu.id == id);
            if (deletl != null)
            {
                _context.Chatlieus!.Remove(deletl);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ChatlieuModel>> GetAll()
        {
            var s = await _context.Chatlieus!.ToListAsync();
            return _mapper.Map<List<ChatlieuModel>>(s);
        }

        public async Task<ChatlieuModel> GetByid(int id)
        {
            var s = await _context.Chatlieus!.FindAsync(id);
            return _mapper.Map<ChatlieuModel>(s);
        }

        public async Task Updatechatlieu(int id, ChatlieuModel chatlieu)
        {
            if (id == chatlieu.id)
            {
                var updates = _mapper.Map<Chatlieu>(chatlieu);
                _context.Chatlieus!.Update(updates);
                await _context.SaveChangesAsync();
                _mapper.Map<ChatlieuModel>(updates);
            }
        }
    }
}
