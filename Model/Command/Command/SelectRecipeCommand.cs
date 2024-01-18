using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Command.Command
{
    public class SelectRecipeCommand
    {
        public int RecipeId { get; set; }
        public string UserId { get; set; }
    }
}
