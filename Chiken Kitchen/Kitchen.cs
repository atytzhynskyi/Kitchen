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
            if (!isEnoughIngredients(order))
            {
                Console.WriteLine("We dont have enough ingredient");
                return;
            }
            foreach (var food in Storage)
            {
                if (order.Name == food.GetName() && food is Food)
                {
                    order = (Food)food;
                    break;
                }
            }
            foreach (var foodIngredients in Storage)
            {
                foreach (Ingredient ingredient in order.GetRecipe())
                {
                    if (ingredient.Name == foodIngredients.GetName())
                    {
                        if (foodIngredients is Food)
                        {
                            while (foodIngredients.GetCount() < ingredient.GetCount())
                                Cook((Food)foodIngredients);
                            foodIngredients.SetCount(foodIngredients.GetCount() - ingredient.Count);
                        }
                        else if (ingredient is Ingredient)
                        {
                            foodIngredients.SetCount(foodIngredients.GetCount() - ingredient.Count);
                        }
                    }
                }
            }
            order.Count++;
        }
        public bool isEnoughIngredients(Food food)
        {
            foreach (var foodIngredient in Storage)
            {
                if (food.Name == foodIngredient.GetName())
                {
                    food.Recipe = foodIngredient.GetRecipe();
                }
            }
            List<Ingredient> RecipeList = new List<Ingredient>();
            foreach (var foodIngredient in Storage)
            {
                foreach (Ingredient ingredient in food.Recipe)
                {
                    if (ingredient.Name == foodIngredient.GetName())
                    {
                        if (foodIngredient is Food && foodIngredient.GetCount() < ingredient.Count)
                        {
                            RecipeList.AddRange(GetFullRecipe((Food)foodIngredient));
                        }
                        else RecipeList.Add(ingredient);
                    }
                }
            }
            RecipeList = CompressRecipeList(RecipeList);
            
            foreach(Ingredient ingredientRecipe in RecipeList)
            {
                foreach(var ingredient in Storage)
                {
                    if(ingredientRecipe.Name == ingredient.GetName() && ingredient.GetCount() < ingredientRecipe.Count)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private List<Ingredient> GetFullRecipe(Food food)
        {
            List<Ingredient> AllIngredient = new List<Ingredient>();
            foreach (var foodIngredient in Storage)
            {
                foreach (Ingredient ingredient in food.GetRecipe())
                {
                    if (foodIngredient.GetName() == ingredient.Name)
                    {
                        if (foodIngredient is Food)
                        {
                            AllIngredient.AddRange(GetFullRecipe((Food)foodIngredient));
                        }
                        else AllIngredient.Add(ingredient);
                    }
                }
            }
            return AllIngredient;
        }
        private List<Ingredient> CompressRecipeList(List<Ingredient> RecipeList)
        {
            List<Ingredient> FinalRecipeList = new List<Ingredient>();
            foreach(Ingredient ingredient in RecipeList)
            {
                bool isIngredientFound = false;
                foreach(Ingredient ingredientFound in FinalRecipeList)
                {
                    if(ingredientFound.Name == ingredient.Name)
                    {
                        isIngredientFound = true;
                    }
                }
                if (!isIngredientFound)
                {
                    FinalRecipeList.Add(new Ingredient(ingredient.Name));
                }
            }
            foreach (Ingredient ingredientFinal in FinalRecipeList)
            {
                int Count = 0;
                foreach (Ingredient ingredient in RecipeList)
                {
                    if(ingredient.Name == ingredientFinal.Name)
                    {
                        Count++;
                    }
                }
                ingredientFinal.Count = Count;
            }
            return FinalRecipeList;
        } // {(water,2),(water,3)} => {(water,5)}
        public void ShowAll()
        {
            foreach (var foodIngredient in Storage)
            {
                Console.WriteLine(foodIngredient.GetName() + " " + foodIngredient.GetCount());
            }
        }
    }
}
