using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BanDienThoai.Migrations
{
    public partial class asd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CTdonhang_Donhang_DonhangId",
                table: "CTdonhang");

            migrationBuilder.DropForeignKey(
                name: "FK_CTdonhang_Sanpham_SanphamID",
                table: "CTdonhang");

            migrationBuilder.DropForeignKey(
                name: "FK_Donhang_Khachhang_KhachhangId",
                table: "Donhang");

            migrationBuilder.DropForeignKey(
                name: "FK_Sanpham_Loaisp_LoaiSpidID",
                table: "Sanpham");

            migrationBuilder.DropColumn(
                name: "IDKH",
                table: "Donhang");

            migrationBuilder.RenameColumn(
                name: "LoaiSpidID",
                table: "Sanpham",
                newName: "LoaiSpid");

            migrationBuilder.RenameIndex(
                name: "IX_Sanpham_LoaiSpidID",
                table: "Sanpham",
                newName: "IX_Sanpham_LoaiSpid");

            migrationBuilder.RenameColumn(
                name: "KhachhangId",
                table: "Donhang",
                newName: "KhachhangidId");

            migrationBuilder.RenameIndex(
                name: "IX_Donhang_KhachhangId",
                table: "Donhang",
                newName: "IX_Donhang_KhachhangidId");

            migrationBuilder.RenameColumn(
                name: "SanphamID",
                table: "CTdonhang",
                newName: "SanphamidID");

            migrationBuilder.RenameColumn(
                name: "DonhangId",
                table: "CTdonhang",
                newName: "DonhangidId");

            migrationBuilder.RenameIndex(
                name: "IX_CTdonhang_SanphamID",
                table: "CTdonhang",
                newName: "IX_CTdonhang_SanphamidID");

            migrationBuilder.RenameIndex(
                name: "IX_CTdonhang_DonhangId",
                table: "CTdonhang",
                newName: "IX_CTdonhang_DonhangidId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Ngaydat",
                table: "Sanpham",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_CTdonhang_Donhang_DonhangidId",
                table: "CTdonhang",
                column: "DonhangidId",
                principalTable: "Donhang",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CTdonhang_Sanpham_SanphamidID",
                table: "CTdonhang",
                column: "SanphamidID",
                principalTable: "Sanpham",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Donhang_Khachhang_KhachhangidId",
                table: "Donhang",
                column: "KhachhangidId",
                principalTable: "Khachhang",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sanpham_Loaisp_LoaiSpid",
                table: "Sanpham",
                column: "LoaiSpid",
                principalTable: "Loaisp",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CTdonhang_Donhang_DonhangidId",
                table: "CTdonhang");

            migrationBuilder.DropForeignKey(
                name: "FK_CTdonhang_Sanpham_SanphamidID",
                table: "CTdonhang");

            migrationBuilder.DropForeignKey(
                name: "FK_Donhang_Khachhang_KhachhangidId",
                table: "Donhang");

            migrationBuilder.DropForeignKey(
                name: "FK_Sanpham_Loaisp_LoaiSpid",
                table: "Sanpham");

            migrationBuilder.DropColumn(
                name: "Ngaydat",
                table: "Sanpham");

            migrationBuilder.RenameColumn(
                name: "LoaiSpid",
                table: "Sanpham",
                newName: "LoaiSpidID");

            migrationBuilder.RenameIndex(
                name: "IX_Sanpham_LoaiSpid",
                table: "Sanpham",
                newName: "IX_Sanpham_LoaiSpidID");

            migrationBuilder.RenameColumn(
                name: "KhachhangidId",
                table: "Donhang",
                newName: "KhachhangId");

            migrationBuilder.RenameIndex(
                name: "IX_Donhang_KhachhangidId",
                table: "Donhang",
                newName: "IX_Donhang_KhachhangId");

            migrationBuilder.RenameColumn(
                name: "SanphamidID",
                table: "CTdonhang",
                newName: "SanphamID");

            migrationBuilder.RenameColumn(
                name: "DonhangidId",
                table: "CTdonhang",
                newName: "DonhangId");

            migrationBuilder.RenameIndex(
                name: "IX_CTdonhang_SanphamidID",
                table: "CTdonhang",
                newName: "IX_CTdonhang_SanphamID");

            migrationBuilder.RenameIndex(
                name: "IX_CTdonhang_DonhangidId",
                table: "CTdonhang",
                newName: "IX_CTdonhang_DonhangId");

            migrationBuilder.AddColumn<int>(
                name: "IDKH",
                table: "Donhang",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CTdonhang_Donhang_DonhangId",
                table: "CTdonhang",
                column: "DonhangId",
                principalTable: "Donhang",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CTdonhang_Sanpham_SanphamID",
                table: "CTdonhang",
                column: "SanphamID",
                principalTable: "Sanpham",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Donhang_Khachhang_KhachhangId",
                table: "Donhang",
                column: "KhachhangId",
                principalTable: "Khachhang",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sanpham_Loaisp_LoaiSpidID",
                table: "Sanpham",
                column: "LoaiSpidID",
                principalTable: "Loaisp",
                principalColumn: "ID");
        }
    }
}
