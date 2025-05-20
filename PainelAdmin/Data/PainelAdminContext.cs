using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PainelAdmin.Models;

namespace PainelAdmin.Data
{
    public class PainelAdminContext : DbContext
    {
        public PainelAdminContext (DbContextOptions<PainelAdminContext> options)
            : base(options)
        {
        }

        public DbSet<PainelAdmin.Models.Pet> Pet { get; set; } = default!;
        public DbSet<PainelAdmin.Models.Noticia> Noticia { get; set; } = default!;
    }
}
