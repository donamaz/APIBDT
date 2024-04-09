﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BanQuanAo.Data
{
    [Table("Loaisp")]
    public class LoaiSP
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(100)]
        public string? TenLoai { get; set; }
        [MaxLength(30)]
        public bool? TrangThai { get; set; }




        public virtual ICollection<Sanpham> Sanpham { get; set; } = new List<Sanpham>();
    }
}