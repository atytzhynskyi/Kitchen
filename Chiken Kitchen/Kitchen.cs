using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiken_Kitchen
{
    public class Kitchen : IKitchen
    {
        public List<IFoodIngredient> Storage = new List<IFoodIngredient>();
        public Kitchen()
        {
            FillBaseIngredients();
            FillFoodsRecipe();
        }
        public Kitchen(List<IFoodIngredient> _Storage)
        {
            Storage = _Storage;
        }
        private void FillBaseIngredients()
        {
            string[] BaseIngredientsStr = "Chicken, Tuna, Potatoes, Asparagus, Milk, Honey, Paprika, Garlic, Water, Lemon, Tomatoes, Pickles, Feta, Vinegar, Rice, Chocolate".Split(", ");
            foreach (string i in BaseIngredientsStr)
            {
                Storage.Add(new Ingredient(i, 10));
            }
        }
        private void FillFoodsRecipe()
        {
            Storage.Add(new Food("Emperor Chicken", 0, new Ingredient("Fat Cat Chiken"), new Ingredient("Spicy Sauce"), new Ingredient("Tuna Cake")));
            Storage.Add(new Food("Fat Cat Chiken", 0, new Ingredient("Princess Chicken"), new Ingredient("Youth Sauce"), new Ingredient("Fries"), new Ingredient("Tuna Cake")));
            Storage.Add(new Food("Princess Chicken", 0, new Ingredient("Chicken"), new Ingredient("Youth Sauce")));
            Storage.Add(new Food("Youth Sauce", 0, new Ingredient("Asparagus"), new Ingredient("Milk"), new Ingredient("Honey")));
            Storage.Add(new Food("Spicy Sauce", 0, new Ingredient("Paprika"), new Ingredient("Garlic"), new Ingredient("Water")));
            Storage.Add(new Food("Omega Sauce", 0, new Ingredient("Lemon"), new Ingredient("Water")));
            Storage.Add(new Food("Diamond Salad", 0, new Ingredient("Tomatoes"), new Ingredient("Pickles"), new Ingredient("Feta")));
            Storage.Add(new Food("Ruby Salad", 0, new Ingredient("Tomatoes"), new Ingredient("Vinegar")));
            Storage.Add(new Food("Fries", 0, new Ingredient("Potatoes")));
            Storage.Add(new Food("Smashed Potatoes", 0, new Ingredient("Potatoes")));
            Storage.Add(new Food("Tuna Cake", 0, new Ingredient("Tuna"), new Ingredient("Chocolate"), new Ingredient("Youth Sauce")));
            Storage.Add(new Food("Fish In Water", 0, new Ingredient("Tuna"), new Ingredient("Omega Sauce"), new Ingredient("Ruby Salad")));
        }
        public void AddNewIngredient()
        {
            Console.WriteLine("What is name of new ingredient?");
            string inredientName = Console.ReadLine();
            Console.WriteLine("How many do you want?");
            int ingredientCount = Convert.ToInt32(Console.ReadLine());
            Ingredient ingredient = new Ingredient(inredientName, ingredientCount);
            Storage.Add(ingredient);
            Console.WriteLine("New ingredient " + ingredient.Name + " added");
        }
        public void Cook(Food order)
        {
            foreach (var food in Storage)
            {
                if (order.Name == food.GetName() && food is Food)
                {
                    order = (Food)food;
                    break;
                }
            }
            foreach(var foodIngredients in Storage)
            {
                foreach(Ingredient ingredient in order.GetRecipe())
                {
                    if(ingredient.Name == foodIngredients.GetName())
                    {
                        if(foodIngredients is Food)
                        {
                            while(ingredient.Count>foodIngredients.GetCount())
                                Cook((Food)foodIngredients);
                            foodIngredients.SetCount(foodIngredients.GetCount()-ingredient.Count);
                        }
                        if(ingredient is Ingredient)
                        {
                            foodIngredients.SetCount(foodIngredients.GetCount()-ingredient.Count);
                        }
                    }
                }
            }
            order.Count++;
        }
        public bool isEnoughIngredients(Food food)
        {
            List<IFoodIngredient> CopyStorage = new List<IFoodIngredient>();
            foreach(var foodIngredient in Storage)
            {
                if(foodIngredient is Food)
                {
                    CopyStorage.Add(new Food(foodIngredient.GetName(), foodIngredient.GetCount(), foodIngredient.GetRecipe().ToArray()));
                }
                else if(foodIngredient is Ingredient)
                {
                    CopyStorage.Add(new Ingredient(foodIngredient.GetName(), foodIngredient.GetCount()));
                }
            }
            Kitchen kitchen = new Kitchen(CopyStorage);
            kitchen.Cook(food);
            foreach(var foodIngredient in kitchen.Storage)
            {
                if (foodIngredient.GetCount() < 0)
                {
                    return false;
                }
            }
            return true;
        }
        public void ShowAll()
        {
            foreach (var foodIngredient in Storage)
            {
                Console.WriteLine(foodIngredient.GetName() + " " + foodIngredient.GetCount());
            }
        }
    }
}
