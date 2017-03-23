using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OlimpicsWebApi.Repositories.Core.Entity;
using System.Linq;

namespace OlimpicsWebApi.Repositories.Core.Context
{
    public class BaseContext :DbContext
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
                 .Property(u => u.Username)
                 .HasMaxLength(50)
                 .IsRequired();

            modelBuilder.Entity<User>()
                  .Property(u => u.Coins);



        }


    }
}
