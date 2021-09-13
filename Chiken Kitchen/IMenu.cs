using System;
using System.Collections.Generic;
using System.Text;

namespace Chiken_Kitchen
{
    interface IMenu
    {
        public List<Ingredient> GetAllIngredients();
        public void AddNewFood();
        public void AddNewIngredient();
    }
}
