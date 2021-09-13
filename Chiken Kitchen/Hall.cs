using System;
using System.Collections.Generic;
using System.Text;

namespace Chiken_Kitchen
{
    class Hall : IHall
    {
        List<Customer> AllCustomers = new List<Customer>();
        List<Customer> CustomersInHall = new List<Customer>();
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
        public Customer GetCustomerHall(string Name)
        {
            foreach(Customer customer in CustomersInHall)
            {
                if(customer.Name == Name)
                {
                    return customer;
                }
            }
            Console.WriteLine("customer didnt found");
            return new Customer("NULL");
        }
        public void SetCustomersOrder(Menu menu, string Name, Ingredient order)
        {
            foreach(Customer customer in CustomersInHall)
            {
                if(customer.Name == Name)
                {
                    customer.SetOrder(menu.AllIngredients, order);
                    return;
                }
            }
        }
        public List<Customer> GetAllCustomers()
        {
            return AllCustomers;
        }
        public string AskCustomersName()
        {
            Console.WriteLine("Welcome to Chicken Kitchen, what is your name?");
            string Name = Console.ReadLine();
            return Name;
        }
        public Customer Meet(Menu menu, string Name)
        {
            Customer customer = new Customer(Name);
            bool isNewCustomer = true;
            foreach (Customer customerTemp in AllCustomers)
            {
                if (customerTemp.Name == Name)
                {
                    isNewCustomer = false;
                    customer = customerTemp;
                    break;
                }
            }
            if (isNewCustomer) 
                customer.Allergies.AddRange(AskAllergies());
            CustomersInHall.Add(customer);
            return customer;
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
        public Ingredient AskOrder(Menu menu, Customer customer)
        {
            Ingredient ingredient = new Food("",0);
            string _Order = "";
            do
            {
                Console.WriteLine("Did you found what you wanted, {0}? y/n", customer.Name);
                string answear = Console.ReadLine();
                if (answear == "n")
                {
                    Console.WriteLine("We so sorry, hope you come back soon");
                    return ingredient;
                }
                else if (answear == "y")
                {
                    Console.WriteLine("What you prefer to order?");
                    _Order = Console.ReadLine();
                    customer.SetOrder(menu.AllIngredients, new Ingredient(_Order));
                    if (!customer.Order.isEnoughIngredients(menu.AllIngredients))
                        Console.WriteLine("Can you order somethink else?");
                    if (Food.isAllergiesFood(menu.AllIngredients, customer.Order, customer.Allergies))
                        Console.WriteLine("Sorry, this food is allergic to you");
                }
                else continue;
            }
            while (
                Food.isAllergiesFood(menu.AllIngredients, customer.Order, customer.Allergies) || !customer.Order.isEnoughIngredients(menu.AllIngredients));
            Console.WriteLine("How many do you want?");
            int orderCount = Convert.ToInt32(Console.ReadLine());
            ingredient = new Ingredient(_Order, orderCount);
            return ingredient;
        }
        public void Service(Menu menu, string Name)
        {
            foreach(Customer customer in CustomersInHall)
            {
                if(customer.Name == Name)
                {
                    if (Food.isAllergiesFood(menu.AllIngredients, customer.Order, customer.Allergies))
                    {
                        Console.WriteLine(customer.Order.Name + " is allergic food for " + Name);
                        return;
                    }
                    else
                    {
                        foreach (Ingredient ingredient in menu.AllIngredients)
                        {
                            if (ingredient.Name == customer.Order.Name)
                            {
                                ingredient.Cook(menu.AllIngredients);
                            }
                        }
                        customer.GiveFood(menu.AllIngredients);
                        CustomersInHall.Remove(customer);
                    }
                    return;
                }
            }
        }
    }
}
