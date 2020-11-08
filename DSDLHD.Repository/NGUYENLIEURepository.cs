using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VPDT.Data;

using Microsoft.EntityFrameworkCore;
using VPDT.Models;

namespace VPDT.Repository
{
    public interface INGUYENLIEURepository : IRepository<NGUYENLIEU>
    {

    }
    
    public class NGUYENLIEURepository : Repository<NGUYENLIEU>, INGUYENLIEURepository
    {
        public NGUYENLIEURepository(VPDTDbContext dbContext) : base(dbContext)
        {

        }
    }

}


