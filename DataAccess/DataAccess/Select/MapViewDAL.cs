using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DataAccess.Select
{
   
    public class MapViewDAL : DataAccessBase
    {
        public MapViewDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetMapDetail.ToString();
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
