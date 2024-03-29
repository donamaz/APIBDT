using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BanDienThoai.Migrations
{
    public partial class BanDienThoai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Khachhang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKH = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Diachi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SDT = table.Column<int>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khachhang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Loaisp",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loaisp", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "New",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tieude = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Noidung = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Ngaydang = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_New", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhaCungCap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNCC = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Diachi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SDT = table.Column<int>(type: "int", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaCungCap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNV = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Diachi = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    GioiTinh = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Email = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    SDT = table.Column<int>(type: "int", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.ID);
                });

           

           

            migrationBuilder.CreateTable(
                name: "Donhang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diachi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ghichu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PTthanhtoan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tongtien = table.Column<double>(type: "float", nullable: false),
                    Ngaydat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    
                    KhachhangId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donhang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donhang_Khachhang_KhachhangId",
                        column: x => x.KhachhangId,
                        principalTable: "Khachhang",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sanpham",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSP = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Anh = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Gia = table.Column<double>(type: "float", nullable: false),
                    GiaKM = table.Column<double>(type: "float", nullable: false),
                    Trangthai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Danhgia = table.Column<int>(type: "int", nullable: false),
                    
                    LoaiSpID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sanpham", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sanpham_Loaisp_LoaiSpID",
                        column: x => x.LoaiSpID,
                        principalTable: "Loaisp",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Hoadonnhap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tongtien = table.Column<double>(type: "float", nullable: false),
                    Ngaynhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    
                    NhaCungCapId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoadonnhap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hoadonnhap_NhaCungCap_NhaCungCapId",
                        column: x => x.NhaCungCapId,
                        principalTable: "NhaCungCap",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CTdonhang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Soluong = table.Column<int>(type: "int", nullable: false),
                    Gia = table.Column<double>(type: "float", nullable: false),
                   
                    DonhangId = table.Column<int>(type: "int", nullable: true),
                   
                    SanphamID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTdonhang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CTdonhang_Donhang_DonhangId",
                        column: x => x.DonhangId,
                        principalTable: "Donhang",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CTdonhang_Sanpham_SanphamID",
                        column: x => x.SanphamID,
                        principalTable: "Sanpham",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Chitietdonnhap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Soluong = table.Column<int>(type: "int", nullable: false),
                    Gia = table.Column<double>(type: "float", nullable: false),
                    
                    HoadonnhapId = table.Column<int>(type: "int", nullable: true),
                    
                    SanphamID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chitietdonnhap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chitietdonnhap_Hoadonnhap_HoadonnhapId",
                        column: x => x.HoadonnhapId,
                        principalTable: "Hoadonnhap",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Chitietdonnhap_Sanpham_SanphamID",
                        column: x => x.SanphamID,
                        principalTable: "Sanpham",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chitietdonnhap_HoadonnhapId",
                table: "Chitietdonnhap",
                column: "HoadonnhapId");

            migrationBuilder.CreateIndex(
                name: "IX_Chitietdonnhap_SanphamID",
                table: "Chitietdonnhap",
                column: "SanphamID");

            migrationBuilder.CreateIndex(
                name: "IX_CTdonhang_DonhangId",
                table: "CTdonhang",
                column: "DonhangId");

            migrationBuilder.CreateIndex(
                name: "IX_CTdonhang_SanphamID",
                table: "CTdonhang",
                column: "SanphamID");

            migrationBuilder.CreateIndex(
                name: "IX_Donhang_KhachhangId",
                table: "Donhang",
                column: "KhachhangId");

            migrationBuilder.CreateIndex(
                name: "IX_Hoadonnhap_NhaCungCapId",
                table: "Hoadonnhap",
                column: "NhaCungCapId");

            migrationBuilder.CreateIndex(
                name: "IX_Sanpham_LoaiSpID",
                table: "Sanpham",
                column: "LoaiSpID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chitietdonnhap");

            migrationBuilder.DropTable(
                name: "CTdonhang");

            migrationBuilder.DropTable(
                name: "New");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "Hoadonnhap");

            migrationBuilder.DropTable(
                name: "Donhang");

            migrationBuilder.DropTable(
                name: "Sanpham");

            migrationBuilder.DropTable(
                name: "NhaCungCap");

            migrationBuilder.DropTable(
                name: "Khachhang");

            migrationBuilder.DropTable(
                name: "Loaisp");
        }
    }
}
