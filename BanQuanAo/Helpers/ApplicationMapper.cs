using AutoMapper;
using BanDienThoai.Data;
using BanQuanAo.Data;
using BanQuanAo.Models;


namespace BanDienThoai.Helpers
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<LoaiSP, LoaiSPModel>().ReverseMap();
            CreateMap<Sanpham, SanphamModel>().ReverseMap();
            CreateMap<Size, SizeModel>().ReverseMap();
            CreateMap<Donhang, DonhangModel>().ReverseMap();
            CreateMap<Khachhang, KhachhangModel>().ReverseMap();
            CreateMap<Chitietdonhang, CTDonhangModel>().ReverseMap();
        }
    }
}
