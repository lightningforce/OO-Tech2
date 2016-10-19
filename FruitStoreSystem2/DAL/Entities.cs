using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Configuration;
using MySql.Data.Common;
using MySql.Data;
namespace ECS.DAL
{
    public class Entities : IDisposable
    {
        #region private properties
        private System.Data.Common.DbConnection _connection = null;
        private System.Data.Common.DbCommand _command = null;
        //private System.Data.Common.DbDataReader _reader = null;
        private string _serverName = string.Empty;
        private string _databaseName = string.Empty;
        private string _userName = string.Empty;
        private string _password = string.Empty;
        private string _connectionString = string.Empty;
        #endregion

        #region public properties
        public enum ENTITY_STATE
        {
            Insert,
            Update,
            Delete
        }
        #endregion

        #region constructor
        public Entities()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            if (_connectionString == null)
            {
                _connectionString = "Server=fruitstore.cloudapp.net;Port=3306;Database=fruitstore;Uid=root;Pwd=BSDnewgeneration;";
                //_connectionString = "Data Source=localhost\sqlserver2012;Initial Catalog=GSB;User ID=alm_focusconn;Password=alm_focus#c0nn;";
            }
        }

        public Entities(string connectionName)
        {
            _connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString; ;
            if (_connectionString == null)
            {
                //_connectionString = "Data Source=192.168.1.210;Initial Catalog=EICS;User ID=dev01;Password=password;";
                _connectionString = "Server=fruitstore.cloudapp.net;Port=3306;Database=fruitstore;Uid=root;Pwd=BSDnewgeneration;";
                //_connectionString = "Data Source=localhost\sqlserver2012;Initial Catalog=GSB;User ID=alm_focusconn;Password=alm_focus#c0nn;";
            }
        }
        public void Dispose()
        {
            if (_command != null)
            {
                _command.Dispose();
            }
            if (_connection != null)
            {
                _connection.Dispose();
            }
        }
        #endregion

        #region Private method

        private void CreateConnection()
        {
            if (_connection == null || _connection.State != System.Data.ConnectionState.Closed)
            {
                //_connection = new System.Data.SqlClient.SqlConnection(_connectionString);
                _connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString);
            }
            _connection.Open();
        }

        #endregion

        #region public methods
        /// <summary>
        /// open connection with default application config file
        /// </summary>
        public void Open()
        {
            CreateConnection();
            
        }
        /// <summary>
        /// create connetion
        /// </summary>
        /// <param name="serverName"></param>
        /// <param name="database"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public void Open(string connectionString) // string serverName, string database, string userName, string password)
        {
            _connectionString = connectionString;
            //_connectionString = "Data Source=192.168.1.210;Initial Catalog=EICS;User ID=dev01;Password=password;";
            CreateConnection();
        }
        public DbConnection GetConnection()
        {
            return _connection;
        }
        /// <summary>
        /// create command
        /// </summary>
        /// <returns></returns>
        public DbCommand CreateCommand()
        {
            //System.Data.Common.DbCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.Common.DbCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
            cmd.Connection = _connection;
            cmd.CommandTimeout = 180;
            return cmd;
        }
        /// <summary>
        /// create command with sql
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public DbCommand CreateCommand(string sqlString)
        {
            _command = CreateCommand();
            _command.CommandText = sqlString;
            return _command;
        }
        /// <summary>
        /// create parameter info
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="paramValue"></param>
        /// <returns></returns>
        public DbParameter CreateParameter(string paramName, object paramValue)
        {
            //return new System.Data.SqlClient.SqlParameter(paramName, paramValue);
            return new MySql.Data.MySqlClient.MySqlParameter(paramName,paramValue);
        }
        /// <summary>
        /// create data adapter
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public DbDataAdapter CreateDataAdapter(string sqlString)
        {
            //DbDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter((System.Data.SqlClient.SqlCommand)CreateCommand(sqlString));
            DbDataAdapter adapter = new MySql.Data.MySqlClient.MySqlDataAdapter((MySql.Data.MySqlClient.MySqlCommand)CreateCommand(sqlString));
            return adapter;
        }
        /// <summary>
        /// create adapter by command
        /// </summary>
        /// <param name="inCmd"></param>
        /// <returns></returns>
        public DbDataAdapter CreateDataAdapter(DbCommand inCmd)
        {
            //DbDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter((System.Data.SqlClient.SqlCommand)inCmd);
            DbDataAdapter adapter = new MySql.Data.MySqlClient.MySqlDataAdapter((MySql.Data.MySqlClient.MySqlCommand)inCmd);
            return adapter;
        }

        public DataSet GetDataBySQL(string sqlString, string resultName = "Table1")
        {
            DataSet ds = new DataSet();
            DbDataAdapter adapter = CreateDataAdapter(sqlString);
            adapter.Fill(ds, resultName);
            return ds;
        }

        public void SetCommand(DbCommand cmd)
        {
            _command = cmd;
        }

        public int SaveChanges()
        {
            return _command.ExecuteNonQuery();
        }
        #endregion
    }
}
