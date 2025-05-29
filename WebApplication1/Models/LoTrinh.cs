using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class LoTrinh
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string TenLoTrinh { get; set; }

        public string MoTa { get; set; }

        public double BMI { get; set; }

        public virtual ICollection<LoTrinh_BaiTap> LoTrinh_BaiTaps { get; set; }
    }
}