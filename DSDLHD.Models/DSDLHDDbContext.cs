using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using VPDT.Models;

namespace VPDT.Models
{
    public class VPDTDbContext : DbContext
    {

        private static readonly MethodInfo _propertyMethod = typeof(EF).GetMethod(nameof(EF.Property), BindingFlags.Static | BindingFlags.Public).MakeGenericMethod(typeof(bool));
        public VPDTDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseOracle(@"User Id=disanhd;Password=oracle;Data Source=(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = DISANHAIDUONG)));");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        public DbSet<NHACUNGCAP> TBL_Chuc_Vu { get; set; }
        public DbSet<PHIEUNHAP> PHIEUNHAP { get; set; }
        public DbSet<NGUYENLIEU> NGUYENLIEU { get; set; }
       
    }
}
