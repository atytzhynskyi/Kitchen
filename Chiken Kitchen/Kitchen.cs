using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiken_Kitchen
{
    public class Kitchen : IKitchen
    {
        public List<Ingredient> BaseIngredients = new List<Ingredient>();
        public List<Food> Foods = new List<Food>();
        public Kitchen()
        {
            FillBaseIngredients();
            FillFoodsRecipe();
        }
        public Kitchen(List<Ingredient> _BaseIngredients, List<Food> _Foods)
        {
            BaseIngredients = _BaseIngredients;
            Foods = _Foods;
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
            Foods.Add(new Food("Emperor Chicken", 0, new Ingredient("Fat Cat Chiken"), new Ingredient("Spicy Sauce"), new Ingredient("Tuna Cake")));
            Foods.Add(new Food("Fat Cat Chiken", 0, new Ingredient("Princess Chicken"), new Ingredient("Youth Sauce"), new Ingredient("Fries"), new Ingredient("Tuna Cake")));
            Foods.Add(new Food("Princess Chicken", 0, new Ingredient("Chicken"), new Ingredient("Youth Sauce")));
            Foods.Add(new Food("Youth Sauce", 0, new Ingredient("Asparagus"), new Ingredient("Milk"), new Ingredient("Honey")));
            Foods.Add(new Food("Spicy Sauce", 0, new Ingredient("Paprika"), new Ingredient("Garlic"), new Ingredient("Water")));
            Foods.Add(new Food("Omega Sauce", 0, new Ingredient("Lemon"), new Ingredient("Water")));
            Foods.Add(new Food("Diamond Salad", 0, new Ingredient("Tomatoes"), new Ingredient("Pickles"), new Ingredient("Feta")));
            Foods.Add(new Food("Ruby Salad", 0, new Ingredient("Tomatoes"), new Ingredient("Vinegar")));
            Foods.Add(new Food("Fries", 0, new Ingredient("Potatoes")));
            Foods.Add(new Food("Smashed Potatoes", 0, new Ingredient("Potatoes")));
            Foods.Add(new Food("Tuna Cake", 0, new Ingredient("Tuna"), new Ingredient("Chocolate"), new Ingredient("Youth Sauce")));
            Foods.Add(new Food("Fish In Water", 0, new Ingredient("Tuna"), new Ingredient("Omega Sauce"), new Ingredient("Ruby Salad")));
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
        public void Cook(Food order)
        {
            foreach (Food food in Foods)
            {
                if (order.Name == food.Name)
                {
                    order = food;
                    break;
                }
            }
            foreach (Ingredient ingredient in BaseIngredients)
            {
                foreach (Ingredient ingredientRecipe in order.GetRecipe())
                {
                    if (ingredientRecipe.Name == ingredient.Name)
                    {
                        ingredient.Count-=ingredientRecipe.Count;
                    }
                }
            }
            foreach(Food food in Foods)
            {
                foreach(Ingredient ingredient in order.GetRecipe())
                {
                    if (ingredient.Name == food.Name)
                    {
                        while (ingredient.Count > food.Count)
                        {
                            Cook(food);
                        }
                        food.Count -= ingredient.Count;
                    }
                }
            }
            order.Count++;
        }
        public bool isEnoughIngredients(Food food)
        {
            List<Ingredient> BaseIngredientsCopy = new List<Ingredient>();
            foreach (Ingredient ingredient in BaseIngredients)
            {
                BaseIngredientsCopy.Add(new Ingredient(ingredient.Name, ingredient.Count));
            }
            List<Food> FoodsCopy = new List<Food>();
            foreach(Food _food in Foods)
            {
                FoodsCopy.Add(new Food(_food.Name, _food.Count, _food.Recipe.ToArray()));
            }
            Kitchen kitchen = new Kitchen(BaseIngredientsCopy, FoodsCopy);
            kitchen.Cook(food);
            foreach (Ingredient ingredient in BaseIngredientsCopy)
            {
                if (ingredient.Count < 0)
                {
                    return false;
                }
            }
            return true;
        }
        public void ShowAll()
        {
            foreach (Ingredient ingredient in BaseIngredients)
            {
                Console.WriteLine(ingredient.Name + " " + ingredient.Count);
            }
            foreach (Food food in Foods)
            {
                Console.WriteLine(food.Name + " " + food.Count);
            }
        }
    }
}
