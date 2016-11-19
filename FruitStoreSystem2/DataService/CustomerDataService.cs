using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Text;
using BSD.DAL;
namespace FruitStoreSystem2
{
    public class CustomerDataService
    {
        public DataTable getCustomerNameData()
        {
            string query = "select cusFName + ' ' + cusLName as cusFullname from Customer";
            DataTable dt = new DataTable();
            using (DataAccess dac = new DataAccess())
            {
                dac.Open(Provider.MSSQL);
                DbDataAdapter da = dac.CreateDataAdapter(query);
                da.Fill(dt);
            }
            return dt;
        }
    }
}