using System;
using System.Collections.Generic;
using System.Data;
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
        public DataTable getFruitType()
        {
            FruitDataService fd = new FruitDataService();
            DataTable dt = fd.getFruitTypeData();
            return dt;
        }
        public DataTable getFruitSeed(string fruitType)
        {
            FruitDataService fd = new FruitDataService();
            DataTable dt  = fd.getFruitSeedData(fruitType);
            return dt;
        }
        public void insertFruit(string fruitType, string fruitSeed, int amount)
        {
            FruitDataService fd = new FruitDataService();
            fd.insertFruitData(fruitType,fruitSeed,amount);
        }
    }

    
}