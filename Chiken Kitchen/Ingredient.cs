using System;
using System.Collections.Generic;
using System.Text;

namespace Chiken_Kitchen
{
    class Ingredient
    {
        public string Name;
        public int Count;
        public Ingredient(string _Name, int _Count)
        {
            Name = _Name;
            Count = _Count;
        }
        public Ingredient(string _Name)
        {
            Name = _Name;
            Count = 1;
        }
        public void UseIngredient(List<Ingredient> allIngredients)
        {
            foreach (Ingredient ingredient in allIngredients)
            {
                if (ingredient.Name == Name)
                {
                    ingredient.Count--;
                    return;
                }
            }
        }
        public virtual bool isAllergic(Menu menu, List<Ingredient> customerAllergies)
        {
            foreach(Ingredient ingredient in customerAllergies)
            {
                if (ingredient.Name == Name)
                {
                    Console.WriteLine("!");
                    return true;
                }
            }
            return false;
        }
        public virtual List<Ingredient> GetRecipe() => new List<Ingredient>();
    }
}
