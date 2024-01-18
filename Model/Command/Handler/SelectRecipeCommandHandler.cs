using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Command.Abstract;
using Model.Command.Command;
using Model.Model;
using Model.Repository;

namespace Model.Command.Handler
{
    internal class SelectRecipeCommandHandler :
        ICommandHandler<SelectRecipeCommand>
    {
        IGenericRepository<Recipe, int> _rRepo;
        IGenericRepository<SelectedRecipe, int> _srRepo;

        public SelectRecipeCommandHandler(
            IGenericRepository<Recipe, int> rRepo,
            IGenericRepository<SelectedRecipe, int> srRepo)
        {
            _rRepo = rRepo;
            _srRepo = srRepo;
        }

        public void Execute(SelectRecipeCommand command)
        {
            // Проверим, что рецепт уже не выбран
            var selectedRecipe = _srRepo.Query(
                x => x.RecipeId == command.RecipeId &&
                   x.UserId == command.UserId);
            if (selectedRecipe != null)
            {
                return;
            }

            // Найдем рецепт
            var recipe = _rRepo.FindById(command.RecipeId);
            if (recipe == null)
            {
                throw new Exception($"Рецепт id={command.RecipeId} не найден");
            }

            // Создадим новый объект выбранного рецепта
            selectedRecipe = new SelectedRecipe(recipe);
            _srRepo.Create(selectedRecipe);
            _srRepo.Save();
        }
    }
}
