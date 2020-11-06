using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace VPDT.Utils
{
    public enum StatusEnum
    {
        [Description("Tất cả trạng thái")]
        All = -1,
        [Description("Đang sử dụng")]
        Active = 1,
        [Description("Đang bị khóa")]
        Unactive = 2,
        [Description("Đang bị xóa")]
        IsDelete =3,
        [Description("Đã xóa")]
        Removed = 4
    }
    public enum DocumnetTypeEnum
    {
        Dang = 0,
        NhaNuoc = 1
    }
}
