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
            //IKitchen kitchen = new Kitchen();

            Ingredient water = new Ingredient("water", 1);
            Food ice = new Food("ice", 0, new Ingredient("water", 1));
            Food iceCream = new Food("ice cream", 0, new Ingredient("water", 1), new Ingredient("ice", 1));
            List<Ingredient> ingredients = new List<Ingredient> { water };
            List<Food> foods = new List<Food> { ice, iceCream };
            Kitchen kitchen = new Kitchen(ingredients, foods);
            kitchen.isEnoughIngredients(new Food("ice cream"));
            kitchen.Cook(new Food("ice cream"));
        }
    }
}

/*1. Julie Mirage wants to buy Fish In Water. She gets her Fish in Water.
2. Elon Carousel wants to buy Fish In Water. You have to refuse him service, because one
dependency uses Chocolate and he is allergic to it.
3. Julie Mirage wants to buy Emperor Chicken. She gets her Emperor Chicken.
4. Bernard Unfortunate wants to buy Emperor Chicken. You have to refuse him service, because
one dependency uses Potatoes and he is allergic to them.*/
