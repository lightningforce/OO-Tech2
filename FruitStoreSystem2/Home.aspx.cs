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
        MySql.Data.MySqlClient.MySqlConnection conn;
        string myConnectionString;
        Entities en = new Entities();
        string connect = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string myConnectionString = "server=fruitstore.cloudapp.net;uid=root;" +
    "pwd=BSDnewgeneration;database=fruitstore;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex);
            }
            //MySqlConnection con = new MySqlConnection(connect);
            //con.Open();
        }
    }
}