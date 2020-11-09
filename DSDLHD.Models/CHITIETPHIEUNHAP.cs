using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CAFE.Models
{
    [Table("CHITIETPHIEUNHAP")]
    public class CHITIETPHIEUNHAP
    {
        [Key]
        public int ID { get; set; }
        public int PHIEUNHAPID { get; set; }
        public int NGUYENLIEUID { get; set; }
        public int SOLUONG { get; set; }
        public int DONGIA { get; set; }
    }
}
