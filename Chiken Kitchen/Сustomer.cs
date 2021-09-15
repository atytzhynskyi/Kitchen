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
        public void SetOrder(Menu menu, Ingredient _Order)
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
        public void SetOrder(Menu menu, Ingredient _Order, int OrderCount)
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
            foreach (Food _food in kitchen.Foods)
            {
                if (_food.Name == food.Name)
                {
                    food = _food;
                }
            }
            foreach (Ingredient ingredient in food.Recipe)
            {
                foreach (Ingredient allergy in Allergies)
                {
                    if (allergy.Name == ingredient.Name)
                    {
                        return true;
                    }
                }
            }
            foreach (Food _food in kitchen.Foods)
            {
                foreach (Ingredient ingredient in food.Recipe)
                {
                    if (_food.Name == ingredient.Name)
                    {
                        if (isAllergic(kitchen, _food))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}