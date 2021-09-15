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
        public void SetOrder(Menu menu, Ingredient _Order)
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
        public void SetOrder(Menu menu, Ingredient _Order, int OrderCount)
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
    }
}
