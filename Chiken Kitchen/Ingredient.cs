using System;
using System.Collections.Generic;
using System.Text;

namespace Chiken_Kitchen
{
    public class Ingredient : IFoodIngredient
    {
        public string Name;
        public int Count;
        public int GetCount() => Count;
        public void SetCount(int _Count)
        {
            Count = _Count;
        }
        public string GetName() => Name;
        public List<Ingredient> GetRecipe() => new List<Ingredient>();
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
    }
}
