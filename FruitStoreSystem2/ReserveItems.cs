using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace FruitStoreSystem2
{
    public class ReserveItems
    {
        private int numberOfItem;
        private string gradeRequiremment;
        private string status;
        private Fruit fruit;
        //private string reserveID;
        //public string ReserveID { get; set; }
        public ReserveItems(int n,string g,string s,Fruit f)
        {
            this.numberOfItem = n;
            this.gradeRequiremment = g;
            this.status = s;
            this.fruit = f;
            
        }
        public DataTable getReserveItem(string reserveID)
        {
            ReserveItemDataService ri = new ReserveItemDataService();
            DataTable dt = ri.getReserveItemData(reserveID);
            return dt;
        }
        public void insertReserveItem(int reserveID, int quantity, string fruitType, string fruitSeed,string grade)
        {
            ReserveItemDataService ri = new ReserveItemDataService();
            ri.insertReserveItemData(reserveID, quantity, fruitType, fruitSeed, grade);
        }
    }
}