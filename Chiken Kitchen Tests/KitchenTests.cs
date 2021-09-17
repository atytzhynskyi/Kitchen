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
            List<IFoodIngredient> storage = new List<IFoodIngredient> { ice, iceCream, water };
            Kitchen kitchen = new Kitchen(storage);
            kitchen.Cook(new Food("ice cream"));

            Ingredient waterTest = new Ingredient("water", 8);
            Food iceTest = new Food("ice", 0, water);
            Food iceCreamTest = new Food("ice cream", 1, water, new Ingredient("ice"));
            List<IFoodIngredient> test = new List<IFoodIngredient> { ice, iceCream, water };

            foreach (var FoodIngredient in storage)
            {
                foreach (var testFoodIngredient in test)
                {
                    if(FoodIngredient.GetName()==testFoodIngredient.GetName())
                        Assert.IsFalse(FoodIngredient.GetCount() != testFoodIngredient.GetCount(), "Wrong food or ingredient count");
                }
            }
        }

        [TestMethod()]
        public void isEnoughIngredientsTest()
        {
            Ingredient water = new Ingredient("water", 1);
            Food ice = new Food("ice", new Ingredient("water"));
            Food iceCream = new Food("ice cream", new Ingredient("water"), new Ingredient("ice"));
            List<IFoodIngredient> storage = new List<IFoodIngredient> { ice, iceCream, water };
            Kitchen kitchen = new Kitchen(storage);
            Assert.IsFalse(kitchen.isEnoughIngredients(new Food("ice cream")), "False positive result");
        }

        [TestMethod()]
        public void isEnoughIngredientsTest1()
        {
            Ingredient water = new Ingredient("water", 12);
            Food ice = new Food("ice", new Ingredient("water"));
            Food iceCream = new Food("ice cream", new Ingredient("water"), new Ingredient("ice"));
            List<IFoodIngredient> storage = new List<IFoodIngredient> { ice, iceCream, water };
            Kitchen kitchen = new Kitchen(storage);
            Assert.IsTrue(kitchen.isEnoughIngredients(new Food("ice cream")), "False negative result");
        }
    }
}