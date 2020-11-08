using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VPDT.Data;

using Microsoft.EntityFrameworkCore;
using VPDT.Models;

namespace VPDT.Repository
{
    public interface IPHIEUNHAPRepository : IRepository<PHIEUNHAP>
    {

    }
    
    public class PHIEUNHAPRepository : Repository<PHIEUNHAP>, IPHIEUNHAPRepository
    {
        public PHIEUNHAPRepository(VPDTDbContext dbContext) : base(dbContext)
        {

        }
    }

}


