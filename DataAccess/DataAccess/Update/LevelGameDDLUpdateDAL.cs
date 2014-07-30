using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
  public  class LevelGameDDLUpdateDAL : DataAccessBase
    {
      
       private Common.LevelGame _game;
        private LevelGameDDLUpdateDataParameters _insertParameters;

        public LevelGameDDLUpdateDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_UpdateLevelGameDDL.ToString();
        }
        public void Update()
        {

            _insertParameters = new LevelGameDDLUpdateDataParameters(LevelGame);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);

        }

         public Common.LevelGame LevelGame
        {
            get
            {
                return _game;
            }
            set
            {
                _game = value;
            }
        }
    }
    public class LevelGameDDLUpdateDataParameters
    {
       private Common.LevelGame _game;
        private MySqlParameter[] _parameters;

        public LevelGameDDLUpdateDataParameters(Common.LevelGame game)
        {
            LevelGame = game;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_GameDropdownName",LevelGame.GameDropDownName),
                                              new MySqlParameter("?p_Active",LevelGame.Active),
                                              new MySqlParameter("?p_GameID",LevelGame.GameID),
                                              new MySqlParameter("?p_GameDropdownID",LevelGame.GameDropDownID)
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
       public Common.LevelGame LevelGame
        {
            get
            {
                return _game;
            }
            set
            {
                _game = value;
            }
        }
    }
}
