using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class LoTrinh_BaiTap
    {
        [Key]
        public int Id { get; set; }

        public int IdLoTrinh { get; set; }
        public virtual LoTrinh LoTrinh { get; set; }

        public int IdBaiTap { get; set; }
        public virtual BaiTap BaiTap { get; set; }
    }
}