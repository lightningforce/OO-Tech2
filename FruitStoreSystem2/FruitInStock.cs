using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FruitStoreSystem2
{
    public class FruitInStock
    {
        private string grade;
        private int amount;
        public FruitInStock(string g,int a)
        {
            this.grade = g;
            this.amount = a;
        }
    }
}