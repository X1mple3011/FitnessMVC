using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class LikeBaiViet
    {
        [Key]
        public int Id { get; set; }

        public DateTime? NgayLike { get; set; }

        // Foreign keys
        public int IdNguoiDung { get; set; }
        public int IdBaiViet { get; set; }

        // Navigation properties
        [ForeignKey("IdNguoiDung")]
        [InverseProperty("LikeBaiViets")]
        public virtual NguoiDung NguoiDung { get; set; }

        [ForeignKey("IdBaiViet")]
        [InverseProperty("LikeBaiViets")]
        public virtual BaiViet BaiViet { get; set; }
    }
}