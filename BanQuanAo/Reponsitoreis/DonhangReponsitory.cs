using AutoMapper;
using BanDienThoai.Data;
using BanQuanAo.Data;
using BanQuanAo.DTO;
using BanQuanAo.Models;
using BanQuanAo.Reponsitoreis.Interface;
using Microsoft.EntityFrameworkCore;

namespace BanQuanAo.Reponsitoreis
{
    public class DonhangReponsitory:IDonhangReponsitory
    {
        private readonly BanQuanAoContext _context;
        private readonly IMapper _mapper;

        public DonhangReponsitory(BanQuanAoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<DonhangModel>> GetAllAsync()
        {
            var dh= await _context.Donhangs!.ToListAsync();
            return _mapper.Map<List<DonhangModel>>(dh);
        }
        public async Task<int> AddDonhang(DonhangModel donhangModel, IEnumerable<CTDonhangModel> chitietDonhangModels, KhachhangModel khachhangModel)
        {
            try
            {

                var khachhang = _mapper.Map<Khachhang>(khachhangModel);


                _context.Khachhangs!.Add(khachhang);
                await _context.SaveChangesAsync();


                var donhang = _mapper.Map<Donhang>(donhangModel);
                donhang.KhachhangId = khachhang.Id;
                _context.Donhangs!.Add(donhang);
                await _context.SaveChangesAsync();


                foreach (var ctDonhangModel in chitietDonhangModels)
                {
                    var ctDonhang = _mapper.Map<Chitietdonhang>(ctDonhangModel);
                    ctDonhang.DonhangId = donhang.Id;
                    _context.Chitietdonhangs!.Add(ctDonhang);
                }
                await _context.SaveChangesAsync();

                return donhang.Id;
            }
            catch (Exception ex)
            {

                throw new Exception("Failed to add order to database", ex);
            }
        }
        public async Task<CTietdonhangRequest> GetHoaDonDetailByIdAsync(int id)
        {
            var hoaDonDetail = await _context.Donhangs!
                .Include(dh => dh.Khachhang)
                .Include(dh => dh.Chitietdonhang)
                    .ThenInclude(ct => ct.Sanpham) // Include thông tin sản phẩm
                .Where(dh => dh.KhachhangId == id)
                .Select(dh => new CTietdonhangRequest
                {
                    DonhangModel = new DonhangsModel
                    {
                        Id = dh.Id,
                        Diachi = dh.Diachi,
                        Ghichu = dh.Ghichu,
                        PTthanhtoan = dh.PTthanhtoan,
                        Tongtien = dh.Tongtien,
                        Ngaydat = dh.Ngaydat,
                        KhachhangId = dh.KhachhangId
                    },
                    KhachhangModel = new KhachhangsModel
                    {
                        Id = dh.Khachhang!.Id,
                        TenKH = dh.Khachhang.TenKH,
                        Diachi = dh.Khachhang.Diachi,
                        Email = dh.Khachhang.Email,
                        SDT = dh.Khachhang.SDT
                    },
                    ChitietDonhangModels = dh.Chitietdonhang.Select(ct => new CTietDonhangModel
                    {
                        Id = ct.Id,
                        Soluong = ct.Soluong,
                        Gia = ct.Gia,
                        KichCo = ct.KichCo,
                        DonhangId = ct.DonhangId,
                        SanphamId = ct.SanphamId,
                        SanphamModel = new SanphamModel // Khởi tạo thông tin sản phẩm
                        {
                            ID = ct.Sanpham!.ID,
                            TenSP = ct.Sanpham.TenSP,
                            Anh = ct.Sanpham.Anh,
                            Mota = ct.Sanpham.Mota,
                            Gia = ct.Sanpham.Gia,
                            GiaKM = ct.Sanpham.GiaKM,
                            Trangthai = ct.Sanpham.Trangthai,
                            Danhgia = ct.Sanpham.Danhgia,
                            Ngaydang = ct.Sanpham.Ngaydang,
                            LoaiSpid = ct.Sanpham.LoaiSpid,
                            Sizeid = ct.Sanpham.Sizeid
                        }
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            return hoaDonDetail!;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingDonhang = await _context.Donhangs!.FindAsync(id);
            if (existingDonhang == null)
            {
                return false;
            }

            // Xóa các chi tiết đơn hàng liên quan
            var chitietdonhangs = _context.Chitietdonhangs!.Where(ct => ct.DonhangId == id);
            _context.Chitietdonhangs!.RemoveRange(chitietdonhangs);

            // Xóa đơn hàng
            _context.Donhangs.Remove(existingDonhang);
            await _context.SaveChangesAsync();
            return true;
        }
        

        


    }
}


