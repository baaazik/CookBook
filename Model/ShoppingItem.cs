using Model.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Элемент списка покупок
    /// </summary>
    public class ShoppingItem
    {
        public int Id { get; set; }
        public RecipeItem Ingredient { get; set; }
        public bool IsBought { get; set; }
    }
}
