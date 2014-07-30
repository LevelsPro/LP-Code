using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{
   public class UserImageViewDAL : DataAccessBase
    {
       private Common.UserImage _userimage;
       public UserImageViewDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetImage.ToString();
        }

        public DataSet View()
        {

            DataSet ds;
            UserImageViewDataParameters _viewParameters = new UserImageViewDataParameters(UserImages);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            //ds = dbHelper.Run(ConnectionString);
            ds = dbHelper.Run(base.ConnectionString, _viewParameters.Parameters);
            return ds;          
        }

        public Common.UserImage UserImages
        {
            get
            {
                return _userimage;
            }
            set
            {
                _userimage = value;
            }
        }
    }

   public class UserImageViewDataParameters
   {
       private Common.UserImage _userimage;
       private MySqlParameter[] _parameters;

       public UserImageViewDataParameters(Common.UserImage userimage)
       {
           UserImages = userimage;
           Build();
       }
       public void Build()
       {
           MySqlParameter[] parameters = {new MySqlParameter("?p_UserID",UserImages.UserID)
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
       public Common.UserImage UserImages
       {
           get
           {
               return _userimage;
           }
           set
           {
               _userimage = value;
           }
       }
   }
}
