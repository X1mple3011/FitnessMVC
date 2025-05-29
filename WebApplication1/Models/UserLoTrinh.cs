using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserLoTrinh
    {
        [Key]
        public int Id { get; set; }

        public int IdNguoiDung { get; set; }
        public int IdLoTrinh { get; set; }
        public DateTime NgayThamGia { get; set; }

        [ForeignKey("IdNguoiDung")]
        public virtual NguoiDung NguoiDung { get; set; }

        [ForeignKey("IdLoTrinh")]
        public virtual LoTrinh LoTrinh { get; set; }
    }
}