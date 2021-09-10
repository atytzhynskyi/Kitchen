using System;
using System.Collections.Generic;

namespace Chiken_Kitchen
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Ingredient> allIngredients = new List<Ingredient>();
            FillLists.FillBaseIngredients(allIngredients);
            FillLists.FillFoodRecipe(allIngredients);
            List<Customer> customers = new List<Customer>();
            FillLists.FillCustomers(customers);
            Customer.MeetCustomer(allIngredients, customers, "Julie Mirage");
            Customer.MeetCustomer(allIngredients, customers, "Julie Mirage");
            Customer.MeetCustomer(allIngredients, customers, "Elon Carousel");
            Customer.MeetCustomer(allIngredients, customers, "Bernard Unfortunate");
            /*foreach(Customer customer in customers)
            {
                if (customer.Name == "Julie Mirage"|| customer.Name == "Elon Carousel")
                {
                    customer.SetOrder(allIngredients, new Ingredient("Fish In Water"));
                    customer.Service(allIngredients);
                }
                if (customer.Name == "Julie Mirage"|| customer.Name == "Bernard Unfortunate")
                {
                    customer.SetOrder(allIngredients, new Ingredient("Emperor Chicken"));
                    customer.Service(allIngredients);
                }
            }*/
            foreach (Ingredient ingredient in allIngredients)
            {
                Console.WriteLine(ingredient.Name + " " + ingredient.Count);
            }
        }
    }
}

/*1. Julie Mirage wants to buy Fish In Water. She gets her Fish in Water.
2. Elon Carousel wants to buy Fish In Water. You have to refuse him service, because one
dependency uses Chocolate and he is allergic to it.
3. Julie Mirage wants to buy Emperor Chicken. She gets her Emperor Chicken.
4. Bernard Unfortunate wants to buy Emperor Chicken. You have to refuse him service, because
one dependency uses Potatoes and he is allergic to them.*/
