using System;
using System.Collections.Generic;
using System.Text;

namespace Chiken_Kitchen
{
    public class Ingredient
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
    }
}
