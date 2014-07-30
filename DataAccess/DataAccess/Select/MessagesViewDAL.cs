using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DataAccess.Select
{    
    public class MessagesViewDAL : DataAccessBase
    {
        public MessagesViewDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetMessages.ToString();
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
