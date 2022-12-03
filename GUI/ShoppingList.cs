using Data;
using Model;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class ShoppingList : UserControl
    {
        IDataSource _source;
        IList<RecipeItem> _shoppingList;

        public ShoppingList()
        {
            InitializeComponent();
            // Получаем источник данных
            _source = DataSourceProvider.GetInstance().GetSource();
            UpdateMenu();
        }

        private void UpdateMenu()
        {
            // Обновляем список покупок
            _shoppingList = ShoppingListBuilder.GetShoppingList(_source.GetMenu());
            listBoxShopping.DataSource = _shoppingList;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateMenu();
        }
    }
}
