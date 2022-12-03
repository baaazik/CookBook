using Data;
using Model.Menu;
using Model.Recipe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    /// <summary>
    /// Компонент, отображающий список рецептов
    /// </summary>
    public partial class RecipesList : UserControl
    {
        IDataSource source;
        IReadOnlyList<BaseRecipe> recipes;
        Menu menu;

        public RecipesList()
        {
            InitializeComponent();

            // Получаем источник данных
            source = new FakeData();
            menu = source.GetMenu();

            UpdateRecipes();
        }

        private void UpdateRecipes()
        {
            // Обновляем список рецептов
            recipes = source.GetRecipes();
            listBoxRecipes.DataSource = recipes;
        }

        private void btnChooseRecipe_Click(object sender, EventArgs e)
        {
            // Добавляем выбранный рецепт в меню
            int idx = listBoxRecipes.SelectedIndex;
            if (idx != -1)
            {
                var selectedRecipe = recipes[idx];
                if (!menu.Contains(selectedRecipe))
                {
                    menu.Add(selectedRecipe);
                }
            }
        }
    }
}
