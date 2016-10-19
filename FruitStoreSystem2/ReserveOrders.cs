using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FruitStoreSystem2
{
    public class ReserveOrders
    {
        private DateTime reserveDate;
        private DateTime reserveInterval;
        private Fruit f;
        private ReserveItems RItems;
        
        public ReserveOrders(DateTime reserveDate, DateTime reserveInterval, int n, string g, string status, Fruit f)
        {
            this.reserveDate = reserveDate;
            this.reserveInterval = reserveInterval;
            this.RItems = new ReserveItems(n,g,status,f);
        }
    }
}