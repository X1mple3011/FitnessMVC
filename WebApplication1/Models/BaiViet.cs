using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class BaiViet
    {
        public BaiViet()
        {
            BinhLuans = new HashSet<BinhLuan>();
            LikeBaiViets = new HashSet<LikeBaiViet>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string TieuDe { get; set; }

        [Required]
        public string NoiDung { get; set; }

        public string HinhAnh { get; set; }

        public DateTime NgayTao { get; set; }

        public int IdNguoiDung { get; set; }

        [ForeignKey("IdNguoiDung")]
        [InverseProperty("BaiViets")]
        public virtual NguoiDung NguoiDung { get; set; }

        public virtual ICollection<BinhLuan> BinhLuans { get; set; }

        public virtual ICollection<LikeBaiViet> LikeBaiViets { get; set; }
    }
}