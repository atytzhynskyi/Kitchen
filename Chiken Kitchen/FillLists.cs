using System;
using System.Collections.Generic;
using System.Text;

namespace Chiken_Kitchen
{
    static class FillLists
    {
        public static void FillBaseIngredients(List<Ingredient> allIngredients)
        {
            string[] BaseIngredients = "Chicken, Tuna, Potatoes, Asparagus, Milk, Honey, Paprika, Garlic, Water, Lemon, Tomatoes, Pickles, Feta, Vinegar, Rice, Chocolate".Split(", ");
            foreach (string i in BaseIngredients)
            {
                allIngredients.Add(new Ingredient(i, 10));
            }
        }
        public static void FillFoodRecipe(List<Ingredient> allIngredients)
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
        public static void FillCustomers(List<Customer> CustomersList)
        {
            CustomersList.Add(new Customer("Julie Mirage", new Ingredient("Soy")));
            CustomersList.Add(new Customer("Elon Carousel", new Ingredient("Vinegar"), new Ingredient("olives")));
            CustomersList.Add(new Customer("Adam Smith"));
            CustomersList.Add(new Customer("Barbara Smith", new Ingredient("Chocolate")));
            CustomersList.Add(new Customer("Christian Donnovan", new Ingredient("Paprika")));
            CustomersList.Add(new Customer("Bernard Unfortunate", new Ingredient("Potatoes")));
        }
    }
}
