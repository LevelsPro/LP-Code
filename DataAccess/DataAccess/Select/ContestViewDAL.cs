using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Common;

namespace DataAccess.Select
{
   public class ContestViewDAL : DataAccessBase
    {
       public ContestViewDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetContest.ToString();
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
