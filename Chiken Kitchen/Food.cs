using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Chiken_Kitchen
{
    public class Food
    {
        public string Name;
        public int Count;
        public List<Ingredient> Recipe = new List<Ingredient>();
        public List<Ingredient> GetRecipe() => Recipe;
        public string GetName() => Name;
        public int GetCount() => Count;
        public void SetCount(int _Count)
        {
            Count = _Count;
        }
        public Food(string _Name)
        {
            Name = _Name;
            Count = 0;
        }
        public Food(string _Name, int _Count)
        {
            Name = _Name;
            Count = _Count;
        }
        public Food(string _Name, params Ingredient[] _Recipe)
        {
            Name = _Name;
            Recipe.AddRange(_Recipe);
            Count = 0;
        }
        public Food(string _Name, int _Count, params Ingredient[] _Recipe)
        {
            Recipe.AddRange(_Recipe);
            Name = _Name;
            Count = _Count;
        }
    }
}
