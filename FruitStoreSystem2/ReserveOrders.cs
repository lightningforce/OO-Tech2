using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using BSD.DAL;
namespace FruitStoreSystem2
{
    public class ReserveOrders
    {
        private DateTime reserveDate;
        private DateTime reserveInterval;
        private Fruit f;
        private ReserveItems RItems;
        private string cusFullName;

        public string CusFullName
        {
            get
            {
                return cusFullName;
            }

            set
            {
                cusFullName = value;
            }
        }

        public ReserveOrders(DateTime reserveDate, DateTime reserveInterval, int n, string g, string status, Fruit f)
        {
            this.reserveDate = reserveDate;
            this.reserveInterval = reserveInterval;
            this.RItems = new ReserveItems(n,g,status,f);
        }
        public DataTable getReserveOrder()
        {
            ReserveOrderDataService rs = new ReserveOrderDataService();
            DataTable dt = rs.getReserveOrderData();
            return dt;
        }
        public DataTable serchReserveOrder()
        {
            cusFullName = CusFullName;
            ReserveOrderDataService rs = new ReserveOrderDataService();
            DataTable dt = rs.searchReserveOrderData(cusFullName);
            return dt;
        }
        public int insertReserveOrder(string cusFullname,string receiveDate)
        {
            ReserveOrderDataService rs = new ReserveOrderDataService();
            int id = rs.insertReserveOrderData(cusFullname, receiveDate);
            return id;
        }
        public int getMaxReserveID()
        {
            ReserveOrderDataService rs = new ReserveOrderDataService();
            int id = rs.getMaxReserveIdData();
            return id;
        }
    }
}