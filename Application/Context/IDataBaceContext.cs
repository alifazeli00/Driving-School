using Domain.Coach;
using Domain.Dates;
using Domain.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Context
{
    public interface IDataBaceContext
    {
        DbSet<ListDatesTeory> ListDatesTeory { get; set; }
        DbSet<Image> Image { get; set; }
        DbSet<Users> Users { get; set; }
        DbSet<Coachs> Coachs { get; set; }
       DbSet<DatesDrivigs> DatesDrivigs { get; set; }
        DbSet<BisnesUsers> BisnesUsers { get; set; }
        DbSet<DatesTeory> DatesTeory { get; set; }
        DbSet<BisnesCoachs> BisnesCoachs { get; set; }

        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
