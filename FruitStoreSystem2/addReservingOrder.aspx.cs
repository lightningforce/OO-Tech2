using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace FruitStoreSystem2
{
    public partial class addReservingOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int reserveID;
            var objOrder = TextBox1.Text;
            JObject data = JObject.Parse(objOrder);
            string customer = data["customer"].ToString();
            string date = data["date"].ToString();
            customer = "Steve Jobs";
            reserveID = insertReserveOrder(customer, date);
            //if (!string.IsNullOrEmpty(customer) && !string.IsNullOrEmpty(date))
            //{
            //    reserveID = insertReserveOrder(customer, date);
            //}
            //else
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('กรุณาเลือกชื่อลูกค้าและวันที่รับผลไม้')", true);
            //}
            foreach (var order in data["order"])
            {
                string type = order["type"].ToString();
                string seed = order["seed"].ToString();
                int amount = int.Parse(order["amount"].ToString());
                string grade = order["grade"].ToString();
                type = "มะม่วง";
                seed = "ฟ้าลั่น";
                insertReserveItem(reserveID, amount, type, seed, grade);
            }
        }
        private int insertReserveOrder(string customer, string receiveDate)
        {
            ReserveOrders ro = new ReserveOrders(DateTime.Now, DateTime.Now, 0, string.Empty, string.Empty, null);
            ro.insertReserveOrder(customer, receiveDate);
            int id = ro.getMaxReserveID();
            return id;
        }
        public void insertReserveItem(int reserveID, int quantity, string fruitType,string fruitSeed, string grade)
        {
            ReserveItems ri = new ReserveItems(0, string.Empty, string.Empty, null);
            ri.insertReserveItem(reserveID, quantity, fruitType, fruitSeed, grade);
        }
    }
}