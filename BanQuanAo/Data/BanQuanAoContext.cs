using BanQuanAo.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BanDienThoai.Data
{
    public class BanQuanAoContext : IdentityDbContext<ApplicationUser>
    {
        public BanQuanAoContext(DbContextOptions<BanQuanAoContext> options) : base(options)
        {

        }

        public DbSet<LoaiSP>? LoaiSps { get; set; }
        public DbSet<Sanpham>? Sanphams { get; set; }
        public DbSet<NhaCungCap>? NhaCungCaps { get; set; }
        public DbSet<Nhanvien>? Nhanviens { get; set; }
        public DbSet<Hoadonnhap>? Hoadonnhaps { get; set; }
        public DbSet<Chitietdonnhap>? Chitietdonnhaps { get; set; }
        public DbSet<Donhang>? Donhangs { get; set; }
        public DbSet<Chitietdonhang>? Chitietdonhangs { get; set; }
        public DbSet<Baiviet>? Baiviets { get; set; }
        public DbSet<Khachhang>? Khachhangs { get; set; }
        public DbSet<Size>? Sizes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Sanpham>()
                .HasOne(s => s.LoaiSP)
                .WithMany(l => l.Sanpham)
                .HasForeignKey(s => s.LoaiSpid);



            modelBuilder.Entity<Chitietdonhang>()
                .HasOne(c => c.Donhang)
                .WithMany(d => d.Chitietdonhang)
                .HasForeignKey(c => c.DonhangId);

            modelBuilder.Entity<Chitietdonhang>()
                .HasOne(c => c.Sanpham)
                .WithMany(s => s.Chitietdonhang)
                .HasForeignKey(c => c.SanphamId);

            modelBuilder.Entity<Chitietdonnhap>()
                .HasOne(c => c.Hoadonnhap)
                .WithMany(h => h.Chitietdonnhap)
                .HasForeignKey(c => c.HoadonnhapId);

            modelBuilder.Entity<Chitietdonnhap>()
                .HasOne(c => c.Sanpham)
                .WithMany(s => s.Chitietdonnhap)
                .HasForeignKey(c => c.SanphamId);
            modelBuilder.Entity<Donhang>()
               .HasOne(d => d.Khachhang)
               .WithMany(k => k.Donhang)
               .HasForeignKey(d => d.KhachhangId);
            modelBuilder.Entity<Hoadonnhap>()
                .HasOne(h => h.NhaCungCap)
                .WithMany(n => n.Hoadonnhap)
                .HasForeignKey(h => h.NhaCungCapId);
            modelBuilder.Entity<Sanpham>()
    .HasOne(s => s.Size) // Một size chỉ thuộc về một sản phẩm
    .WithMany(sp => sp.Sanphams) // Một sản phẩm có thể có nhiều size
    .HasForeignKey(s => s.Sizeid); // Khóa ngoại của bảng Size tham chiếu đến bảng Sanpham

        }
    }
}
