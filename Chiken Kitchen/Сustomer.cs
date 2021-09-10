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
        
        public void SetOrder(List<Ingredient> allIngredients, Ingredient _Order)
        {
            foreach (Ingredient ingredient in allIngredients)
            {
                if (_Order.Name == ingredient.Name)
                {
                    Order.Name = ingredient.Name;
                    Order.Count = 1;
                }
            }
        }
        public void SetOrder(List<Ingredient> allIngredients, Ingredient _Order, int OrderCount)
        {
            foreach (Ingredient ingredient in allIngredients)
            {
                if (_Order.Name == ingredient.Name)
                {
                    Order = ingredient;
                    Order.Count = OrderCount;
                }
            }
        }
        public void Service(List<Ingredient> allIngredients)
        {
            if (Food.isAllergiesFood(allIngredients, Order, Allergies))
            {
                Console.WriteLine(Order.Name + " is allergic food for " + Name);
            }
            else
            {
                foreach (Ingredient ingredient in allIngredients)
                {
                    if (ingredient.Name == Order.Name)
                    {
                        ingredient.Cook(allIngredients);
                    }
                }
                GiveFood(allIngredients);
            }
        }
        public void GiveFood(List<Ingredient> allIngredients)
        {
            foreach (Ingredient ingredient in allIngredients)
            {
                if (ingredient.Name == Order.Name)
                {
                    if (ingredient.Count < Order.Count)
                    {
                        Console.WriteLine("We dont have " + Order.Name);
                        return;
                    }
                    ingredient.Count -= Order.Count;
                    Console.WriteLine(Name + " get " + ingredient.Name);
                    return;
                }
            }
            Console.WriteLine("Order doesnt exist in Ingedient List");
        }

        public static Customer MeetCustomer(List<Ingredient> allIngredients, List<Customer> customers, string _Name)
        {
            Customer customer = new Customer(_Name);
            foreach (Customer customerTemp in customers)
            {
                if (customerTemp.Name == _Name)
                {
                    customer = customerTemp;
                    break;
                }
            }
            do
            {
                Console.WriteLine("Did you found what you want, {0}? y/n", _Name);
                if (Console.ReadLine() == "n")
                {
                    Console.WriteLine("We so sorry, hope you come back soon");
                    return customer;
                }
                Console.WriteLine("What you prefer to order?", _Name);
                string _Order = Console.ReadLine();
                customer.SetOrder(allIngredients, new Ingredient(_Order));
                if (!customer.Order.isEnoughIngredients(allIngredients))
                    Console.WriteLine("Can you order somethink else?");
                if (Food.isAllergiesFood(allIngredients, customer.Order, customer.Allergies))
                    Console.WriteLine("Sorry, this food is allergic to you");
            }
            while (Food.isAllergiesFood(allIngredients, customer.Order, customer.Allergies) || !customer.Order.isEnoughIngredients(allIngredients));
            Console.WriteLine("How many do you want?");
            int orderCount = Convert.ToInt32(Console.ReadLine());
            customer.Order.Count = orderCount;
            return customer;
        }
        public static Customer MeetNewCustomer(List<Ingredient> allIngredients, List<Customer> customers)
        {
            Console.WriteLine("Welcome to Chucken Kitchen, what is our name?");
            string _Name = Console.ReadLine();
            Console.WriteLine("Do you have any allergies? please use ',' between allergic food");
            string[] allergicFoodName = Console.ReadLine().Split(", ");
            Customer customer = new Customer(_Name);
            foreach (string ingredientName in allergicFoodName)
            {
                customer.Allergies.Add(new Ingredient(ingredientName));
            }
            MeetCustomer(allIngredients, customers, customer.Name);
            return customer;
        }
    }
}
