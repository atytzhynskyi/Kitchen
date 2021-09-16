using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiken_Kitchen
{
    public class Kitchen : IKitchen
    {
        public List<Ingredient> BaseIngredients = new List<Ingredient>();
        public List<Food> Recipes = new List<Food>();
        public Kitchen()
        {
            FillBaseIngredients();
            FillFoodsRecipe();
        }
        public Kitchen(List<Ingredient> _BaseIngredients, List<Food> _Recipes)
        {
            BaseIngredients = _BaseIngredients;
            Recipes = _Recipes;
        }
        private void FillBaseIngredients()
        {
            string[] BaseIngredientsStr = "Chicken, Tuna, Potatoes, Asparagus, Milk, Honey, Paprika, Garlic, Water, Lemon, Tomatoes, Pickles, Feta, Vinegar, Rice, Chocolate".Split(", ");
            foreach (string i in BaseIngredientsStr)
            {
                BaseIngredients.Add(new Ingredient(i, 10));
            }
        }
        private void FillFoodsRecipe()
        {
            Recipes.Add(new Food("Emperor Chicken", 0, new Ingredient("Fat Cat Chiken"), new Ingredient("Spicy Sauce"), new Ingredient("Tuna Cake")));
            Recipes.Add(new Food("Fat Cat Chiken", 0, new Ingredient("Princess Chicken"), new Ingredient("Youth Sauce"), new Ingredient("Fries"), new Ingredient("Tuna Cake")));
            Recipes.Add(new Food("Princess Chicken", 0, new Ingredient("Chicken"), new Ingredient("Youth Sauce")));
            Recipes.Add(new Food("Youth Sauce", 0, new Ingredient("Asparagus"), new Ingredient("Milk"), new Ingredient("Honey")));
            Recipes.Add(new Food("Spicy Sauce", 0, new Ingredient("Paprika"), new Ingredient("Garlic"), new Ingredient("Water")));
            Recipes.Add(new Food("Omega Sauce", 0, new Ingredient("Lemon"), new Ingredient("Water")));
            Recipes.Add(new Food("Diamond Salad", 0, new Ingredient("Tomatoes"), new Ingredient("Pickles"), new Ingredient("Feta")));
            Recipes.Add(new Food("Ruby Salad", 0, new Ingredient("Tomatoes"), new Ingredient("Vinegar")));
            Recipes.Add(new Food("Fries", 0, new Ingredient("Potatoes")));
            Recipes.Add(new Food("Smashed Potatoes", 0, new Ingredient("Potatoes")));
            Recipes.Add(new Food("Tuna Cake", 0, new Ingredient("Tuna"), new Ingredient("Chocolate"), new Ingredient("Youth Sauce")));
            Recipes.Add(new Food("Fish In Water", 0, new Ingredient("Tuna"), new Ingredient("Omega Sauce"), new Ingredient("Ruby Salad")));
        }
        public void AddNewIngredient()
        {
            Console.WriteLine("What is name of new ingredient?");
            string inredientName = Console.ReadLine();
            Console.WriteLine("How many do you want?");
            int ingredientCount = Convert.ToInt32(Console.ReadLine());
            Ingredient ingredient = new Ingredient(inredientName, ingredientCount);
            BaseIngredients.Add(ingredient);
            Console.WriteLine("New ingredient " + ingredient.Name + " added");
        }
        public Food Cook(Food order)
        {
            foreach (Food food in Recipes)
            {
                if (food.Name == order.Name)
                    order.Recipe = DeepCopyRecipe(food.Recipe);
            }

            if (!isEnoughIngredients(order.Recipe))
            {
                Console.WriteLine("We dont have enough ingredients");
                return order;
            }
            order.Recipe = GetBaseIngredientRecipe(order.Recipe);
            foreach (Ingredient ingredient in BaseIngredients)
            {
                foreach (Ingredient ingredientRecipe in order.Recipe)
                {
                    if (ingredient.Name == ingredientRecipe.Name)
                    {
                        ingredient.Count -= ingredientRecipe.Count;
                    }
                }
            }
            order.Count++;
            return order;
        }
        public bool isEnoughIngredients(List<Ingredient> Recipe)
        {
            List<Ingredient> CopyRecipe = DeepCopyRecipe(Recipe);
            CopyRecipe = GetBaseIngredientRecipe(CopyRecipe);
            foreach (Ingredient ingredientRecipe in CopyRecipe)
            {
                foreach (Ingredient ingredient in BaseIngredients)
                {
                    if (ingredient.Name == ingredientRecipe.Name && ingredient.Count < ingredientRecipe.Count)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private List<Ingredient> GetBaseIngredientRecipe(List<Ingredient> Recipe)
        {
            List<Ingredient> fullRecipe = new List<Ingredient>();
            foreach (Ingredient ingredient in Recipe)
            {
                bool isFood = false;
                foreach (Food food in Recipes)
                {
                    if (food.Name == ingredient.Name)
                    {
                        fullRecipe.AddRange(GetBaseIngredientRecipe(food.Recipe));
                        isFood = true;
                    }
                }
                if (!isFood)
                {
                    bool isFound = false;
                    foreach(Ingredient ingredientFullRecipe in fullRecipe)
                    {
                        if (ingredientFullRecipe.Name == ingredient.Name)
                        {
                            ingredientFullRecipe.Count += ingredient.Count;
                            isFound = true;
                            break;
                        }
                    }
                    if (isFound) continue;
                    fullRecipe.Add(ingredient);
                }
            }
            return fullRecipe;
        }
        private List<Ingredient> DeepCopyRecipe(List<Ingredient> Recipe)
        {
            List<Ingredient> CopyRecipe = new List<Ingredient>();
            foreach (Ingredient ingredient in Recipe)
            {
                CopyRecipe.Add(new Ingredient(ingredient.Name, ingredient.Count));
            }
            return CopyRecipe;
        }
        public void ShowAll()
        {
            foreach (Ingredient ingredient in BaseIngredients)
            {
                Console.WriteLine(ingredient.Name + " " + ingredient.Count);
            }
            foreach (Food food in Recipes)
            {
                Console.WriteLine(food.Name + " " + food.Count);
            }
        }
    }
}
