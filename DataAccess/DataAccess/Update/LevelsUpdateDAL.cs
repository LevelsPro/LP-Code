using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
    public class LevelsUpdateDAL : DataAccessBase
    {
        private Common.Levels _levels;
        private LevelsUpdateDataParameters _insertParameters;

        public LevelsUpdateDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_UpdateLevel.ToString();
        }
        public void Update()
        {

            _insertParameters = new LevelsUpdateDataParameters(Levels);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);

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
    public class LevelsUpdateDataParameters
    {
        private Common.Levels _levels;
        private MySqlParameter[] _parameters;

        public LevelsUpdateDataParameters(Common.Levels levels)
        {
            Levels = levels;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_LevelID", Levels.LevelID), 
                                            new MySqlParameter("?p_LevelName", Levels.LevelName),
                                            new MySqlParameter("?p_RoleID", Levels.RoleID),
                                            new MySqlParameter("?p_Active", Levels.Active),
                                            new MySqlParameter("?p_LevelPosition", Levels.LevelPosition),
                                            new MySqlParameter("?p_BaseHours",Levels.BaseHours),
                                            new MySqlParameter("?p_Dimension_top",Levels.Dimension_top),
                                            new MySqlParameter("?p_Dimension_left",Levels.Dimension_left)}; 

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
