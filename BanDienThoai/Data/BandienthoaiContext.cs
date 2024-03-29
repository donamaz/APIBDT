using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BanDienThoai.Data
{
    public class BandienthoaiContext:IdentityDbContext<ApplicationUser>
    {
        public BandienthoaiContext(DbContextOptions<BandienthoaiContext> otp) : base(otp)
        {

        }
        public DbSet<LoaiSp>? loaiSps { get; set; }
        public DbSet<Sanpham>? sanphams { get; set; }
        public DbSet<NhaCungCap>? nhaCungCaps { get; set; }
        public DbSet<Nhanvien>? nhanviens { get; set; }
        public DbSet<Hoadonnhap>? hoadonnhaps { get; set; }
        public DbSet<Chitietdonnhap>? chitietdonnhaps { get; set; }
        public DbSet<Donhang>? donhangs { get; set; }
        public DbSet<Chitietdonhang>? chitietdonhangs { get; set; }
       
        public DbSet<Baiviet>? baiviets { get; set; }
        public DbSet<Khachhang>? khachhangs { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}
