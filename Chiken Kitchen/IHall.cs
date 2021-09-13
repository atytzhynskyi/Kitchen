using System;
using System.Collections.Generic;
using System.Text;

namespace Chiken_Kitchen
{
    interface IHall
    {
        public Customer Meet(Menu menu, string Name);
        public List<Customer> GetAllCustomers();
        public string AskCustomersName();
        public void Service(Menu menu, string Name);
        public Ingredient AskOrder(Menu menu, Customer customer);
        public Customer GetCustomerHall(string Name);
        public void SetCustomersOrder(Menu menu, string Name, Ingredient order);
    }
}
