using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
//using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Microsoft.ApplicationBlocks.Data;
namespace DataAccess
{
    public class DataBaseHelper:DataAccessBase
    {
        private MySqlParameter[] _parameters;
        public DataBaseHelper(string storedProcedureName)
        {
            StoredProcedureName = storedProcedureName;
        }
        public DataSet   Run(string connectionString, MySqlParameter[] parameters)
        {
            DataSet ds;
            ds = SqlHelper.ExecuteDataset(connectionString, StoredProcedureName, parameters);
            return ds;
        }
        public DataSet Run(MySqlTransaction MySqlTransaction,  MySqlParameter[] parameters)
        {
            DataSet ds;
            ds = SqlHelper.ExecuteDataset(MySqlTransaction,CommandType.StoredProcedure, StoredProcedureName, parameters);
            return ds;
        }
        public int Run(MySqlTransaction MySqlTransaction, string  connectionString, MySqlParameter[] parameters)
        {
            int mRet;            
            mRet = SqlHelper.ExecuteNonQuery(MySqlTransaction, CommandType.StoredProcedure, StoredProcedureName, parameters);
            return mRet;         
        }
        #region Method Return Paramaeter Value 
        public object[] RunReturnParValue(string connectionString, MySqlParameter[] parameters)
        {
            object[] myobjreturn = SqlHelper.ExecuteNonQueryReturnValue(connectionString, StoredProcedureName, parameters);            
            return myobjreturn;
        }
        #endregion
        #region Method with sql Transactions
        public object[] RunReturnParValueSqlTrans(string connectionString, MySqlParameter[] parameters, MySqlTransaction MySqlTransaction)
        {
            object[] myobjreturn = SqlHelper.ExecuteNonQueryReturnValueSqlTrans(MySqlTransaction, connectionString, StoredProcedureName, parameters);
            return myobjreturn;
        }
        #endregion
        public object RunScalar(string connectionString, MySqlParameter[] parameters)
        {
            object obj;
            obj = SqlHelper.ExecuteScalar(connectionString, StoredProcedureName, parameters);
            return obj;
        }
        public DataSet Run(string connectionString)
        {
            DataSet ds;
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, StoredProcedureName);
            return ds;
        }        
        public void Run()
        {
            SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, StoredProcedureName, Parameters);
        }
        public MySqlDataReader Run(MySqlParameter[] parameters)
        {
            MySqlDataReader dr;
            dr = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.StoredProcedure, StoredProcedureName, parameters);
            return dr;
        }
        public MySqlDataReader Run(MySqlParameter[] parameters,MySqlTransaction MySqlTransaction)
        {
            MySqlDataReader dr;
            dr = SqlHelper.ExecuteReader(MySqlTransaction, CommandType.StoredProcedure, StoredProcedureName, parameters);
            return dr;
        }
        public MySqlParameter[] Parameters
        {
            get
            {
                return _parameters;
            }
            set
            {
                _parameters = value;
            }
        }
    }
}