using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FruitStoreSystem2
{
    public class ReserveItems
    {
        private int numberOfItem;
        private string gradeRequiremment;
        private string status;
        private Fruit fruit;
        public ReserveItems(int n,string g,string s,Fruit f)
        {
            this.numberOfItem = n;
            this.gradeRequiremment = g;
            this.status = s;
            this.fruit = f;
            
        }
    }
}