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
            strQuery.Append("where r.status = 'reserved' ");
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
        public DataTable searchReserveOrderData(string cusFullName)
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
            strQuery.Append("where r.status = 'reserved' ");
            strQuery.Append("and c.cusFname + ' ' + c.cusLName like @cusFullName");
            using (DataAccess dac = new DataAccess())
            {
                dac.Open(Provider.MSSQL);
                DbCommand cmd = dac.CreateCommand(strQuery.ToString());
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(dac.CreateParameter("@cusFullName", "%" + cusFullName + "%"));
                DbDataAdapter da = dac.CreateDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable getSaleOrderData()
        {
            DataTable dt = new DataTable();
            StringBuilder strQuery = new StringBuilder();
            strQuery.Append("select ");
            strQuery.Append("r.reserveID");
            strQuery.Append(",c.cusFName + ' ' + c.cusLName as cus_fullname");
            strQuery.Append(",r.reserveDate");
            strQuery.Append(",r.sellDate");
            strQuery.Append(",r.status ");
            strQuery.Append("from ReserveOrder r ");
            strQuery.Append("inner join Customer c ");
            strQuery.Append("on r.cusID = c.cusID ");
            strQuery.Append("where r.status = 'sold' ");
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
        public DataTable searchSaleOrderData(string cusFullName)
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
            strQuery.Append("where r.status = 'sold' ");
            strQuery.Append("and c.cusFname + ' ' + c.cusLName like @cusFullName");
            using (DataAccess dac = new DataAccess())
            {
                dac.Open(Provider.MSSQL);
                DbCommand cmd = dac.CreateCommand(strQuery.ToString());
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(dac.CreateParameter("@cusFullName", "%" + cusFullName + "%"));
                DbDataAdapter da = dac.CreateDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public void insertReserveOrderData(string cusFullName, string receiveDate)
        {
            //int id;
            using (DataAccess dac = new DataAccess())
            {
                dac.Open(Provider.MSSQL);
                DbCommand cmd = dac.CreateCommand("usp_InsertReserveOrder");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(dac.CreateParameter("@in_cusFullname", cusFullName));
                cmd.Parameters.Add(dac.CreateParameter("@in_receiveDate", receiveDate)); 
                cmd.ExecuteNonQuery();

            }
        }
        public int getMaxReserveIdData()
        {
            int id;
            DataTable dt = new DataTable();
            StringBuilder strQuery = new StringBuilder();
            strQuery.Append("select ");
            strQuery.Append("max(reserveID) as reserveID ");
            strQuery.Append("from ReserveOrder");
            using (DataAccess dac = new DataAccess())
            {
                dac.Open(Provider.MSSQL);
                DbCommand cmd = dac.CreateCommand(strQuery.ToString());
                cmd.CommandType = CommandType.Text;
                DbDataAdapter da = dac.CreateDataAdapter(cmd);
                da.Fill(dt);
            }
            id = int.Parse(dt.Rows[0]["reserveID"].ToString());
            return id;
        }
        public void updateSellStatus(string reserveID)
        {
            
            StringBuilder strQuery = new StringBuilder();
            strQuery.Append("update ReserveOrder ");
            strQuery.Append("set status = 'sold'");
            strQuery.Append(",sellDate = getdate() ");
            strQuery.Append("where reserveID =  @reserveID");
            using (DataAccess dac = new DataAccess())
            {
                dac.Open(Provider.MSSQL);
                DbCommand cmd = dac.CreateCommand(strQuery.ToString());
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(dac.CreateParameter("@reserveID", reserveID));
                cmd.ExecuteNonQuery();
            }
        }
    }
}