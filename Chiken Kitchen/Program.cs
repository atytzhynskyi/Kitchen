using System;
using System.Collections.Generic;

namespace Chiken_Kitchen
{
    class Program
    {
        static void Main(string[] args)
        {
            IMenu menu = new Menu();
            IHall hall = new Hall();
            

            hall.Meet((Menu)menu, "Julie Mirage");
            hall.SetCustomersOrder((Menu)menu, "Julie Mirage", new Ingredient("Fish In Water"));
            hall.Service((Menu)menu, "Julie Mirage");

            hall.Meet((Menu)menu, "Julie Mirage");
            hall.SetCustomersOrder((Menu)menu, "Julie Mirage", new Ingredient("Emperor Chicken"));
            hall.Service((Menu)menu, "Julie Mirage");

            hall.Meet((Menu)menu, "Elon Carousel");
            hall.SetCustomersOrder((Menu)menu, "Elon Carousel", new Ingredient("Fish In Water"));
            hall.Service((Menu)menu, "Elon Carousel");

            hall.Meet((Menu)menu, "Bernard Unfortunate");
            hall.SetCustomersOrder((Menu)menu, "Bernard Unfortunate", new Ingredient("Emperor Chicken"));
            hall.Service((Menu)menu, "Bernard Unfortunate");

            string Name = hall.AskCustomersName();
            hall.Meet((Menu)menu, Name);
            hall.SetCustomersOrder((Menu)menu, Name, hall.AskOrder((Menu)menu, hall.GetCustomerHall(Name)));
            hall.Service((Menu)menu, Name);
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
