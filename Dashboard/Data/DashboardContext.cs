using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dashboard.Models;

namespace Dashboard.Data
{
    public class DashboardContext : DbContext
    {
        public DashboardContext (DbContextOptions<DashboardContext> options)
            : base(options)
        {
        }

        public DbSet<Dashboard.Models.Pet> Pet { get; set; } = default!;
        public DbSet<Dashboard.Models.Noticia> Noticia { get; set; } = default!;
    }
}
