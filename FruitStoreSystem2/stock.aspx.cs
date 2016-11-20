using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BSD.DAL;

namespace FruitStoreSystem2
{
    public partial class stock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.DataSource = GetFruit();
                DropDownList1.DataTextField = "fruitType";
                DropDownList1.DataValueField = "fruitType";
                DropDownList1.DataBind();

                DropDownList3.DataSource = GetFruit();
                DropDownList3.DataTextField = "fruitType";
                DropDownList3.DataValueField = "fruitType";
                DropDownList3.DataBind();

                Fruit f = new Fruit(string.Empty, string.Empty, null);
                showUncatStock.DataSource = f.getUncatTable();
                showUncatStock.DataBind();

                showGradedStock.DataSource = f.getStockTable();
                showGradedStock.DataBind();
            }

        }

        public DataTable GetFruit()
        {
            DataTable dt = new DataTable();
            Fruit f = new Fruit(string.Empty, string.Empty, null);
            dt = f.getFruitType();
            return dt;
        }

        public DataTable GetSeed(string type)
        {
            DataTable dt = new DataTable();
            Fruit f = new Fruit(string.Empty, string.Empty, null);
            dt = f.getFruitSeed(type);
            return dt;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fruitType = DropDownList1.SelectedValue;
            DropDownList2.DataSource = GetSeed(fruitType);
            DropDownList2.DataTextField = "fruitSeed";
            DropDownList2.DataValueField = "fruitSeed";
            DropDownList2.DataBind();
        }

        protected void DropDownList1_DataBound(object sender, EventArgs e)
        {
            string fruitType = DropDownList1.SelectedValue;
            DropDownList2.DataSource = GetSeed(fruitType);
            DropDownList2.DataTextField = "fruitSeed";
            DropDownList2.DataValueField = "fruitSeed";
            DropDownList2.DataBind();
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fruitType = DropDownList3.SelectedValue;
            DropDownList4.DataSource = GetSeed(fruitType);
            DropDownList4.DataTextField = "fruitSeed";
            DropDownList4.DataValueField = "fruitSeed";
            DropDownList4.DataBind();
        }

        protected void DropDownList3_DataBound(object sender, EventArgs e)
        {
            string fruitType = DropDownList3.SelectedValue;
            DropDownList4.DataSource = GetSeed(fruitType);
            DropDownList4.DataTextField = "fruitSeed";
            DropDownList4.DataValueField = "fruitSeed";
            DropDownList4.DataBind();
        }

        protected void InputConfirmButton_Click(object sender, EventArgs e)
        {
            string fruitType = DropDownList1.SelectedValue;
            string fruitSeed = DropDownList2.SelectedValue;
            int amount = int.Parse(TextBox1.Text);
            Insert(fruitType,fruitSeed,amount);
            Fruit f = new Fruit(string.Empty, string.Empty, null);
            showUncatStock.DataSource = f.getUncatTable();
            showUncatStock.DataBind();
        }
        private void Insert(string fruitType,string fruitSeed,int amount)
        {
            Fruit f = new Fruit(string.Empty, string.Empty, null);
            f.insertFruit(fruitType,fruitSeed,amount);
        }

        protected void SepConfirmButton_Click(object sender, EventArgs e)
        {
            string fruitType = DropDownList3.SelectedValue;
            string fruitSeed = DropDownList4.SelectedValue;
            int amount_a = int.Parse(TextBox2.Text);
            int amount_b = int.Parse(TextBox3.Text);
            int amount_c = int.Parse(TextBox4.Text);
            UpdateStock(fruitType, fruitSeed, amount_a, amount_b, amount_c);
            Fruit f = new Fruit(string.Empty, string.Empty, null);
            showGradedStock.DataSource = f.getStockTable();
            showGradedStock.DataBind();
        }
        private void UpdateStock(string fruitType, string fruitSeed, int amount_a, int amount_b, int amount_c)
        {
            Fruit f = new Fruit(string.Empty, string.Empty, null);
            f.updateFruit(fruitType, fruitSeed, amount_a, amount_b, amount_c);
        }
    }
}