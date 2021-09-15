using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiken_Kitchen
{
    class Kitchen : IKitchen
    {
        public Kitchen() { }
        public void Cook(Menu menu, Ingredient order)
        {
            foreach (Ingredient ingredient in menu.AllIngredients)
            {
                if (ingredient.Name == order.Name)
                {
                    if (ingredient.GetRecipe().Count == 0) return;
                    foreach (Ingredient ingredientRecipe in ingredient.GetRecipe())
                    {
                        Cook(menu, ingredientRecipe);
                        ingredientRecipe.UseIngredient(menu.AllIngredients);
                    }
                    ingredient.Count++;
                }
            }
        }
        public bool isEnoughIngredients(Menu menu, Ingredient food)
        {
            List<int> startValues = (from ingredient in menu.AllIngredients
                                     select ingredient.Count).ToList();
            Cook(menu, food);
            List<Ingredient> missingIngredients = new List<Ingredient>();
            foreach (Ingredient ingredient in menu.AllIngredients)
            {
                if (ingredient.Count < 0)
                {
                    missingIngredients.Add(ingredient);
                }
            }
            if (missingIngredients.Count != 0)
            {
                foreach (Ingredient ingredient in missingIngredients)
                {
                    Console.WriteLine("We dont have enough " + ingredient.Name);
                }
                SetStartCount(menu.AllIngredients, startValues);
                return false;
            }
            SetStartCount(menu.AllIngredients, startValues);
            return true;
        }
        private void SetStartCount(List<Ingredient> allIngredients, List<int> StartValues)
        {
            int i = 0;
            foreach (Ingredient ingredient in allIngredients)
            {
                ingredient.Count = StartValues[i];
                i++;
            }
        }
    }
}
