using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
   
    public class Level_LevelInfoUpdateDAL : DataAccessBase
    {
        private Common.Levels _levels;
        private LevelsInfoUpdateDataParameters _insertParameters;

        public Level_LevelInfoUpdateDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_level_UpdateLevelInfo.ToString();
        }
        public void Update()
        {

            _insertParameters = new LevelsInfoUpdateDataParameters(Levels);
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
    public class LevelsInfoUpdateDataParameters
    {
        private Common.Levels _levels;
        private MySqlParameter[] _parameters;

        public LevelsInfoUpdateDataParameters(Common.Levels levels)
        {
            Levels = levels;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_LevelID", Levels.LevelID), 
                                            new MySqlParameter("?p_LevelName", Levels.LevelName),                                           
                                            new MySqlParameter("?p_BaseHours",Levels.BaseHours),                                            
                                            new MySqlParameter("?p_Points",Levels.Points),
                                            new MySqlParameter("?p_CurrentlyIn",Levels.CurrentlyIn),
                                            new MySqlParameter("?p_Reach",Levels.Reach),
                                            new MySqlParameter("?p_Game",Levels.Game),
                                            new MySqlParameter("?p_levelImage",Levels.LevelImage),
                                             new MySqlParameter("?p_levelthumbnail",Levels.LevelThumbnail)
                                            //new MySqlParameter("?p_dimensiontop",Levels.Dimension_top),
                                            //new MySqlParameter("?p_dimensionleft",Levels.Dimension_left)
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
