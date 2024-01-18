using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Model.Model;

namespace Data.Models
{
    public class Context : DbContext
    {
        private string _sqlConnectionString = "Server=(localdb)\\mssqllocaldb;Database=sema_Data;Trusted_Connection=True;MultipleActiveResultSets=true";
        private string _sqliteConnectionString = "Data Source=D:\\recipes_data.db";

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<SelectedRecipe> SelectedRecipes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ShoppingItem> ShoppingItems { get; set; }

        public Context()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer(_sqlConnectionString);
            optionsBuilder.UseSqlite(_sqliteConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetupConversion<Ingredient>(modelBuilder, x => x.Unit);
            SetupConversion<Recipe>(modelBuilder, x => x.Unit);
        }

        // Настройка преобразования типов при сохранении в БД
        private void SetupConversion<T>(ModelBuilder builder, Expression<Func<T, BaseUnit>> func) where T : class
        {
            builder.Entity<T>()
                .Property(func)
                .HasConversion(
                    v => UnitConverter.TypeToStr(v),
                    v => UnitConverter.StrToType(v));
        }
    }
}
