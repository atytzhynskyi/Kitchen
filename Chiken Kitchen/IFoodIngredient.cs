using System;
using System.Collections.Generic;
using System.Text;

namespace Chiken_Kitchen
{
    public interface IFoodIngredient
    {
        int GetCount();
        string GetName();
        void SetCount(int _Count);
        List<Ingredient> GetRecipe();
    }
}
