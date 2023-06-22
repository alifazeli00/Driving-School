using Application.Context;
using Domain.Coach;
using Domain.Dates;
using Domain.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class DataBaceContext:DbContext, IDataBaceContext
    {
        public DataBaceContext(DbContextOptions<DataBaceContext> option):base(option)
        {

        }

    public   DbSet<Coachs> Coachs { get; set; }
        public DbSet<BisnesCoachs> BisnesCoachs { get; set; }
        public  DbSet<DatesDrivigs> DatesDrivigs { get; set; }

        public  DbSet<BisnesUsers> BisnesUsers { get; set; }
        public DbSet<Users > Users { get; set; }
        public DbSet<Image> Image { get; set; }









        protected override void OnModelCreating(ModelBuilder builder)
        {
            // builder.Entity<Brands>().HasOne(a => a.CatalogItems).WithOne(a => a.Brand).HasForeignKey<CatalogItems>(c => c.CatalogBrandId);


            //builder.Entity<Types>().HasOne(a => a.CatalogItems).WithOne(a => a.Types).HasForeignKey<CatalogItems>(c => c.CatalogTypeId);
            //builder.Entity<CatalogItems>()
            //  .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") != false);
            builder.Entity<Users>().HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);
            builder.Entity<Coachs>().HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);
            builder.Entity<DatesDrivigs>().HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);

        }
    }
}
