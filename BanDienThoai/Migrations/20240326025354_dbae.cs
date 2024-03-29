using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BanDienThoai.Migrations
{
    public partial class dbae : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hoadonnhap_NhaCungCap_NhaCungCapId",
                table: "Hoadonnhap");

            migrationBuilder.DropForeignKey(
                name: "FK_Sanpham_Loaisp_LoaiSpID",
                table: "Sanpham");

            migrationBuilder.DropColumn(
                name: "IDLSP",
                table: "Sanpham");

            migrationBuilder.DropColumn(
                name: "IDNCC",
                table: "Hoadonnhap");

            migrationBuilder.DropColumn(
                name: "IDDH",
                table: "CTdonhang");

            migrationBuilder.DropColumn(
                name: "IDSP",
                table: "CTdonhang");

            migrationBuilder.DropColumn(
                name: "IDDHN",
                table: "Chitietdonnhap");

            migrationBuilder.DropColumn(
                name: "IDSP",
                table: "Chitietdonnhap");

            migrationBuilder.RenameColumn(
                name: "LoaiSpID",
                table: "Sanpham",
                newName: "LoaiSpidID");

            migrationBuilder.RenameIndex(
                name: "IX_Sanpham_LoaiSpID",
                table: "Sanpham",
                newName: "IX_Sanpham_LoaiSpidID");

            migrationBuilder.RenameColumn(
                name: "NhaCungCapId",
                table: "Hoadonnhap",
                newName: "NhaCungCapidId");

            migrationBuilder.RenameIndex(
                name: "IX_Hoadonnhap_NhaCungCapId",
                table: "Hoadonnhap",
                newName: "IX_Hoadonnhap_NhaCungCapidId");

            migrationBuilder.RenameColumn(
                name: "Ten",
                table: "AspNetUsers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Ho",
                table: "AspNetUsers",
                newName: "FirstName");

            migrationBuilder.AddForeignKey(
                name: "FK_Hoadonnhap_NhaCungCap_NhaCungCapidId",
                table: "Hoadonnhap",
                column: "NhaCungCapidId",
                principalTable: "NhaCungCap",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sanpham_Loaisp_LoaiSpidID",
                table: "Sanpham",
                column: "LoaiSpidID",
                principalTable: "Loaisp",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hoadonnhap_NhaCungCap_NhaCungCapidId",
                table: "Hoadonnhap");

            migrationBuilder.DropForeignKey(
                name: "FK_Sanpham_Loaisp_LoaiSpidID",
                table: "Sanpham");

            migrationBuilder.RenameColumn(
                name: "LoaiSpidID",
                table: "Sanpham",
                newName: "LoaiSpID");

            migrationBuilder.RenameIndex(
                name: "IX_Sanpham_LoaiSpidID",
                table: "Sanpham",
                newName: "IX_Sanpham_LoaiSpID");

            migrationBuilder.RenameColumn(
                name: "NhaCungCapidId",
                table: "Hoadonnhap",
                newName: "NhaCungCapId");

            migrationBuilder.RenameIndex(
                name: "IX_Hoadonnhap_NhaCungCapidId",
                table: "Hoadonnhap",
                newName: "IX_Hoadonnhap_NhaCungCapId");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "Ten");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "AspNetUsers",
                newName: "Ho");

            migrationBuilder.AddColumn<int>(
                name: "IDLSP",
                table: "Sanpham",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IDNCC",
                table: "Hoadonnhap",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IDDH",
                table: "CTdonhang",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IDSP",
                table: "CTdonhang",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IDDHN",
                table: "Chitietdonnhap",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IDSP",
                table: "Chitietdonnhap",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Hoadonnhap_NhaCungCap_NhaCungCapId",
                table: "Hoadonnhap",
                column: "NhaCungCapId",
                principalTable: "NhaCungCap",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sanpham_Loaisp_LoaiSpID",
                table: "Sanpham",
                column: "LoaiSpID",
                principalTable: "Loaisp",
                principalColumn: "ID");
        }
    }
}
