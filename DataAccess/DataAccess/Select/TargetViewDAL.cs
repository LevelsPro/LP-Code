using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DataAccess.Select
{
   public class TargetViewDAL : DataAccessBase
    {
       public TargetViewDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetTarget.ToString();
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
