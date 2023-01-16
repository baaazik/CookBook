using Data;
using Model.Recipe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class RecipesMenu : UserControl
    {
        IDataSource _source;
        IList<BaseRecipe> _menu;

        public RecipesMenu()
        {
            InitializeComponent();
            // Получаем источник данных
            _source = DataSourceProvider.GetInstance().GetSource();
            UpdateMenu();
        }

        private void UpdateMenu()
        {
            // Обновляем список рецептов
            _menu = _source.GetMenu();
            listBoxMenu.DataSource = null;
            listBoxMenu.DataSource = _menu;
        }

        public void Selected()
        {
            UpdateMenu();
        }
    }
}
