using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class NguoiDung
    {
        public NguoiDung()
        {
            BaiViets = new HashSet<BaiViet>();
            BinhLuans = new HashSet<BinhLuan>();
            LikeBaiViets = new HashSet<LikeBaiViet>();
            ChiSoBMIs = new HashSet<ChiSoBMI>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string TenDangNhap { get; set; }

        [Required]
        [StringLength(100)]
        public string MatKhau { get; set; }

        [Required]
        [StringLength(100)]
        public string HoTen { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(20)]
        public string SoDienThoai { get; set; }

        public DateTime NgaySinh { get; set; }

        public string HinhAnh { get; set; }

        public int IdPhanQuyen { get; set; }

        [ForeignKey("IdPhanQuyen")]
        public virtual PhanQuyen PhanQuyen { get; set; }

        // Navigation properties
        public virtual ICollection<BaiViet> BaiViets { get; set; }
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }
        public virtual ICollection<LikeBaiViet> LikeBaiViets { get; set; }
        public virtual ICollection<ChiSoBMI> ChiSoBMIs { get; set; }
    }
}