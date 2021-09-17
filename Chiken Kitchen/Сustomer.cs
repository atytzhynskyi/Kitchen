using System;
using System.Collections.Generic;
using System.Text;

namespace Chiken_Kitchen
{
    class Customer
    {
        public string Name;
        public Ingredient Order = new Food("");
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
            foreach (Ingredient ingredient in menu.AllIngredients)
            {
                if (_Order.Name == ingredient.Name)
                {
                    Order.Name = ingredient.Name;
                    Order.Count = 1;
                    return;
                }
            }
            Console.WriteLine("Order doesnt exist in menu");
        }
        public void SetOrder(Menu menu, Food _Order, int OrderCount)
        {
            foreach (Ingredient ingredient in menu.AllIngredients)
            {
                if (_Order.Name == ingredient.Name)
                {
                    Order.Name = ingredient.Name;
                    Order.Count = OrderCount;
                    return;
                }
            }
            Console.WriteLine("Order doesnt exist in menu");
        }
<<<<<<< HEAD
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
=======
>>>>>>> parent of 46e240b... Wednesday. Remove inheritance betveen Food and Ingredient. Add few test for Customer, Kitchen
    }
}
