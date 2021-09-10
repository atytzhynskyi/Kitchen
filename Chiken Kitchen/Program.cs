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

            Customer.Meet(allIngredients, customers, "Julie Mirage");
            Customer.Service(allIngredients, customers, "Julie Mirage");
            Customer.Meet(allIngredients, customers, "Julie Mirage");
            Customer.Service(allIngredients, customers, "Julie Mirage");
            Customer.Meet(allIngredients, customers, "Elon Carousel");
            Customer.Service(allIngredients, customers, "Elon Carousel");
            Customer.Meet(allIngredients, customers, "Bernard Unfortunate");
            Customer.Service(allIngredients, customers, "Bernard Unfortunate");

            /*while (2+2!=5)
            {
                Console.WriteLine("What you prefer to do? 1.Meet and Service customers 2.add new Ingredient, 3. add new Food recipe");
                int n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        Customer customerTemp = Customer.MeetNewbie(allIngredients, customers);
                        Customer.Service(allIngredients, customers, customerTemp.Name); 
                    default:
                }
            }*/
            
        }
        static void ShowAllIngredients(List<Ingredient> allIngredients)
        {
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
