using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VPDT.Models
{
    [Table("NGUYENLIEU")]
    public class NGUYENLIEU
    {
        [Key]
        public int ID { get; set; }
        public string TENNGUYENLIEU { get; set; }
        public int SOLUONG { get; set; }
        public string DONVITINH { get; set; }

    }
  
}
