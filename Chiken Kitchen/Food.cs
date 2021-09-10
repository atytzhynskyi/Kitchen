using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Chiken_Kitchen
{
    class Food : Ingredient
    {
        public List<Ingredient> Recipe = new List<Ingredient>();
        public override List<Ingredient> GetRecipe() => Recipe;

        public Food(string _Name, params Ingredient[] _Recipe) : base(_Name)
        {
            Recipe.AddRange(_Recipe);
        }
        public Food(string _Name, int _Count, params Ingredient[] _Recipe) : base(_Name, _Count)
        {
            Recipe.AddRange(_Recipe);
        }

        public void AddNewFood(List<Ingredient> allIngredients)
        {
            Console.WriteLine("Do you want add new recipe? What is name of this food?");
            Name = Console.ReadLine();
            Console.WriteLine("What are in the recipe? (please use ',' between ingredients)");
            string[] ingredientsRecipeName = Console.ReadLine().Split(", ");
            List<Ingredient> ingredientsRecipe = new List<Ingredient>();
            foreach (string ingredientName in ingredientsRecipeName)
            {
                ingredientsRecipe.Add(new Ingredient(ingredientName));
            }
            Recipe.AddRange(ingredientsRecipe);
            allIngredients.Add(this);
            Console.WriteLine(Name + " added to the menu");
        }
        public override void Cook(List<Ingredient> allIngredients)
        {
            if (!isEnoughIngredients(allIngredients))
            {
                return;
            }
            CookWithoutCheck(allIngredients);
        }
        public override void CookWithoutCheck(List<Ingredient> allIngredients)
        {
            foreach (var (ingredient, ingredientRecipe) in from Ingredient ingredient in allIngredients
                                                           from Ingredient ingredientRecipe in Recipe
                                                           where ingredientRecipe.Name == ingredient.Name
                                                           select (ingredient, ingredientRecipe))
            {
                while (ingredient.GetRecipe().Count != 0 && ingredient.Count < ingredientRecipe.Count)
                {
                    ingredient.CookWithoutCheck(allIngredients);
                }

                ingredient.UseIngredient(allIngredients);
            }

            Count++;
        }
        public override bool isEnoughIngredients(List<Ingredient> allIngredients)
        {
            List<int> startValues = new List<int>();
            foreach (var ingredient in allIngredients)
            {
                startValues.Add(ingredient.Count);
            }

            CookWithoutCheck(allIngredients);
            List<Ingredient> missingIngredients = new List<Ingredient>();
            foreach (Ingredient ingredient in allIngredients)
            {
                foreach (Ingredient ingredientRecipe in GetRecipe())
                    if (ingredient.Count < 0 && ingredient.Name == ingredientRecipe.Name)
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
                SetStartCount(allIngredients, startValues);
                return false;
            }
            SetStartCount(allIngredients, startValues);
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
        static public bool isAllergiesFood(List<Ingredient> allIngredients, Ingredient food, List<Ingredient> customerAllergies)
        {
            foreach (Ingredient ingredient in allIngredients) //Set ingredient from allIngredient as customerOrder to set a Recipe
                if (food.Name == ingredient.Name)
                {
                    food = ingredient;
                    break;
                }
            foreach (Ingredient ingredient in food.GetRecipe())
            {
                foreach (Ingredient allergiesIngredient in customerAllergies)
                    if (ingredient.Name == allergiesIngredient.Name)
                    {
                        return true;
                    }
                if (isAllergiesFood(allIngredients, ingredient, customerAllergies)) return true;
            }
            return false;
        }
    }
}
