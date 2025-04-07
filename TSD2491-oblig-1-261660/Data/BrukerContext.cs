using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TSD2491_oblig_1_261660.Models;

namespace MvcBruker.Data
{
    public class BrukerContext : DbContext
    {
        public BrukerContext (DbContextOptions<BrukerContext> options)
            : base(options)
        {
        }

        public DbSet<TSD2491_oblig_1_261660.Models.Bruker> Bruker { get; set; } = default!;
    }
}
