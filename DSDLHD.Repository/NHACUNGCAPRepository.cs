using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VPDT.Data;

using Microsoft.EntityFrameworkCore;
using VPDT.Models;

namespace VPDT.Repository
{
    public interface INHACUNGCAPRepository : IRepository<NHACUNGCAP>
    {

    }
    
    public class NHACUNGCAPRepository : Repository<NHACUNGCAP>, INHACUNGCAPRepository
    {
        public NHACUNGCAPRepository(VPDTDbContext dbContext) : base(dbContext)
        {

        }
    }

}


