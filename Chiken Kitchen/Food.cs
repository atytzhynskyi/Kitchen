using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Chiken_Kitchen
{
    class Food : Ingredient
    {
        public List<Ingredient> Recipe = new List<Ingredient>();
<<<<<<< HEAD
        public List<Ingredient> GetRecipe() => Recipe;
        public string GetName() => Name;
        public int GetCount() => Count;
        public void SetCount(int _Count)
        {
            Count = _Count;
        }
        public Food(string _Name)
        {
            Name = _Name;
            Count = 0;
        }
        public Food(string _Name, int _Count)
        {
            Name = _Name;
            Count = _Count;
        }
        public Food(string _Name, params Ingredient[] _Recipe)
=======
        public override List<Ingredient> GetRecipe() => Recipe;

        public Food(string _Name, params Ingredient[] _Recipe) : base(_Name)
>>>>>>> parent of 46e240b... Wednesday. Remove inheritance betveen Food and Ingredient. Add few test for Customer, Kitchen
        {
            Recipe.AddRange(_Recipe);
        }
        public Food(string _Name, int _Count, params Ingredient[] _Recipe) : base(_Name, _Count)
        {
            Recipe.AddRange(_Recipe);
        }
        public override bool isAllergic(Menu menu, List<Ingredient> customerAllergies)
        {
            Ingredient food = new Food("");
            foreach (Ingredient ingredient in menu.AllIngredients) //Set ingredient from allIngredient as customerOrder to set a Recipe
                if (Name == ingredient.Name)
                {
                    food = ingredient;
                    break;
                }
            foreach (Ingredient ingredient in food.GetRecipe())
            {
                foreach (Ingredient allergiesIngredient in customerAllergies)
                    if (ingredient.Name == allergiesIngredient.Name) return true;
                foreach(Ingredient menuIngredient in menu.AllIngredients)
                {
                    if(menuIngredient.Name == ingredient.Name)
                    {
                        if (menuIngredient.isAllergic(menu, customerAllergies)) return true;
                    }
                }
            }
            return false;
        }
    }
}
