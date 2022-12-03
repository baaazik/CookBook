using Model.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// Интерфейс источника данных
    /// </summary>
    public interface IDataSource
    {
        /// <summary>
        /// Получить список рецептов
        /// </summary>
        /// <returns>Список рецептов</returns>
        IReadOnlyList<BaseRecipe> GetRecipes();

        IList<BaseRecipe> GetMenu();
    }
}
