using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VPDT.Models
{
    [Table("NHACUNGCAP")]
    public class NHACUNGCAP
    {
        [Key]
        public int ID { get; set; }
        public string TENNHACUNGCAP { get; set; }
        public string SODIENTHOAI { get; set; }
        public string DIACHI { get; set; }
        public string EMAIL { get; set; }

    }
}
