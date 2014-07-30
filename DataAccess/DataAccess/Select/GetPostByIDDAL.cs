using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{
    public class GetPostByIDDAL:DataAccessBase
    {
        public GetPostByIDDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetPostByID.ToString();
        }

        public DataSet View(int PostID)
        {
            DataSet ds;
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            MySqlParameter[] paras = {new MySqlParameter("?p_PostID", PostID)};
            ds = dbHelper.Run(ConnectionString,paras);
            return ds;
        }
    }
}
