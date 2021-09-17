using System;
using System.Collections.Generic;
using System.Text;

namespace Chiken_Kitchen
{
    interface IMenu
    {
<<<<<<< HEAD
        bool isFoodInMenu(Food food);
        public List<Food> GetFoods();
=======
        public List<Ingredient> GetAllIngredients();
>>>>>>> parent of 46e240b... Wednesday. Remove inheritance betveen Food and Ingredient. Add few test for Customer, Kitchen
        public void AddNewFood();
        public void AddNewIngredient();
        public void ShowAllIngredients();
    }
}
