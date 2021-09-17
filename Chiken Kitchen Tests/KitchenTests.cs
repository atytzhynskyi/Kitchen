﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            Food ice = new Food("ice", new Ingredient("water", 1));
            Food iceCream = new Food("ice cream", new Ingredient("water", 1), new Ingredient("ice", 1));
            List<Ingredient> ingredients = new List<Ingredient> { water };
            List<Food> foods = new List<Food> { ice, iceCream };
            Kitchen kitchen = new Kitchen(ingredients, foods);
            Food finishFood = kitchen.Cook(new Food("ice cream"));

            Ingredient waterTest = new Ingredient("water", 8);
            if (kitchen.BaseIngredients[0].Count != waterTest.Count){
                Assert.Fail("ingredients count doesnt correct");
            }
            if(finishFood.Count != 1)
            {
                Assert.Fail("finish final food count doesnt correct");
            }
        }

        [TestMethod()]
        public void isEnoughIngredientsTest()
        {
            Ingredient water = new Ingredient("water", 1);
            Food ice = new Food("ice", 0, new Ingredient("water", 1));
            Food iceCream = new Food("ice cream", 0, new Ingredient("water", 1), new Ingredient("ice", 1));
            List<Ingredient> ingredients = new List<Ingredient> { water };
            List<Food> foods = new List<Food> { ice, iceCream };
            Kitchen kitchen = new Kitchen(ingredients, foods);
            Console.WriteLine(kitchen.BaseIngredients[0].Name + " " + kitchen.BaseIngredients[0].Count);
            Assert.IsFalse(kitchen.isEnoughIngredients(iceCream), "the number of ingredients is incorrectly checked");
        }
    }
}