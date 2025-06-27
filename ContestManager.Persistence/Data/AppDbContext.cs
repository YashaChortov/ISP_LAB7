using ContestManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ContestManager.Persistence.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Contest> Contests { get; set; }
        public DbSet<Participant> Participants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contest>()
                .HasMany(c => c.Participants)
                .WithOne(p => p.Contest)
                .HasForeignKey(p => p.ContestId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}