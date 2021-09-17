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
            IKitchen kitchen = new Kitchen();

<<<<<<< HEAD
            Customer customer = new Customer("Julie Mirage");
            if (hall.isNewCustomer(customer.Name)){
                customer.Allergies = hall.AskAllergies();
            }
            Food order = new Food("Fish In Water");
            if (menu.isFoodInMenu(order))
            {
                if (!customer.isAllergic((Kitchen)kitchen, order))
                {
                    customer.SetOrder((Menu)menu, order);
                    if (kitchen.isEnoughIngredients(order))
                    {
                        kitchen.Cook(order);
                        hall.GiveFood((Kitchen)kitchen, customer);
                    }
                    else Console.WriteLine("We dont have enough ingredients");
                }
                else Console.WriteLine(order.Name + " contains allergic ingredients for " + customer.Name);
=======
            Customer customer = new Customer(hall.AskName());
            if(hall.isNewCustomer(customer.Name))
                customer.Allergies=hall.AskAllergies();
            else 
                customer.Allergies = hall.GetCustomer(customer.Name).Allergies;
            customer.SetOrder((Menu)menu, hall.AskOrder());
            if(customer.Order.isAllergic((Menu)menu, customer.Allergies))
            {
                Console.WriteLine("This food is alergic to " + customer.Name);
            }
            else
            {
                if (kitchen.isEnoughIngredients((Menu)menu, customer.Order))
                {
                    kitchen.Cook((Menu)menu, customer.Order);
                    hall.GiveFood((Menu)menu, customer);
                }
                else Console.WriteLine("We dont have enough ingredients to cook " + customer.Order.Name);
>>>>>>> parent of 46e240b... Wednesday. Remove inheritance betveen Food and Ingredient. Add few test for Customer, Kitchen
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
