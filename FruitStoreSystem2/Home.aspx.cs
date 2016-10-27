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
using BSD.DAL;
namespace FruitStoreSystem2
{
    public partial class Home : System.Web.UI.Page
    {
        //string connect = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            displayCustomer();
            //display();
        }
        /// <summary>
        /// query from local mssql server
        /// </summary>
        private void displayCustomer()
        {
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string query = "select Firstname,Lastname,Phone,Address from Customer";
            try
            {
                //using (Dac dac = new Dac())
                //{
                //    dac.Open();
                //    DbCommand cmd = dac.CreateCommand(query);
                //    cmd.CommandType = CommandType.Text;
                //    DbDataAdapter da = dac.CreateDataAdapter(cmd);
                //    da.Fill(ds);
                //}
                using (DataAccess dac = new DataAccess())
                {
                    dac.Open(Provider.MSSQL);
                    DbCommand cmd = dac.CreateCommand(query);
                    cmd.CommandType = CommandType.Text;
                    DbDataAdapter da = dac.CreateDataAdapter(cmd);
                    da.Fill(dt);
                }
                gdvFruit.DataSource = dt;
                gdvFruit.DataBind();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// query from mysql on azure cloud
        /// </summary>
        private void display()
        {
            DataSet ds = new DataSet();
            string query = "select firstname,lastname,phone,address from customer";
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
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}