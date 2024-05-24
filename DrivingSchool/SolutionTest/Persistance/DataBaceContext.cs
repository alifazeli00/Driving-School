using app;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class DataBaceContext:DbContext, IDataBaceContext
    {
        public DataBaceContext(DbContextOptions<DataBaceContext> option) : base(option)
        {

        }
      
        public DbSet<Users> Users { get; set; }
    }
}
