using BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class GregoryContext : DbContext
    {
        public DbSet<Chain> WTF { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Database=Gregory;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MapUniqueId<Chain>(modelBuilder);
        }

        private PropertyBuilder MapUniqueId<T>(ModelBuilder modelBuilder) where T: EditableObject
        {
            return modelBuilder.Entity<T>().Property(c => c.UniqueId).HasColumnName(typeof(T).Name + "_Guid");
        }

    }
}
