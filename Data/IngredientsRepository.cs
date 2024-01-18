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
    /// Позволяет получать ингредиенты из базы данных
    /// </summary>
    internal class IngredientsRepository
    {

        private Context ctx;

        public IngredientsRepository(Context ctx)
        {
            this.ctx = ctx;
        }

        /// <summary>
        /// Получить список всех ингредиентов
        /// </summary>
        public IReadOnlyList<Ingredient> GetIngredients()
        {

            var ingredients = ctx.Ingredients
                .ToList();

            return ingredients;
        }
    }
}
