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
            if(!IsPostBack)
            {
                ReserveItems ri = new ReserveItems(0,string.Empty,string.Empty,null);
                //.ReserveID = "1";
                showSale.DataSource = ri.getReserveItem("1");
                showSale.DataBind();
            }
        }
    }
}