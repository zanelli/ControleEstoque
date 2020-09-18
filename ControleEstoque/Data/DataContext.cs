using ControleEstoque.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Produto> Produto { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.Property(e => e.Descricao).IsRequired();

            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder//.UseSqlServer("Server=.;Database=ControleEstoque;Trusted_Connection=True;MultipleActiveResultSets=true;");
                           .UseInMemoryDatabase("ControleEstoque");
        }

    }
}
