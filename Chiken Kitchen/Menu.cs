using System;
using System.Collections.Generic;
using System.Text;

namespace Chiken_Kitchen
{
    class Menu : IMenu
    {
        public List<Ingredient> AllIngredients = new List<Ingredient>();
        public Menu()
        {
            FillFoodsRecipe(AllIngredients);
            FillBaseIngredients(AllIngredients);
        }
        public Menu(List<Ingredient> ingredients)
        {
            AllIngredients.AddRange(ingredients);
        }
        public List<Ingredient> GetAllIngredients() => AllIngredients;
        public void AddNewFood()
        {
            Console.WriteLine("Do you want add new recipe? What is name of this food?");
            string foodName = Console.ReadLine();
            Food food = new Food(foodName, 0);
            Console.WriteLine("What are in the recipe? (please use ',' between ingredients)");
            string[] ingredientsRecipeSplit = Console.ReadLine().Split(", ");
            List<Ingredient> ingredientsRecipe = new List<Ingredient>();
            foreach (string ingredientNameStr in ingredientsRecipeSplit)
            {
                ingredientsRecipe.Add(new Ingredient(ingredientNameStr));
            }
            food.Recipe.AddRange(ingredientsRecipe);
            AllIngredients.Add(food);
            Console.WriteLine(food.Name + " added to the menu");
        }
        public void AddNewIngredient()
        {
            Console.WriteLine("Are you want buying new ingredient? What would you prefer?");
            string inredientName = Console.ReadLine();
            Console.WriteLine("How many do you want?");
            int ingredientCount = Convert.ToInt32(Console.ReadLine());
            Ingredient ingredient = new Ingredient(inredientName, ingredientCount);
            AllIngredients.Add(ingredient);
            Console.WriteLine("New ingredient " + ingredient.Name + " added");
        }
        private void FillFoodsRecipe(List<Ingredient> allIngredients)
        {
            allIngredients.Add(new Food("Emperor Chicken", 0, new Ingredient("Fat Cat Chiken"), new Ingredient("Spicy Sauce"), new Ingredient("Tuna Cake")));
            allIngredients.Add(new Food("Fat Cat Chiken", 0, new Ingredient("Princess Chicken"), new Ingredient("Youth Sauce"), new Ingredient("Fries"), new Food("Tuna Cake")));
            allIngredients.Add(new Food("Princess Chicken", 0, new Ingredient("Chicken"), new Ingredient("Youth Sauce")));
            allIngredients.Add(new Food("Youth Sauce", 0, new Ingredient("Asparagus"), new Ingredient("Milk"), new Ingredient("Honey")));
            allIngredients.Add(new Food("Spicy Sauce", 0, new Ingredient("Paprika"), new Ingredient("Garlic"), new Ingredient("Water")));
            allIngredients.Add(new Food("Omega Sauce", 0, new Ingredient("Lemon"), new Ingredient("Water")));
            allIngredients.Add(new Food("Diamond Salad", 0, new Ingredient("Tomatoes"), new Ingredient("Pickles"), new Ingredient("Feta")));
            allIngredients.Add(new Food("Ruby Salad", 0, new Ingredient("Tomatoes"), new Ingredient("Vinegar")));
            allIngredients.Add(new Food("Fries", 0, new Ingredient("Potatoes")));
            allIngredients.Add(new Food("Smashed Potatoes", 0, new Ingredient("Potatoes")));
            allIngredients.Add(new Food("Tuna Cake", 0, new Ingredient("Tuna"), new Ingredient("Chocolate"), new Ingredient("Youth Sauce")));
            allIngredients.Add(new Food("Fish In Water", 0, new Ingredient("Tuna"), new Ingredient("Omega Sauce"), new Ingredient("Ruby Salad")));
        }
        private static void FillBaseIngredients(List<Ingredient> allIngredients)
        {
            string[] BaseIngredients = "Chicken, Tuna, Potatoes, Asparagus, Milk, Honey, Paprika, Garlic, Water, Lemon, Tomatoes, Pickles, Feta, Vinegar, Rice, Chocolate".Split(", ");
            foreach (string i in BaseIngredients)
            {
                allIngredients.Add(new Ingredient(i, 10));
            }
        }
    }
}
