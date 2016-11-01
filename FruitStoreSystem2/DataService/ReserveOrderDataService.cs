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
    public class ReserveOrderDataService
    {
        public DataTable getReserveOrderData()
        {
            DataTable dt = new DataTable();
            StringBuilder strQuery = new StringBuilder();
            strQuery.Append("select ");
            strQuery.Append("r.reserveID");
            strQuery.Append(",c.cusFName + ' ' + c.cusLName as cus_fullname");
            strQuery.Append(",r.reserveDate");
            strQuery.Append(",r.receiveDate");
            strQuery.Append(",r.status ");
            strQuery.Append("from ReserveOrder r ");
            strQuery.Append("inner join Customer c ");
            strQuery.Append("on r.cusID = c.cusID ");
            using (DataAccess dac = new DataAccess())
            {
                dac.Open(Provider.MSSQL);
                DbCommand cmd = dac.CreateCommand(strQuery.ToString());
                cmd.CommandType = CommandType.Text;
                DbDataAdapter da = dac.CreateDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}