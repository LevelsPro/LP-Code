using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace Common
{
  public  class LevelGame
    {
        #region Private Members
        SqlInt32 _gameid;
        SqlString _gamename;
        SqlString _gamedropdownname;
        SqlInt32 _gamedropdownid;
        SqlInt32 _active;

        #endregion
        public LevelGame()
        {
        }

        #region Properties
        public SqlInt32 GameID
        {
            get { return _gameid; }
            set { _gameid = value; }
        }
        public SqlString GameName
        {
            get { return _gamename; }
            set { _gamename = value; }
        }
        public SqlString GameDropDownName
        {
            get { return _gamedropdownname; }
            set { _gamedropdownname = value; }
        }
       
        public SqlInt32 GameDropDownID
        {
            get { return _gamedropdownid; }
            set { _gamedropdownid = value; }
        }
       
        public SqlInt32 Active
        {
            get { return _active; }
            set { _active = value; }
        }
       

        #endregion
    }
}
