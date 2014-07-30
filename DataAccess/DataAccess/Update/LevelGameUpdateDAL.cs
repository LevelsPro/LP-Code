using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
   public class LevelGameUpdateDAL :DataAccessBase
    {
       private Common.LevelGame _game;
        private LevelGameUpdateDataParameters _insertParameters;

        public LevelGameUpdateDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_UpdateLevelGame.ToString();
        }
        public void Update()
        {

            _insertParameters = new LevelGameUpdateDataParameters(LevelGame);
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
    public class LevelGameUpdateDataParameters
    {
       private Common.LevelGame _game;
        private MySqlParameter[] _parameters;

        public LevelGameUpdateDataParameters(Common.LevelGame game)
        {
            LevelGame = game;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_GameName",LevelGame.GameName),
                                              new MySqlParameter("?p_Active",LevelGame.Active),
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
