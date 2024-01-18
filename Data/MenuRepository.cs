using Data.Models;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// Позволяет работать со списком выбранных рецептов
    /// </summary>
    internal class MenuRepository
    {
        private Context ctx;

        public MenuRepository(Context ctx)
        {
            this.ctx = ctx;
        }

        /// <summary>
        /// Возращает меню - список выбранных рецептов
        /// </summary>
        public IList<SelectedRecipe> GetMenu(string userId)
        {
            var recipes = ctx.SelectedRecipes
                .Where(r => r.UserId == userId)
                .Select(r => new SelectedRecipe()
                {
                    Id = r.Id,
                    Recipe = new Recipe()
                    {
                        Id = r.Recipe.Id,
                        Name = r.Recipe.Name,
                        Amount = r.Recipe.Amount,
                        Unit = r.Recipe.Unit
                    },
                    Amount = r.Amount
                })
                .ToList();
            return recipes;
        }

        /// <summary>
        /// Выбирает рецепт
        /// </summary>
        public void SelectRecipe(string userId, int recipeId, uint amount)
        {
            var newSelectedRecipe = new SelectedRecipe()
            {
                UserId = userId,
                RecipeId = recipeId,
                Amount = amount
            };

            ctx.SelectedRecipes.Add(newSelectedRecipe);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Удаляет выбор рецепта
        /// </summary>
        public void DeleteRecipe(string userId, int recipeId)
        {
            var selectedRecipe = ctx.SelectedRecipes
                .First(r => r.UserId == userId && r.RecipeId == recipeId);

            ctx.SelectedRecipes.Attach(selectedRecipe);
            ctx.SelectedRecipes.Remove(selectedRecipe);
            ctx.SaveChanges();
        }
    }
}
