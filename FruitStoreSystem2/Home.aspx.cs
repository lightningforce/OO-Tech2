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
                txtSearchSell.Attributes.Add("onKeyPress", "doClick('" + btnSearchSell.ClientID + "',event)");
                ReserveOrders ro = new ReserveOrders(DateTime.Now, DateTime.Now, 0, string.Empty, string.Empty, null);
                gvReserveOrder.DataSource = ro.getReserveOrder();
                gvReserveOrder.DataBind();
                gvSellOrder.DataSource = ro.getSaleOrder();
                gvSellOrder.DataBind();
            }
        }
      

        protected void gvReserveOrder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string reserveID = gvReserveOrder.DataKeys[e.Row.RowIndex].Value.ToString();
                ReserveItems ri = new ReserveItems(0, string.Empty, string.Empty, null);
                GridView gvReserveItem = e.Row.FindControl("gvReserveItem") as GridView;
                //ri.ReserveID = reserveID;
                gvReserveItem.DataSource = ri.getReserveItem(reserveID);
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

        protected void gvSellOrder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string reserveID = gvSellOrder.DataKeys[e.Row.RowIndex].Value.ToString();
                ReserveItems ri = new ReserveItems(0, string.Empty, string.Empty, null);
                GridView gvSellItem = e.Row.FindControl("gvSellItem") as GridView;
                //ri.ReserveID = reserveID;
                gvSellItem.DataSource = ri.getReserveItem(reserveID);
                gvSellItem.DataBind();
            }
        }

        protected void btnSearchSell_Click(object sender, EventArgs e)
        {
            ReserveOrders ro = new ReserveOrders(DateTime.Now, DateTime.Now, 0, string.Empty, string.Empty, null);
            ro.CusFullName = txtSearchSell.Text;
            gvSellOrder.DataSource = ro.searchSaleOrder();
            gvSellOrder.DataBind();
        }

        protected void gvReserveOrder_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gvReserveOrder = (sender as GridView);
            gvReserveOrder.PageIndex = e.NewPageIndex;
            ReserveOrders ro = new ReserveOrders(DateTime.Now, DateTime.Now, 0, string.Empty, string.Empty, null);
            gvReserveOrder.DataSource = ro.getReserveOrder();
            gvReserveOrder.DataBind();
        }

        protected void gvSellOrder_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gvSellOrder = (sender as GridView);
            gvSellOrder.PageIndex = e.NewPageIndex;
            ReserveOrders ro = new ReserveOrders(DateTime.Now, DateTime.Now, 0, string.Empty, string.Empty, null);
            gvSellOrder.DataSource = ro.getSaleOrder();
            gvSellOrder.DataBind();
        }
    }
}
