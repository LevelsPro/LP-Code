using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

using MySql.Data.MySqlClient;

namespace Common
{
    public class Match
    {
        #region Private Members

        SqlInt32 _matchid;
        SqlString _matchname;
        SqlInt32 _pointsforcompletation;
        SqlInt32 _maxplaysperday;
        SqlInt32 _noofdataset;
        SqlInt32 _noofrounds;
        SqlInt32 _kpiID;

        SqlInt32 _elementid;
        SqlString _elementname;
        SqlInt32 _ispicture;        

        SqlInt32 _roundid;
        SqlInt32 _noround;
        SqlString _roundname;
        SqlInt32 _nodatasetperround;
        SqlInt32 _pointsperround;
        SqlInt32 _timeperround;
        SqlInt32 _showhint;        
        
        SqlInt32 _siteid;
        SqlInt32 _datasetid;
        SqlString _dataelementdata;        
        SqlInt32 _status;
        SqlInt32 _userid;
        SqlInt32 _iscorrect;
        SqlInt32 _achievedpoints;
        SqlString _correct;
        SqlInt32 _levelid;
        SqlInt32 _roleid;
        SqlInt32 _elapsed;
        SqlInt32 _datasetpoints;
        SqlString _matchimage;
        SqlString _matchimagethumbnail;
        SqlString _datasetimage;
        SqlString _datasetimagethumbnail;

        SqlString _matchtime;        
        SqlInt32 _matchplays;       

        SqlString _where;        
        private MySqlTransaction _sqlTrans;
        
        #endregion
        public Match() { }

        #region Properties
        public SqlInt32 MatchID
        {
            get { return _matchid; }
            set { _matchid = value; }
        }
        public SqlString MatchName
        {
            get { return _matchname; }
            set { _matchname = value; }
        }
        public SqlInt32 PointsForCompletation
        {
            get { return _pointsforcompletation; }
            set { _pointsforcompletation = value; }
        }
        public SqlInt32 MaxPlaysPerDay
        {
            get { return _maxplaysperday; }
            set { _maxplaysperday = value; }
        }
        public SqlInt32 NoOfDataSet
        {
            get { return _noofdataset; }
            set { _noofdataset = value; }
        }
        public SqlInt32 NoOfRounds
        {
            get { return _noofrounds; }
            set { _noofrounds = value; }
        }
        public SqlInt32 KPIID
        {
            get { return _kpiID; }
            set { _kpiID = value; }
        }
        public SqlInt32 RoundID
        {
            get { return _roundid; }
            set { _roundid = value; }
        }
        public SqlInt32 NoRound
        {
            get { return _noround; }
            set { _noround = value; }
        }
        public SqlString RoundName
        {
            get { return _roundname; }
            set { _roundname = value; }
        }
        public SqlInt32 NoDataSetPerRound
        {
            get { return _nodatasetperround; }
            set { _nodatasetperround = value; }
        }
        public SqlInt32 PointsPerRound
        {
            get { return _pointsperround; }
            set { _pointsperround = value; }
        }
        public SqlInt32 TimePerRound
        {
            get { return _timeperround; }
            set { _timeperround = value; }
        }
        public SqlInt32 ShowHint
        {
            get { return _showhint; }
            set { _showhint = value; }
        }
        public SqlInt32 SiteID
        {
            get { return _siteid; }
            set { _siteid = value; }
        }
        public SqlInt32 DataSetID
        {
            get { return _datasetid; }
            set { _datasetid = value; }
        }
        public SqlString DataElementData
        {
            get { return _dataelementdata; }
            set { _dataelementdata = value; }
        }
        public SqlInt32 Status
        {
            get { return _status; }
            set { _status = value; }
        }
        public SqlInt32 UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        public SqlInt32 IsCorrect
        {
            get { return _iscorrect; }
            set { _iscorrect = value; }
        }
        public SqlInt32 AchievedPoints
        {
            get { return _achievedpoints; }
            set { _achievedpoints = value; }
        }
        public SqlString Correct
        {
            get { return _correct; }
            set { _correct = value; }
        }
        public SqlInt32 LevelID
        {
            get { return _levelid; }
            set { _levelid = value; }
        }
        public SqlInt32 RoleID
        {
            get { return _roleid; }
            set { _roleid = value; }
        }
        public SqlInt32 Elapsed
        {
            get { return _elapsed; }
            set { _elapsed = value; }
        }
        public SqlInt32 DataSetPoints
        {
            get { return _datasetpoints; }
            set { _datasetpoints = value; }
        }
        public SqlString MatchImage
        {
            get { return _matchimage; }
            set { _matchimage = value; }
        }
        public SqlString MatchImageThumbnail
        {
            get { return _matchimagethumbnail; }
            set { _matchimagethumbnail = value; }
        }
        public SqlString DataSetImage
        {
            get { return _datasetimage; }
            set { _datasetimage = value; }
        }
        public SqlString DataSetImageThumbnail
        {
            get { return _datasetimagethumbnail; }
            set { _datasetimagethumbnail = value; }
        }
        public SqlInt32 ElementID
        {
            get { return _elementid; }
            set { _elementid = value; }
        }
        public SqlString ElementName
        {
            get { return _elementname; }
            set { _elementname = value; }
        }
        public SqlInt32 IsPicture
        {
            get { return _ispicture; }
            set { _ispicture = value; }
        }
        public SqlString MatchTime
        {
            get { return _matchtime; }
            set { _matchtime = value; }
        }
        public SqlInt32 MatchPlays
        {
            get { return _matchplays; }
            set { _matchplays = value; }
        }
        public SqlString Where
        {
            get { return _where; }
            set { _where = value; }
        }
        public MySqlTransaction sqlTransaction
        {
            get { return _sqlTrans; }
            set { _sqlTrans = value; }
        }
        #endregion
    }
}
