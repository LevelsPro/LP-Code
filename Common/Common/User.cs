using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;
using MySql.Data.MySqlClient;


namespace Common
{

    public class User
    {
        #region Private Members
        SqlInt32 _userid;
        SqlString _username;
        SqlString _firstname;
        SqlString _userlastname;
        SqlString _usernickname;
        SqlString _userpassword;
        SqlString _useremail;
        SqlInt32 _siteid;
        SqlString _userfbid;
        SqlString _userfbpassword;
        SqlString _usertwid;
        SqlString _usertwpassword;
        SqlInt32 _roleid;
        SqlInt16 _active;
        SqlString _userRoles;
        SqlInt32 _activeupdatestatus;
        SqlInt32 _displayname;
        SqlInt32 _kpiid;
        SqlInt32 _score;
        SqlInt32 _achievedscore;
        SqlInt32 _levelPerformanceId;
        SqlInt32 _currentlevel;
        SqlInt32 _nextlevel;
        SqlInt32 _lastlevel;
        SqlInt32 _levelachieved;
        SqlInt32 _targetscores;
        SqlInt32 _previous;
        SqlInt32 _hours;

       

        SqlString _answer;




        SqlInt32 _managerid;

        SqlInt32 _securitytype;

        SqlString _where;

        SqlInt32 _questionid;
        SqlInt32 _poupupshowed;

        SqlInt32 _targetid;

        SqlInt32 _awardid;

        SqlString _measure;

        DateTime _entrydate;
        private MySqlTransaction _sqlTrans;

        #endregion
        public User()
        {
            QuestionID = 0;
        }

        #region Properties
        public SqlInt32 PreviousLevel
        {
            get { return _previous; }
            set { _previous = value; }
        }
        public SqlInt32 Hours
        {
            get { return _hours; }
            set { _hours = value; }
        }
        public SqlInt32 LevelPerformanceID
        {
            get { return _levelPerformanceId; }
            set { _levelPerformanceId = value; }
        }


        public SqlInt32 CurrentLevel
        {
            get { return _currentlevel; }
            set { _currentlevel = value; }
        }
        public SqlInt32 NextLevel
        {
            get { return _nextlevel; }
            set { _nextlevel = value; }
        }
        public SqlInt32 LastLevel
        {
            get { return _lastlevel; }
            set { _lastlevel = value; }
        }
        public SqlInt32 LevelAchieved
        {
            get { return _levelachieved; }
            set { _levelachieved = value; }
        }
        public SqlInt32 TargetScores
        {
            get { return _targetscores; }
            set { _targetscores = value; }
        }

        public SqlString UserRoles
        {
            get { return _userRoles; }
            set { _userRoles = value; }
        }


        public SqlInt32 UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        public SqlInt32 DisplayName
        {
            get { return _displayname; }
            set { _displayname = value; }
        }
        public SqlString UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        public SqlString FirstName
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        public SqlString UserLastName
        {
            get { return _userlastname; }
            set { _userlastname = value; }
        }
        public SqlString UserNickName
        {
            get { return _usernickname; }
            set { _usernickname = value; }
        }
        public SqlString UserPassword
        {
            get { return _userpassword; }
            set { _userpassword = value; }
        }
        public SqlString UserEmail
        {
            get { return _useremail; }
            set { _useremail = value; }
        }
        public SqlInt32 SiteID
        {
            get { return _siteid; }
            set { _siteid = value; }
        }
        public SqlString UserFbID
        {
            get { return _userfbid; }
            set { _userfbid = value; }
        }
        public SqlString UserFbPassword
        {
            get { return _userfbpassword; }
            set { _userfbpassword = value; }
        }
        public SqlString UserTwPassword
        {
            get { return _usertwpassword; }
            set { _usertwpassword = value; }
        }
        public SqlString UserTwID
        {
            get { return _usertwid; }
            set { _usertwid = value; }
        }

        public SqlInt32 RoleID
        {
            get { return _roleid; }
            set { _roleid = value; }
        }

        //public byte[] UserGraphic
        //{
        //    get { return _usergraphic; }
        //    set { _usergraphic = value; }
        //}
        //public SqlString UserGraphicExt
        //{  
        //    get { return _usergraphicext; }
        //    set { _usergraphicext = value; }
        //}
        public SqlInt16 Active
        {
            get { return _active; }
            set { _active = value; }
        }

        public SqlInt32 ActiveUpdateStatus
        {
            get { return _activeupdatestatus; }
            set { _activeupdatestatus = value; }
        }


        public SqlString Answer
        {
            get { return _answer; }
            set { _answer = value; }
        }


        public SqlInt32 QuestionID
        {
            get { return _questionid; }
            set { _questionid = value; }
        }


        public SqlInt32 ManagerID
        {
            get { return _managerid; }
            set { _managerid = value; }
        }

        public SqlInt32 Securitytype
        {
            get { return _securitytype; }
            set { _securitytype = value; }
        }

        public SqlInt32 Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public SqlInt32 KPIID
        {
            get { return _kpiid; }
            set { _kpiid = value; }
        }

        public SqlInt32 AchievedScore
        {
            get { return _achievedscore; }
            set { _achievedscore = value; }
        }

        public SqlString Where
        {
            get { return _where; }
            set { _where = value; }
        }

        public SqlInt32 PopupShowed
        {
            get { return _poupupshowed; }
            set { _poupupshowed = value; }
        }

        public SqlInt32 TargetID
        {
            get { return _targetid; }
            set { _targetid = value; }
        }

        public SqlInt32 AwardID
        {
            get { return _awardid; }
            set { _awardid = value; }
        }

        public SqlString Measure
        {
            get { return _measure; }
            set { _measure = value; }
        }

        public DateTime EntryDate
        {
            get { return _entrydate; }
            set { _entrydate = value; }
        }
        public MySqlTransaction sqlTransaction
        {
            get
            {
                return _sqlTrans;
            }
            set
            {
                _sqlTrans = value;
            }
        }
        #endregion
    }
}
