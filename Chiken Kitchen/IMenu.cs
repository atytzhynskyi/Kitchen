using System;
using System.Collections.Generic;
using System.Text;

namespace Chiken_Kitchen
{
    interface IMenu
    {
        public List<Food> GetFoods();
        public void AddNewFood();
        void ShowAll();
    }
}
