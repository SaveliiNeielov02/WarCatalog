using Microsoft.EntityFrameworkCore;
using WarCatalog.Models;

namespace WarCatalog
{
        public class ModelDbContext : DbContext
        {
            public DbSet<Vehicle> Vehicles { get; set; } // DbSet для работы с моделью TankViewModel
            public DbSet<Type> Types { get; set; } // DbSet для работы с моделью TankViewModel


        public ModelDbContext(DbContextOptions<ModelDbContext> options)
                : base(options)
            {
            }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Type>().ToTable("types");
            modelBuilder.Entity<Vehicle>().ToTable("vehicles");

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Type)
                .WithMany()
                .HasForeignKey(v => v.TypeID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
