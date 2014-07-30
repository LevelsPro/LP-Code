using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{
   public class UserViewDAL : DataAccessBase
    {
       private Common.User _user;
       public UserViewDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetUser.ToString();
        }

        public DataSet View()
        {           
            DataSet ds;
            UserViewDataParameters _viewParameters = new UserViewDataParameters(User);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            //ds = dbHelper.Run(ConnectionString);
            ds = dbHelper.Run(base.ConnectionString, _viewParameters.Parameters);
            return ds;
        }

        public Common.User User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
            }
        }
    }

   public class UserViewDataParameters
   {
       private Common.User _user;
       private MySqlParameter[] _parameters;

       public UserViewDataParameters(Common.User user)
       {
           User = user;
           Build();
       }
       public void Build()
       {
           MySqlParameter[] parameters = {new MySqlParameter("?p_Where",User.Where)
                                          };
           Parameters = parameters;
       }
       public MySqlParameter[] Parameters
       {
           get
           {
               return _parameters;
           }
           set
           {
               _parameters = value;
           }
       }
       public Common.User User
       {
           get
           {
               return _user;
           }
           set
           {
               _user = value;
           }
       }
   }
}
