using System;
using System.Collections.Generic;
using System.Text;

namespace Chiken_Kitchen
{
    interface IMenu
    {
        bool isFoodInMenu(Food food);
        public List<Food> GetFoods();
        public void AddNewFood();
        void ShowAll();
    }
}
