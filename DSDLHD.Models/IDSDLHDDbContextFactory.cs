using VPDT.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace VPDT.Models
{

    public interface IVPDTDbContextFactory : IDbContextFactory<VPDTDbContext>
    {

    }
    public class VPDTDbContextFactory : IVPDTDbContextFactory
    {
        private readonly DbContextOptions<VPDTDbContext> _options;
        private VPDTDbContext _context;
        public VPDTDbContextFactory(DbContextOptions<VPDTDbContext> options)
        {
            _options = options;
        }
        public VPDTDbContext GetContext()
        {
            if (_context == null) _context = new VPDTDbContext(_options);
            return _context;
        }
    }
}
