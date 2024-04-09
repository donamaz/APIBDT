namespace BanQuanAo.Models
{
    public class SanphamModel
    {
        public int ID { get; set; }
        public string? TenSP { get; set; }
        public string? Anh { get; set; }
        public string? Mota { get; set; }
        public double Gia { get; set; }
        public double GiaKM { get; set; }
        public bool? Trangthai { get; set; }
        public int Danhgia { get; set; }
        public DateTime Ngaydang { get; set; }
        public int? LoaiSpid { get; set; }
        public int? Sizeid { get; set; }
    }
 
}
