using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chiken_Kitchen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chiken_Kitchen.Tests
{
    [TestClass()]
    public class KitchenTests
    {
        [TestMethod()]
        public void CookTest()
        {
            Ingredient water = new Ingredient("water", 10);
            Food ice = new Food("ice", new Ingredient("water"));
            Food iceCream = new Food("ice cream", new Ingredient("water"), new Ingredient("ice"));
            List<Ingredient> ingredients = new List<Ingredient> { water };
            List<Food> foods = new List<Food> { ice, iceCream };
            Kitchen kitchen = new Kitchen(ingredients, foods);
            kitchen.Cook(new Food("ice cream"));

            Ingredient waterTest = new Ingredient("water", 8);
            Food iceTest = new Food("ice", 0, water);
            Food iceCreamTest = new Food("ice cream", 1, water, new Ingredient("ice"));

            if (kitchen.BaseIngredients[0].Count != waterTest.Count){
                Assert.Fail("ingredients count doesnt correct");
            }
            if (kitchen.Foods[0].Count != iceTest.Count)
            {
                Assert.Fail("Foods count doesnt correct");
            }
            if (kitchen.Foods[1].Count != iceCreamTest.Count)
            {
                Assert.Fail("Final food count doesnt correct");
            }
        }

        [TestMethod()]
        public void isEnoughIngredientsTest()
        {
            Ingredient water = new Ingredient("water", 1);
            Food ice = new Food("ice", new Ingredient("water"));
            Food iceCream = new Food("ice cream", new Ingredient("water"), new Ingredient("ice"));
            List<Ingredient> ingredients = new List<Ingredient> { water };
            List<Food> foods = new List<Food> { ice, iceCream };
            Kitchen kitchen = new Kitchen(ingredients, foods);
            Assert.IsFalse(kitchen.isEnoughIngredients(new Food("ice cream")), "the number of ingredients is incorrectly checked");
        }
    }
}