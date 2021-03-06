﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Text;
using BSD.DAL;
namespace FruitStoreSystem2
{

    public class ReserveItemDataService
    {
        public DataTable getReserveItemData(string reserveID)
        {
            DataTable dt = new DataTable();
            StringBuilder strQuery = new StringBuilder();
            strQuery.Append("select ");
            strQuery.Append("f.fruitType");
            strQuery.Append(",f.fruitSeed");
            strQuery.Append(",ri.grade");
            strQuery.Append(",ri.quantity ");
            strQuery.Append("from ReserveItem ri ");
            strQuery.Append("inner join MapItemFruit m ");
            strQuery.Append("on ri.reserveItemID = m.reserveItemID ");
            strQuery.Append("inner join fruit f ");
            strQuery.Append("on m.fruitID = f.fruitID ");
            strQuery.Append("where ri.reserveID = @reserveID ");
            using (DataAccess dac = new DataAccess())
            {
                dac.Open(Provider.MSSQL);
                DbCommand cmd = dac.CreateCommand(strQuery.ToString());
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(dac.CreateParameter("@reserveID", reserveID));
                DbDataAdapter da = dac.CreateDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public void insertReserveItemData(int reserveID,int quantity,string fruitType,string fruitSeed,string grade)
        {
            using (DataAccess dac = new DataAccess())
            {
                dac.Open(Provider.MSSQL);
                DbCommand cmd = dac.CreateCommand("usp_InsertReserveItem");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(dac.CreateParameter("@in_reserveID", reserveID));
                cmd.Parameters.Add(dac.CreateParameter("@in_quantity", quantity));
                cmd.Parameters.Add(dac.CreateParameter("@in_fruitType", fruitType));
                cmd.Parameters.Add(dac.CreateParameter("@in_fruitSeed", fruitSeed));
                cmd.Parameters.Add(dac.CreateParameter("@in_grade", grade));
                cmd.ExecuteNonQuery();
            }
        }
        public void updateStockData(string fruitType,string fruitSeed,string grade,int amount)
        {
            using (DataAccess dac = new DataAccess())
            {
                dac.Open(Provider.MSSQL);
                DbCommand cmd = dac.CreateCommand("usp_UpdateStock");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(dac.CreateParameter("@in_fruitType", fruitType));
                cmd.Parameters.Add(dac.CreateParameter("@in_fruitSeed", fruitSeed));
                cmd.Parameters.Add(dac.CreateParameter("@in_grade", grade));
                cmd.Parameters.Add(dac.CreateParameter("@in_amount", amount));
                cmd.ExecuteNonQuery();
            }
        }
        public int getStockAmount(string fruitType, string fruitSeed, string grade)
        {
            int amount;
            StringBuilder strQuery = new StringBuilder();
            strQuery.Append("select ");
            strQuery.Append("FruitInStock.amount ");
            strQuery.Append("from FruitInStock ");
            strQuery.Append("inner join Fruit ");
            strQuery.Append("on FruitInStock.fruitID = Fruit.fruitID ");
            strQuery.Append("where Fruit.fruitType = @fruitType ");
            strQuery.Append("and Fruit.fruitSeed = @fruitSeed ");
            strQuery.Append("and FruitInStock.grade = @grade ");
            using (DataAccess dac = new DataAccess())
            {
                dac.Open(Provider.MSSQL);
                DbCommand cmd = dac.CreateCommand(strQuery.ToString());
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(dac.CreateParameter("@fruitType", fruitType));
                cmd.Parameters.Add(dac.CreateParameter("@fruitSeed", fruitSeed));
                cmd.Parameters.Add(dac.CreateParameter("@grade", grade));
                amount = int.Parse(cmd.ExecuteScalar().ToString());
            }
            return amount;
        }
    }
}