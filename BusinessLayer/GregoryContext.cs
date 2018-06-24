using BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;

namespace BusinessLayer
{
    public class GregoryContext : DbContext
    {
        public DbSet<Chain> Chains { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Database=Gregory;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Model.GetEntityTypes().Where(w=> w.FindAnnotation("Relational:TableName").IsNull()).ToList().ForEach(e => e.Relational().TableName = e.DisplayName());

            MapUniqueId<Chain>(modelBuilder);
        }

        private PropertyBuilder MapUniqueId<T>(ModelBuilder modelBuilder) where T: EditableObject
        {
            return modelBuilder.Entity<T>().Property(c => c.UniqueId).HasColumnName(typeof(T).Name + "_Guid");
        }

    }
}
