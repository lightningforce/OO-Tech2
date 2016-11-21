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
            if (!IsPostBack)
            {
                //setDropDownCustomerData();
                //setDropDownFruitType();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "myFunction", "aro.submitOrder();", true);
            int reserveID;
            var objOrder = TextBox1.Text;
            JObject data = JObject.Parse(objOrder);
            string customer = data["customer"].ToString();
            string date = data["date"].ToString();
            //customer = "Steve Jobs";
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
                //type = "มะม่วง";
                //seed = "ฟ้าลั่น";
                insertReserveItem(reserveID, amount, type, seed, grade);
            }
        }
        private int insertReserveOrder(string customer, string receiveDate)
        {
            ReserveOrders ro = new ReserveOrders(DateTime.Now, DateTime.Now, 0, string.Empty, string.Empty, null);
            int id = ro.insertReserveOrder(customer, receiveDate);
            //int id = ro.getMaxReserveID();
            return id;
        }
        public void insertReserveItem(int reserveID, int quantity, string fruitType, string fruitSeed, string grade)
        {
            ReserveItems ri = new ReserveItems(0, string.Empty, string.Empty, null);
            ri.insertReserveItem(reserveID, quantity, fruitType, fruitSeed, grade);
        }
        private void setDropDownCustomerData()
        {
            Customer cus = new Customer(string.Empty, string.Empty, string.Empty, string.Empty, null);
            ddlCustomer.DataSource = cus.getCustomerName();
            ddlCustomer.DataTextField = "cusFullName";
            ddlCustomer.DataValueField = "cusFullName";
            ddlCustomer.DataBind();
        }
        private void setDropDownFruitType()
        {
            Fruit f = new Fruit(string.Empty, string.Empty, null);
            ddlFruitType.DataSource = f.getFruitType();
            ddlFruitType.DataTextField = "fruitType";
            ddlFruitType.DataValueField = "fruitType";
            ddlFruitType.DataBind();
        }

        protected void ddlFruitType_DataBound(object sender, EventArgs e)
        {
            Fruit f = new Fruit(string.Empty, string.Empty, null);
            string fruitType = ddlFruitType.SelectedValue;
            ddlFruitSeed.DataSource = f.getFruitSeed(fruitType);
            ddlFruitSeed.DataTextField = "fruitSeed";
            ddlFruitSeed.DataValueField = "fruitSeed";
            ddlFruitSeed.DataBind();
        }

        protected void ddlFruitType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fruit f = new Fruit(string.Empty, string.Empty, null);
            string fruitType = ddlFruitType.SelectedValue;
            ddlFruitSeed.DataSource = f.getFruitSeed(fruitType);
            ddlFruitSeed.DataTextField = "fruitSeed";
            ddlFruitSeed.DataValueField = "fruitSeed";
            ddlFruitSeed.DataBind();
        }
    }
}