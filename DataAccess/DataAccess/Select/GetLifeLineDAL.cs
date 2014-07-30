using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccess.Select
{
    public class GetLifeLineDAL : DataAccessBase
    {

        public GetLifeLineDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetLifeLines.ToString();
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
