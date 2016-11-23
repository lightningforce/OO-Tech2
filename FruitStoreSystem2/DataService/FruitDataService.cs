using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using BSD.DAL;
using System.Text;

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
        public void insertFruitData(string fruitType,string fruitSeed,int amount)
        {
            using (DataAccess dac = new DataAccess())
            {
                dac.Open(Provider.MSSQL);
                DbCommand cmd = dac.CreateCommand("usp_InsertFruit");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(dac.CreateParameter("@in_fruitType",fruitType));
                cmd.Parameters.Add(dac.CreateParameter("@in_fruitSeed", fruitSeed));
                cmd.Parameters.Add(dac.CreateParameter("@in_amount", amount));
                cmd.ExecuteNonQuery();
            }
        }
        public void updateFruitData(string fruitType, string fruitSeed, int amount_a, int amount_b, int amount_c)
        {
            using (DataAccess dac = new DataAccess())
            {
                dac.Open(Provider.MSSQL);
                DbCommand cmd = dac.CreateCommand("usp_UpdateFruit");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(dac.CreateParameter("@in_fruitType", fruitType));
                cmd.Parameters.Add(dac.CreateParameter("@in_fruitSeed", fruitSeed));
                cmd.Parameters.Add(dac.CreateParameter("@in_amount_a", amount_a));
                cmd.Parameters.Add(dac.CreateParameter("@in_amount_b", amount_b));
                cmd.Parameters.Add(dac.CreateParameter("@in_amount_c", amount_c));
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable getUncatTable()
        {
            DataTable dt = new DataTable();
            StringBuilder strQuery = new StringBuilder();
            strQuery.Append("select ");
            strQuery.Append("f.fruitType");
            strQuery.Append(",f.fruitSeed");
            strQuery.Append(",fuc.amount as uncatAmount ");
            strQuery.Append("from Fruit f ");
            strQuery.Append("inner join FruitUnCat fuc ");
            strQuery.Append("on f.fruitID = fuc.fruitID ");
            strQuery.Append("order by f.fruitType,f.fruitSeed ");
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

        public DataTable getStockTable()
        {
            DataTable dt = new DataTable();
            StringBuilder strQuery = new StringBuilder();
            strQuery.Append("select ");
            strQuery.Append("f.fruitType");
            strQuery.Append(",f.fruitSeed");
            strQuery.Append(",fis.amount");
            strQuery.Append(",fis.grade ");
            strQuery.Append("from Fruit f ");
            strQuery.Append("inner join fruitInStock fis ");
            strQuery.Append("on f.fruitID = fis.fruitID ");
            strQuery.Append("order by f.fruitType,f.fruitSeed ");
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

        public int getUncatAmount(string fruitType, string fruitSeed)
        {
            int uncatAmount = 0;
            string query = "select amount from FruitUnCat inner join Fruit on Fruit.fruitID = FruitUnCat.FruitID where Fruit.fruitType = @fruitType and Fruit.fruitSeed = @fruitSeed";
            using (DataAccess dac = new DataAccess())
            {
                dac.Open(Provider.MSSQL);
                DbCommand cmd = dac.CreateCommand(query);
                cmd.Parameters.Add(dac.CreateParameter("@fruitType", fruitType));
                cmd.Parameters.Add(dac.CreateParameter("@fruitSeed", fruitSeed));
                uncatAmount = int.Parse(cmd.ExecuteScalar().ToString());
            }
            return uncatAmount;
        }
    }
}