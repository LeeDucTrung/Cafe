using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VPDT.Data;

using Microsoft.EntityFrameworkCore;
using VPDT.Models;

namespace VPDT.Repository
{
    public interface ITBL_Chuc_VuRepository : IRepository<TBL_Chuc_Vu>
    {

    }
    
    public class TBL_Chuc_VuRepository : Repository<TBL_Chuc_Vu>, ITBL_Chuc_VuRepository
    {
        public TBL_Chuc_VuRepository(VPDTDbContext dbContext) : base(dbContext)
        {

        }
    }

}


