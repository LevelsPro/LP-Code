using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace Common
{
   public class LifeLine
    {
        #region Private Members
        SqlInt32 _lifelineid;
        SqlInt32 _userid;
        SqlInt32 _reducechoices;
        SqlInt32 _quizid;
        SqlInt32 _replacequestion;
        SqlInt32 _addcounter;
        SqlString _dateused;

        #endregion
        public LifeLine()
        {
        }
        #region Properties
        public SqlInt32 LifeLineID
        {
            get { return _lifelineid; }
            set { _lifelineid = value; }
        }
        public SqlInt32 UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
       
        public SqlInt32 ReduceChoices
        {
            get { return _reducechoices; }
            set { _reducechoices = value; }
        }
        public SqlInt32 QuizID
        {
            get { return _quizid; }
            set { _quizid = value; }
        }
        public SqlString DateUsed
        {
            get { return _dateused; }
            set { _dateused = value; }
        }
        
        public SqlInt32 ReplaceQuestion
        {
            get { return _replacequestion; }
            set { _replacequestion = value; }
        }

        
        public SqlInt32 AddCounter
        {
            get { return _addcounter; }
            set { _addcounter = value; }
        }
        
        #endregion
    }
}
