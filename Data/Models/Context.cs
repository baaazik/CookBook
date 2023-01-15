using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    internal class Context : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<SelectedRecipe> SelectedRecipes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=recipes.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>()
                .Property(e => e.UnitType)
                .HasConversion(
                    v => v.ToString(),
                    v => (UnitType)Enum.Parse(typeof(UnitType), v));

            modelBuilder.Entity<Recipe>()
                .Property(e => e.UnitType)
                .HasConversion(
                    v => v.ToString(),
                    v => (UnitType)Enum.Parse(typeof(UnitType), v));
        }
    }
}
