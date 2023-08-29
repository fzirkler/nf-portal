using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NF_Portal.Models;

namespace NF_Portal.Data
{
    public class NfContext : DbContext
    {
        public NfContext (DbContextOptions<NfContext> options)
            : base(options)
        {
        }

        public DbSet<Programm> Programme { get; set; } 
        public DbSet<Veranstaltung> Veranstaltungen { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Veranstaltung>()
                .HasOne(v => v.Programm)
                .WithMany(p => p.Veranstaltungen);
        }
    }
}
