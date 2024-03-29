using AutoMapper;
using BanDienThoai.Data;
using BanDienThoai.Models;
using BanDienThoai.Repositories.Interface;

namespace BanDienThoai.Repositories
{
    public class DonhangReponsitory : IDonhang
    {
        private readonly BandienthoaiContext _context;
        private readonly IMapper _mapper;

        public DonhangReponsitory(BandienthoaiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddDonhang(DonhangModel donhangModel, IEnumerable<CTDonhangModel> chitietDonhangModels, KhachhangModel khachhangModel)
        {
            try
            {
                
                var khachhang = _mapper.Map<Khachhang>(khachhangModel);

                
                _context.khachhangs!.Add(khachhang);
                await _context.SaveChangesAsync();

                
                var donhang = _mapper.Map<Donhang>(donhangModel);
                donhang.Khachhangid = khachhang.Id;
                _context.donhangs!.Add(donhang);
                await _context.SaveChangesAsync();

               
                foreach (var ctDonhangModel in chitietDonhangModels)
                {
                    var ctDonhang = _mapper.Map<Chitietdonhang>(ctDonhangModel);
                    ctDonhang.Donhangid = donhang.Id;
                    _context.chitietdonhangs!.Add(ctDonhang);
                }
                await _context.SaveChangesAsync();

                return donhang.Id;
            }
            catch (Exception ex)
            {
             
                throw new Exception("Failed to add order to database", ex);
            }
        }

    }
}
