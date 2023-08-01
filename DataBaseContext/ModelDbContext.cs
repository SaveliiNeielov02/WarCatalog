using Microsoft.EntityFrameworkCore;
using WarCatalog.Models;
namespace DataBaseContext
{
    public class ModelDbContext: DbContext
    {
        public DbSet<TankViewModel> Tanks { get; set; } // DbSet для работы с моделью TankViewModel

        public ModelDbContext(DbContextOptions<ModelDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Здесь вы можете настроить отображение моделей данных на таблицы базы данных,
            // определить ограничения, индексы и другие настройки

            base.OnModelCreating(modelBuilder);
        }
    }
}