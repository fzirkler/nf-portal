using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NfProgram>()
                .HasMany(e => e.NfEvents)
                .WithOne(e => e.NfProgram)
                .HasForeignKey(e => e.NfProgramId)
                .IsRequired();
        }

        public DbSet<NfProgram> NfPrograms { get; set; }
        public DbSet<NfEvent> NfEvent { get; set; }
    }
}
