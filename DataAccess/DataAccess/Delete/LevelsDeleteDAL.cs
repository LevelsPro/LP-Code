using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Delete
{
  public  class LevelsDeleteDAL : DataAccessBase
    {
       private Common.Levels _level;
        private LevelDeleteDataParameters _deleteParameters;

        public LevelsDeleteDAL()
        {
            StoredProcedureName = StoredProcedure.Delete.sp_deletelevel.ToString();
        }
        public object Delete()
        {

            _deleteParameters = new LevelDeleteDataParameters(Levels);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            //dbHelper.RunScalar(base.ConnectionString, _deleteParameters.Parameters);
            return dbHelper.Run(base.ConnectionString, _deleteParameters.Parameters);
        }

        public Common.Levels Levels
        {
            get
            {
                return _level;
            }
            set
            {
                _level = value;
            }
        }
    }

    public class LevelDeleteDataParameters
    {
        private Common.Levels _level;
        private MySqlParameter[] _parameters;

        public LevelDeleteDataParameters(Common.Levels level)
        {
            Levels = level;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_LevelID",Levels.LevelID) ,
                 new MySqlParameter("?p_LevelPosition",Levels.LevelPosition) ,new MySqlParameter("?p_RoleID",Levels.RoleID) };
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
        public Common.Levels Levels
        {
            get
            {
                return _level;
            }
            set
            {
                _level = value;
            }
        }
    }
}
