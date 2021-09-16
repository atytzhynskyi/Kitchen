using System;
using System.Collections.Generic;
using System.Text;

namespace Chiken_Kitchen
{
    public class Customer
    {
        public string Name;
        public Food Order = new Food("");
        public List<Ingredient> Allergies = new List<Ingredient>();
        public Customer(string _Name, params Ingredient[] _Allergies)
        {
            Name = _Name;
            Allergies.AddRange(_Allergies);
        }
        public Customer(string _Name)
        {
            Name = _Name;
        }
        public void SetOrder(Menu menu, Food _Order)
        {
            foreach (Food food in menu.Foods)
            {
                if (_Order.Name == food.Name)
                {
                    Order.Name = food.Name;
                    Order.Count = 1;
                    return;
                }
            }
            Console.WriteLine("Order doesnt exist in menu");
        }
        public void SetOrder(Menu menu, Food _Order, int OrderCount)
        {
            foreach (Food food in menu.Foods)
            {
                if (_Order.Name == food.Name)
                {
                    Order.Name = food.Name;
                    Order.Count = OrderCount;
                    return;
                }
            }
            Console.WriteLine("Order doesnt exist in menu");
        }
        public bool isAllergic(Kitchen kitchen, Food food)
        {
            foreach (var foodIngredient in kitchen.Storage)
            {
                if (food.Name == foodIngredient.GetName() && foodIngredient is Food)
                {
                    food.Recipe = foodIngredient.GetRecipe();
                }
            }
            foreach (var ingredient in food.GetRecipe())
            {
                foreach (var foodIngredient in kitchen.Storage)
                {
                    if (ingredient.Name == foodIngredient.GetName())
                    {
                        if (foodIngredient is Food)
                        {
                            if (isAllergic(kitchen, (Food)foodIngredient))
                            {
                                return true;
                            }
                        }
                        if(foodIngredient is Ingredient)
                        {
                            foreach (Ingredient ingredientAllergic in Allergies)
                            {
                                if (ingredient.Name == ingredientAllergic.Name)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}