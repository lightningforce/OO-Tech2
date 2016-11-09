using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace FruitStoreSystem2
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtSearch.Attributes.Add("onKeyPress","doClick('" + btnSearch.ClientID + "',event)");
                ReserveOrders ro = new ReserveOrders(DateTime.Now, DateTime.Now, 0, string.Empty, string.Empty, null);
                gvReserveOrder.DataSource = ro.getReserveOrder();
                gvReserveOrder.DataBind();
            }
        }
      

        protected void gvReserveOrder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string reserveID = gvReserveOrder.DataKeys[e.Row.RowIndex].Value.ToString();
                ReserveItems ri = new ReserveItems(0, string.Empty, string.Empty, null);
                GridView gvReserveItem = e.Row.FindControl("gvReserveItem") as GridView;
                ri.ReserveID = reserveID;
                gvReserveItem.DataSource = ri.getReserveItem();
                gvReserveItem.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ReserveOrders ro = new ReserveOrders(DateTime.Now, DateTime.Now, 0, string.Empty, string.Empty, null);
            ro.CusFullName = txtSearch.Text;
            gvReserveOrder.DataSource = ro.serchReserveOrder();
            gvReserveOrder.DataBind();
        }
    }
}
