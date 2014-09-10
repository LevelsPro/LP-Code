using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using log4net;

namespace DataAccess.Select
{
    public class UsersInfoDAL : DataAccessBase
    {
        private static readonly ILog log = LogManager.GetLogger(
  System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Common.User _user;
        public UsersInfoDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetUsersInfoTemp.ToString();
        }

        public DataSet View()
        {
            DataSet ds = new DataSet();
            System.Diagnostics.Stopwatch timetaken= new System.Diagnostics.Stopwatch(); 
            timetaken.Start();
            try
            {
                UserInfoDataParameters _insertParameters = new UserInfoDataParameters(User);
                DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
                //ds = dbHelper.Run(ConnectionString);
                ds = dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (log.IsDebugEnabled)
                    {
                        log.Debug("User Authenticate Successfully, Taken Time in MS = " + timetaken.ElapsedMilliseconds + "Row Count = " + ds.Tables[0].Rows.Count);
                    }
                }

                }
           
            
            catch(Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("UserInfoDAL Error :" + ex.Message);
                }
            }

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
    public class UserInfoDataParameters
    {
        private Common.User _user;
        private MySqlParameter[] _parameters;

        public UserInfoDataParameters(Common.User user)
        {
            User = user;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_Name",User.UserName)
                                            //  ,  new MySqlParameter("?p_password",User.UserPassword)//,
                                           //new MySqlParameter("?p_SiteID",User.SiteID)
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
