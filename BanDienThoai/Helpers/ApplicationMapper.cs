using AutoMapper;
using BanDienThoai.Data;
using BanDienThoai.Models;

namespace BanDienThoai.Helpers
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<LoaiSp, LoaiSPModel>().ReverseMap();
            CreateMap<SanphamModel, Sanpham>().ReverseMap();
            CreateMap<DonhangModel, Donhang>().ReverseMap();
            CreateMap<CTDonhangModel, Chitietdonhang>().ReverseMap();
            CreateMap<KhachhangModel, Khachhang>().ReverseMap();

        }
    }
}
