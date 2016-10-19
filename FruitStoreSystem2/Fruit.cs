using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FruitStoreSystem2
{
    public class Fruit
    {
        private string type;
        private string seeds;
        private FruitInStock fis;

        public Fruit(string t, string s, FruitInStock fs)
        {
            this.type = t;
            this.seeds = s;
            this.fis = fs;
        }

    }

    
}