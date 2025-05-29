using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class BaiTap
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string TenBaiTap { get; set; }

        public string MoTa { get; set; }

        [StringLength(200)]
        public string VideoUrl { get; set; }

        public virtual ICollection<LoTrinh_BaiTap> LoTrinh_BaiTaps { get; set; }
    }
}