using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ChiSoBMI
    {
        [Key]
        public int Id { get; set; }

        public double ChieuCao { get; set; }

        public double CanNang { get; set; }

        public double BMI { get; set; }

        public DateTime? NgayCapNhat { get; set; }

        public DateTime NgayTao { get; set; }

        // Foreign key
        public int IdNguoiDung { get; set; }

        // Navigation property
        [ForeignKey("IdNguoiDung")]
        [InverseProperty("ChiSoBMIs")]
        public virtual NguoiDung NguoiDung { get; set; }

        public ChiSoBMI()
        {
            NgayCapNhat = DateTime.Now;
        }
    }
}