using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OlimpicsWebApi.Repositories.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlimpicsWebApi.Repositories.Core
{
    public class BaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public BaseContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<User>()
                .ToTable("User");

            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Coins);

        }
    }
}
