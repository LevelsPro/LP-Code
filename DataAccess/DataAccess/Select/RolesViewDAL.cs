using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Common;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{
    public class RolesViewDAL: DataAccessBase
    {
       

        public RolesViewDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetRoles.ToString();
        }

        public DataSet View()
        {
            DataSet ds;
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(ConnectionString);
            return ds;
        }
       
    }
}
