using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DataAccess.Select
{
  public  class LevelGameViewDAL :DataAccessBase
    {
      public LevelGameViewDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetLevelGame.ToString();
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
