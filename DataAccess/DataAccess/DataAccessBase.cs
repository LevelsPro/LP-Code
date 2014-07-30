using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
namespace DataAccess
{
    public class DataAccessBase
    {
        private string _storedProcedureName;
        protected string StoredProcedureName
        {
            get
            {
                return _storedProcedureName;
            }
            set
            {
                _storedProcedureName = value;
            }
        }
        protected string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["SQLCONN"].ToString();
            }
        }
    }
}