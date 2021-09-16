using System.Collections.Generic;

namespace Chiken_Kitchen
{
    interface IKitchen
    {
        Food Cook(Food order);
        bool isEnoughIngredients(List<Ingredient> Recipe);
        void AddNewIngredient();
        void ShowAll();
    }
}