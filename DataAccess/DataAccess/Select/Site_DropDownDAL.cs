using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DataAccess.Select
{
   public class Site_DropDownDAL :DataAccessBase
    {

        public Site_DropDownDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetSites_ddl.ToString();
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
