using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chiken_Kitchen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chiken_Kitchen.Tests
{
    [TestClass()]
    public class CustomerTests
    {
        [TestMethod()]
        public void isAllergicTest()
        {
            Customer customerSalt = new Customer("Bill", new Ingredient("salt"));

            Ingredient potato = new Ingredient("potato", 10);
            Ingredient salt = new Ingredient("salt",10);
            Ingredient fish = new Ingredient("fish", 10);
            Ingredient water = new Ingredient("water", 10);

            Food saltPotato = new Food("salt potato", new Ingredient("potato"), new Ingredient("salt"));
            Food fishWithPotato = new Food("Fish with potato", new Ingredient("salt potato"), new Ingredient("fish"));
            Food ice = new Food("ice", new Ingredient("water"));
            Food iceCream = new Food("ice cream", new Ingredient("ice"), new Ingredient("water"));

            List<IFoodIngredient> foodIngredients = new List<IFoodIngredient> { potato, salt, fish, water, saltPotato, fishWithPotato, ice, iceCream };

            Kitchen kitchen = new Kitchen(foodIngredients);

            Assert.IsFalse(customerSalt.isAllergic(kitchen, new Food("ice cream")), "False positive result");
            Assert.IsTrue(customerSalt.isAllergic(kitchen, new Food("Fish with potato")), "False negative result");
        }
    }
}