using System;
using System.Collections.Generic;
using System.Text;

namespace Chiken_Kitchen
{
    interface IHall
    {
        public List<Customer> GetAllCustomers();
        public bool isNewCustomer(string Name);
        public void GiveFood(Menu menu, Customer customer);
        public List<Ingredient> AskAllergies();
        public Ingredient AskOrder();
        public string AskName();
        public Customer GetCustomer(string Name);
    }
}
