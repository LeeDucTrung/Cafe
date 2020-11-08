using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VPDT.Models
{
    [Table("PHIEUNHAP")]
    public class PHIEUNHAP
    {
        [Key]
        public int ID { get; set; }
        public int NHANVIENID { get; set; }
        public int NHACUNGCAPID { get; set; }
        public DateTime NGAYLAP { get; set; }
        public int TONGTIEN { get; set; }
        [NotMapped]
        public string NHACUNGCAPNAME { get; set; }

    }
  
}
