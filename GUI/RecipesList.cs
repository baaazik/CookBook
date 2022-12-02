using Data;
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
    public partial class RecipesList : UserControl
    {
        IDataSource source;
        IReadOnlyList<BaseRecipe> recipes;

        public RecipesList()
        {
            InitializeComponent();
            source = new FakeData();

            UpdateRecipes();
        }

        private void UpdateRecipes()
        {
            recipes = source.GetRecipes();
            listBoxRecipes.DataSource = recipes;
        }
    }
}
