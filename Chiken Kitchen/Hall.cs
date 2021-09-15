using System;
using System.Collections.Generic;
using System.Text;

namespace Chiken_Kitchen
{
    public class Hall : IHall
    {
        List<Customer> AllCustomers = new List<Customer>();
        public Hall()
        {
            FillCustomers();
        }
        public Hall(List<Customer> customers)
        {
            AllCustomers.AddRange(customers);
        }
        private void FillCustomers()
        {
            AllCustomers.Add(new Customer("Julie Mirage", new Ingredient("Soy")));
            AllCustomers.Add(new Customer("Elon Carousel", new Ingredient("Vinegar"), new Ingredient("olives")));
            AllCustomers.Add(new Customer("Adam Smith"));
            AllCustomers.Add(new Customer("Barbara Smith", new Ingredient("Chocolate")));
            AllCustomers.Add(new Customer("Christian Donnovan", new Ingredient("Paprika")));
            AllCustomers.Add(new Customer("Bernard Unfortunate", new Ingredient("Potatoes")));
        }
        public List<Customer> GetAllCustomers() => AllCustomers;
        public bool isNewCustomer(string Name)
        {
            foreach (Customer customerTemp in AllCustomers)
            {
                if (customerTemp.Name == Name)
                {
                    return false;
                }
            }
            return true;
        }
        public void AddNewCustomer(Customer customer)
        {
            AllCustomers.Add(customer);
        }
        public Customer GetCustomer(string Name)
        {
            foreach(Customer customer in AllCustomers)
            {
                if(customer.Name == Name)
                {
                    return customer;
                }
            }
            return new Customer("NULL");
        }
        public void GiveFood(Menu menu, Customer customer)
        {
            foreach (Food food in menu.Foods)
            {
                if (food.Name == customer.Order.Name)
                {
                    if (food.Count < customer.Order.Count)
                    {
                        Console.WriteLine("We dont have " + customer.Order.Name);
                        return;
                    }
                    food.Count -= customer.Order.Count;
                    Console.WriteLine(customer.Name + " get " + food.Name);
                    customer.Order = new Food("");
                    return;
                }
            }
            Console.WriteLine("Order doesnt exist in Ingedient List");
        }
        public List<Ingredient> AskAllergies()
        {
            List<Ingredient> allergicIngredients = new List<Ingredient>();
            Console.WriteLine("Do you have any allergies? (please use ',' between allergic food)");
            string[] allergicFoodName = Console.ReadLine().Split(", ");
            foreach (string ingredientName in allergicFoodName)
            {
                allergicIngredients.Add(new Ingredient(ingredientName));
            }
            return allergicIngredients;
        }
        public Food AskOrder()
        {
            Console.WriteLine("What you prefer to order?");
            string _Order = Console.ReadLine();
            Console.WriteLine("How many do you want?");
            int orderCount = Convert.ToInt32(Console.ReadLine());
            Food food = new Food(_Order, orderCount);
            return food;
        }
        public string AskName()
        {
            Console.WriteLine("Welcome to Chicken Kitchen, what is your name?");
            string Name = Console.ReadLine();
            return Name;
        }
    }
}
