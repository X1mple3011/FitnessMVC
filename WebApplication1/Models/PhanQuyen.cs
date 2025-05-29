using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PhanQuyen
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string TenQuyen { get; set; }
    }
}