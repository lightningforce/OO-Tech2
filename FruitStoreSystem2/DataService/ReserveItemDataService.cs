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
    }
}