using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FruitStoreSystem2
{
    public partial class sales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string reserveID = string.Empty;
            
            if (!IsPostBack)
            {
                ReserveData data = (ReserveData)Session["DATA"];
                ReserveItems ri = new ReserveItems(0, string.Empty, string.Empty, null);
                //ri.ReserveID = "1";
                reserveID = data.reserveID;
                lblRI.Text = data.reserveID;
                //string[] str = data.reserveDate.Split(' ');
                lblRD.Text = data.reserveDate;
                lblCus.Text = data.cusFullname;
               // str = data.receiveDate.Split(' ') ;
                lblRecieveDate.Text = data.receiveDate;
                showSale.DataSource = ri.getReserveItem(data.reserveID);
                showSale.DataBind();

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ReserveOrders ro = new ReserveOrders(DateTime.Now, DateTime.Now, 0, string.Empty, string.Empty, null);
            string reserveID = lblRI.Text;
            ro.updateSellStatus(reserveID);
            Response.Redirect("Home.aspx");
        }
    }
}