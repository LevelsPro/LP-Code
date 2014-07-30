using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
   public class LevelGameDDLInsertDAL : DataAccessBase
    {
       private Common.LevelGame _game;
        private LevelGameDDLInsertDataParameters _insertParameters;

        public LevelGameDDLInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertLevelGameDLL.ToString();
        }
        public void Add()
        {

            _insertParameters = new LevelGameDDLInsertDataParameters(LevelGame);
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
    public class LevelGameDDLInsertDataParameters
    {
        private Common.LevelGame _game;
        private MySqlParameter[] _parameters;

        public LevelGameDDLInsertDataParameters(Common.LevelGame game)
        {
            LevelGame = game;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_GameDropdownName",LevelGame.GameDropDownName),
                                        new MySqlParameter("?p_GameID",LevelGame.GameID)
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
