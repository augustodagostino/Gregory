using BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;

namespace BusinessLayer
{
    public class GregoryContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Database=Gregory;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Model.GetEntityTypes().Where(w=> w.FindAnnotation("Relational:TableName").IsNull()).ToList().ForEach(e => e.Relational().TableName = e.DisplayName());

            MapUniqueId<Chain>(modelBuilder);
        }

        private PropertyBuilder MapUniqueId<T>(ModelBuilder modelBuilder) where T: EditableObject
        {
            return modelBuilder.Entity<T>().Property(c => c.UniqueId).HasColumnName(typeof(T).Name + "_Guid");
        }

        public EntityEntry<T> Add<T>(T newItem) where T : class
        {
            return Set<T>().Add(newItem);
        }

        public DbSet<T> Table<T>() where T : class
        {
            return Set<T>();
        }

    }
}
