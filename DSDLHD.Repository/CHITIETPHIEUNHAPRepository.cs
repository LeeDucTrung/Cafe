using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VPDT.Data;

using Microsoft.EntityFrameworkCore;
using VPDT.Models;
using CAFE.Models;

namespace VPDT.Repository
{
    public interface ICHITIETPHIEUNHAPRepository : IRepository<CHITIETPHIEUNHAP>
    {

    }
    
    public class CHITIETPHIEUNHAPRepository : Repository<CHITIETPHIEUNHAP>, ICHITIETPHIEUNHAPRepository
    {
        public CHITIETPHIEUNHAPRepository(VPDTDbContext dbContext) : base(dbContext)
        {

        }
    }

}


