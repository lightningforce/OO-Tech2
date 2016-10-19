using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECS.DAL;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace FruitStoreSystem2
{
    public partial class Home : System.Web.UI.Page
    {
        Entities en = new Entities();
        string connect = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connect);
            con.Open();
        }
    }
}