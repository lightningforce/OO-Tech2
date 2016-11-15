using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using BSD.DAL;
namespace FruitStoreSystem2
{
    public class FruitDataService
    {
        public DataTable getFruitTypeData()
        {
            DataTable dt = new DataTable();
            string query = "select distinct fruitType from Fruit";
            using (DataAccess dac = new DataAccess())
            {
                dac.Open(Provider.MSSQL);
                DbDataAdapter da = dac.CreateDataAdapter(query);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable getFruitSeedData(string fruitType)
        {
            DataTable dt = new DataTable();
            string query = "select fruitSeed from Fruit where fruitType = @fruitType";
            using (DataAccess dac = new DataAccess())
            {
                dac.Open(Provider.MSSQL);
                DbCommand cmd = dac.CreateCommand(query);
                cmd.Parameters.Add(dac.CreateParameter("@fruitType",fruitType));
                DbDataAdapter da = dac.CreateDataAdapter(cmd);

                da.Fill(dt);
            }
            return dt;
        }
    }
}