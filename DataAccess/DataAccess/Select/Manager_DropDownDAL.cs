using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DataAccess.Select
{
    public class Manager_DropDownDAL : DataAccessBase
    {

        public Manager_DropDownDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetUsers_Manager.ToString();
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
