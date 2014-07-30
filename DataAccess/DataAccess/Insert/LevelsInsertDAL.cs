using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
    public class LevelsInsertDAL : DataAccessBase
    {
        private Common.Levels _levels;
        private LevelsInsertDataParameters _insertParameters;

        public LevelsInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertLevel.ToString();
        }
        public int Add()
        {

            _insertParameters = new LevelsInsertDataParameters(Levels);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);

            return Convert.ToInt32(((MySqlParameter)_insertParameters.Parameters[10]).Value);
        }

        public Common.Levels Levels
        {
            get
            {
                return _levels;
            }
            set
            {
                _levels = value;
            }
        }
    }

    public class LevelsInsertDataParameters
    {
        private Common.Levels _levels;
        private MySqlParameter[] _parameters;

        public LevelsInsertDataParameters(Common.Levels levels)
        {
            Levels = levels;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_LevelName", Levels.LevelName),
                                            new MySqlParameter("?p_RoleID", Levels.RoleID),
                                            new MySqlParameter("?p_LevelPosition", Levels.LevelPosition),
                                            new MySqlParameter("?p_BaseHours",Levels.BaseHours),
                                            new MySqlParameter("?p_Dimension_top",Levels.Dimension_top),
                                            new MySqlParameter("?p_Points",Levels.Points),
                                            new MySqlParameter("?p_Dimension_left",Levels.Dimension_left),
                                            new MySqlParameter("?p_CurrentlyIn",Levels.CurrentlyIn),
                                            new MySqlParameter("?p_Reach",Levels.Reach),
                                            new MySqlParameter("?p_Game",Levels.Game),
                                            new MySqlParameter("?p_LevelID",MySqlDbType.Int32,4,System.Data.ParameterDirection.Output,true,0,0,"Award_ID",System.Data.DataRowVersion.Current,Levels.LevelID)
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
        public Common.Levels Levels
        {
            get
            {
                return _levels;
            }
            set
            {
                _levels = value;
            }
        }
    }

}
