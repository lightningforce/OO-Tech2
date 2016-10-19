using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FruitStoreSystem2
{
    public class Customer
    {
        private string name;
        private string surname;
        private string phone;
        private string address;
        private ReserveOrders ROrder;

        public Customer(string n, string s, string p, string a, ReserveOrders ROrder)
        {
            this.name = n;
            this.surname = s;
            this.phone = p;
            this.address = a;
            this.ROrder = ROrder;
        }
    }
}