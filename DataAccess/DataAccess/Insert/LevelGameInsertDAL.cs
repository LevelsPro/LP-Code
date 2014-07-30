using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
   public class LevelGameInsertDAL : DataAccessBase
    {
        private Common.LevelGame _game;
        private LevelGameInsertDataParameters _insertParameters;

        public LevelGameInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertLevelGame.ToString();
        }
        public void Add()
        {

            _insertParameters = new LevelGameInsertDataParameters(LevelGame);
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
    public class LevelGameInsertDataParameters
    {
        private Common.LevelGame _game;
        private MySqlParameter[] _parameters;

        public LevelGameInsertDataParameters(Common.LevelGame game)
        {
            LevelGame = game;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_GameName",LevelGame.GameName)
                                        
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
