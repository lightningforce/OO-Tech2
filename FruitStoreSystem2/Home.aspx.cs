using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.Common;
using ECS.DAL;

namespace FruitStoreSystem2
{
    public partial class Home : System.Web.UI.Page
    {
        Entities en = new Entities();
        string connect = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
           display("select * from customer");
        }
        private void display(string query)
        {
            DataSet ds = new DataSet();
            try
            {
                using (Entities en = new Entities())
                {
                    en.Open();
                    DbCommand cmd = en.CreateCommand(query);
                    cmd.CommandType = CommandType.Text;
                    DbDataAdapter da = en.CreateDataAdapter(cmd);
                    da.Fill(ds);
                }
                gdvFruit.DataSource = ds;
                gdvFruit.DataBind();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}