using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

using MySql.Data.MySqlClient;

namespace Common
{
    public class Quiz
    {
        #region Private Members

        SqlInt32 _quizid;
        SqlString _quizname;
        SqlInt32 _noofquestions;
        SqlInt32 _timeperquestion;
        SqlInt32 _timesplayableperday;
        SqlInt32 _timebeforepointsdeduction;
        SqlInt32 _pointsperquestion;
        SqlString _explanation;
        SqlInt32 _siteid;
        SqlInt32 _questionid;
        SqlInt32 _status;
        SqlInt32 _userid;
        SqlInt32 _iscorrect;
        SqlInt32 _achievedpoints;
        SqlString _shortquestion;
        SqlString _categoryname;

        SqlString _quiztime;
        SqlString _question;
        SqlString _answer1;
        SqlString _answer2;
        SqlString _answer3;
        SqlString _answer4;
        SqlString _correct;
        SqlInt32 _category;
        SqlInt32 _kpiID;

        SqlInt32 _levelid;
        SqlInt32 _roleid;
        SqlInt32 _elapsed;
        SqlInt32 _qid;
        SqlInt32 _questionpoints;
        SqlString _quizimage;
        SqlString _quizimagethumbnail;

        SqlString _questionimage;

       
        SqlString _questionimagethumbnail;

        

        SqlString _where;
        private MySqlTransaction _sqlTrans;
        #endregion
        public Quiz() { }

        #region Properties
        public SqlInt32 QuizID
        {
            get { return _quizid; }
            set { _quizid = value; }
        }

        public SqlInt32 KPIID
        {
            get { return _kpiID; }
            set { _kpiID = value; }
        }

        public SqlString QuizTime
        {
            get { return _quiztime; }
            set { _quiztime = value; }
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
        public SqlInt32 Status
        {
            get { return _status; }
            set { _status = value; }
        }
        public SqlString QuizName
        {
            get { return _quizname; }
            set { _quizname = value; }
        }
        public SqlString ShortQuestion
        {
            get { return _shortquestion; }
            set { _shortquestion = value; }
        }
        public SqlString CategoryName
        {
            get { return _categoryname; }
            set { _categoryname = value; }
        }
        public SqlInt32 NoOfQuestions
        {
            get { return _noofquestions; }
            set { _noofquestions = value; }
        }
        public SqlInt32 TimePerQuestion
        {
            get { return _timeperquestion; }
            set { _timeperquestion = value; }
        }
        public SqlInt32 TimesPlayablePerDay
        {
            get { return _timesplayableperday; }
            set { _timesplayableperday = value; }
        }
        public SqlInt32 TimeBeforePointsDeduction
        {
            get { return _timebeforepointsdeduction; }
            set { _timebeforepointsdeduction = value; }
        }

        public SqlInt32 PointsPerQuestion
        {
            get { return _pointsperquestion; }
            set { _pointsperquestion = value; }
        }
        public SqlString Explanation
        {
            get { return _explanation; }
            set { _explanation = value; }
        }
        public SqlInt32 SiteID
        {
            get { return _siteid; }
            set { _siteid = value; }
        }
        public SqlString QuestionImage
        {
            get { return _questionimage; }
            set { _questionimage = value; }
        }
        public SqlString QuestionImageThumbnail
        {
            get { return _questionimagethumbnail; }
            set { _questionimagethumbnail = value; }
        }

        public SqlInt32 QuestionID
        {
            get { return _questionid; }
            set { _questionid = value; }
        }
        public SqlInt32 LevelID
        {
            get { return _levelid; }
            set { _levelid = value; }
        }
        public SqlInt32 Elapsed
        {
            get { return _elapsed; }
            set { _elapsed = value; }
        }

        public SqlInt32 RoleID
        {
            get { return _roleid; }
            set { _roleid = value; }
        }
        public SqlInt32 QuestionPoints
        {
            get { return _questionpoints; }
            set { _questionpoints = value; }
        }
        public SqlInt32 Category
        {
            get { return _category; }
            set { _category = value; }
        }
        public SqlString Correct
        {
            get { return _correct; }
            set { _correct = value; }
        }
        public SqlString Answer1
        {
            get { return _answer1; }
            set { _answer1 = value; }
        }

        public SqlString Answer2
        {
            get { return _answer2; }
            set { _answer2 = value; }
        }


        public SqlString Answer3
        {
            get { return _answer3; }
            set { _answer3 = value; }
        }
        public SqlString Answer4
        {
            get { return _answer4; }
            set { _answer4 = value; }
        }
        public SqlString Question
        {
            get { return _question; }
            set { _question = value; }
        }

        public SqlInt32 QID
        {
            get { return _qid; }
            set { _qid = value; }
        }

        public SqlString QuizImage
        {
            get { return _quizimage; }
            set { _quizimage = value; }
        }

        public SqlString QuizImageThumbnail
        {
            get { return _quizimagethumbnail; }
            set { _quizimagethumbnail = value; }
        }

        public SqlString Where
        {
            get { return _where; }
            set { _where = value; }
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
