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
            }
            
        }

        public DataTable GetFruit()
        {
            DataTable dt = new DataTable();
            using (DataAccess da = new DataAccess())
            {
                da.Open(Provider.MSSQL);
                string query = "Select distinct fruitType from Fruit";
                DbCommand dbc = da.CreateCommand(query);
                DbDataAdapter dta = da.CreateDataAdapter(dbc);
                dta.Fill(dt);
            } 
            return dt;
        }

        public DataTable GetSeed(string type)
        {
            DataTable dt = new DataTable();
            using (DataAccess da = new DataAccess())
            {
                da.Open(Provider.MSSQL);
                string query = "Select distinct fruitSeed from Fruit where fruitType = @type";
                DbCommand dbc = da.CreateCommand(query);
                dbc.Parameters.Add(da.CreateParameter("@type", type));
                DbDataAdapter dta = da.CreateDataAdapter(dbc);
                dta.Fill(dt);
            }
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
    }
}