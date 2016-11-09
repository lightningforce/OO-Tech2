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
            var objOrder = TextBox1.Text;    
            JObject order = JsonConvert.DeserializeObject<JObject>(@objOrder);     
            Console.WriteLine(order);
        }
    }
}