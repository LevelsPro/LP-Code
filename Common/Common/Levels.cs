using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlTypes;

namespace Common
{
    public class Levels
    {
        #region Private Members
        SqlInt32 _levelid;
        SqlInt32 _baseHours;
        SqlString _levelname;
        SqlInt32 _roleid;
        SqlInt16 _active;
        SqlInt32 _levelposition;
        SqlInt32 _siteid;
        SqlInt32 _dimensiontop;
        SqlInt32 _dimensionleft;
        SqlString _xml;
        SqlInt32 _points;
        SqlString _currentlyin;
        SqlString _reach;
        SqlString _game;

        #endregion
        public Levels()
        {
        }
        #region Properties

        public SqlInt32 LevelID
        {
            get { return _levelid; }
            set { _levelid = value; }
        }

        public SqlInt32 BaseHours
        {
            get { return _baseHours; }
            set { _baseHours = value; }
        }

        public SqlInt32 RoleID
        {
            get { return _roleid; }
            set { _roleid = value; }
        }
        public SqlString LevelName
        {
            get { return _levelname; }
            set { _levelname = value; }
        }
        public SqlInt16 Active
        {
            get { return _active; }
            set { _active = value; }
        }

        public SqlInt32 LevelPosition
        {
            get { return _levelposition; }
            set { _levelposition = value; }
        }
        public SqlInt32 SiteID
        {
            get { return _siteid; }
            set { _siteid = value; }
        }
        public SqlInt32 Dimension_top
        {
            get { return _dimensiontop; }
            set { _dimensiontop = value; }
        }
        public SqlInt32 Dimension_left
        {
            get { return _dimensionleft; }
            set { _dimensionleft = value; }
        }
        public SqlString XML
        {
            get { return _xml; }
            set { _xml = value; }
        }
        public SqlInt32 Points
        {
            get { return _points; }
            set { _points = value; }
        }

        public SqlString CurrentlyIn
        {
            get { return _currentlyin; }
            set { _currentlyin = value; }
        }
        public SqlString Reach
        {
            get { return _reach; }
            set { _reach = value; }
        }
        public SqlString Game
        {
            get { return _game; }
            set { _game = value; }
        }
        #endregion
    }
}
