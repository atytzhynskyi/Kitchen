using System;
using System.Collections.Generic;
using System.Text;

namespace Chiken_Kitchen
{
    class Ingredient
    {
        public string Name;
        public int Count;
        public Ingredient(string _Name, int _Count)
        {
            Name = _Name;
            Count = _Count;
        }
        public Ingredient(string _Name)
        {
            Name = _Name;
            Count = 1;
        }
        public void UseIngredient(List<Ingredient> allIngredients)
        {
            foreach (Ingredient ingredient in allIngredients)
            {
                if (ingredient.Name == Name)
                {
                    Count--;
                    return;
                }
            }
        }
        public void AddNewIngredient(List<Ingredient> allIngredients)
        {
            Console.WriteLine("Are you want buying new ingredient? What would you prefer?");
            Name = Console.ReadLine();
            Console.WriteLine("How many do you want?");
            Count = Convert.ToInt32(Console.ReadLine());
            allIngredients.Add(this);
            Console.WriteLine("New ingredient " + Name + " added");
        }
        public virtual void Cook(List<Ingredient> allIngredients) => throw new NotImplementedException();
        public virtual void CookWithoutCheck(List<Ingredient> allIngredients) => throw new NotImplementedException();
        public virtual List<Ingredient> GetRecipe() => new List<Ingredient>();
        public virtual bool isEnoughIngredients(List<Ingredient> allIngredients) => throw new NotImplementedException();
    }
}
