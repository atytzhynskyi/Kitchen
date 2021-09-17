using System.Collections.Generic;

namespace Chiken_Kitchen
{
    interface IKitchen
    {
        Food Cook(Food order);
        bool isEnoughIngredients(Food food);
        void AddNewIngredient();
        void ShowAll();
    }
}