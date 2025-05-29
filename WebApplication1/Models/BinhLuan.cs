using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class BinhLuan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NoiDung { get; set; }

        public DateTime NgayTao { get; set; }

        // Foreign keys
        public int IdBaiViet { get; set; }
        public int IdNguoiDung { get; set; }
        public int? IdBinhLuanCha { get; set; }

        // Navigation properties
        [ForeignKey("IdBaiViet")]
        [InverseProperty("BinhLuans")]
        public virtual BaiViet BaiViet { get; set; }

        [ForeignKey("IdNguoiDung")]
        [InverseProperty("BinhLuans")]
        public virtual NguoiDung NguoiDung { get; set; }

        [ForeignKey("IdBinhLuanCha")]
        public virtual BinhLuan BinhLuanCha { get; set; }
    }
}