using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{
  public  class LevelGameDDLViewDAL : DataAccessBase
    {
      private Common.LevelGame _game;
      public LevelGameDDLViewDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetLevelGameDDL.ToString();
        }

        public DataSet View()
        {

            DataSet ds;
            LevelGameDDLDataParameters _insertParameters = new LevelGameDDLDataParameters(Game);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);            
            ds = dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
            return ds;           
        }

        public Common.LevelGame Game
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

  public class LevelGameDDLDataParameters
  {
      private Common.LevelGame _game;
      private MySqlParameter[] _parameters;

      public LevelGameDDLDataParameters(Common.LevelGame game)
      {
          Game = game;
          Build();
      }
      public void Build()
      {
          MySqlParameter[] parameters = {new MySqlParameter("?p_GameID",Game.GameID)
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
      public Common.LevelGame Game
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
