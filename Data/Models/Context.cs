using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    internal class Context : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<SelectedRecipe> SelectedRecipes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=recipes.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetupConversion<Ingredient>(modelBuilder, x => x.UnitType);
            SetupConversion<Recipe>(modelBuilder, x => x.UnitType);           
        }

        private void SetupConversion<T>(ModelBuilder builder, Expression<Func<T, UnitType>> func) where T: class
        {
            builder.Entity<T>()
                .Property(func)
                .HasConversion(
                    v => v.ToString(),
                    v => UnitConverter.StrToType(v));
        }
    }
}
