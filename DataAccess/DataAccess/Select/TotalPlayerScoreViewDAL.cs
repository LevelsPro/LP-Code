using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient; 

namespace DataAccess.Select
{
    public class TotalPlayerScoreViewDAL :DataAccessBase
    {


    
        private Common.User _user;
        private PlayerScoreDataParameters _insertParameters;

        public TotalPlayerScoreViewDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetUserScoreAdmin.ToString();
        }
        public DataSet Update()
        {
            DataSet ds;
            _insertParameters = new PlayerScoreDataParameters(User);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
           ds= dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
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
    public class PlayerScoreDataParameters
    {
        private Common.User _user;
        private MySqlParameter[] _parameters;

        public PlayerScoreDataParameters(Common.User users)
        {
            User = users;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_UserID",User.UserID), 
                                              new MySqlParameter("?p_LevelID",User.CurrentLevel)
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

    

