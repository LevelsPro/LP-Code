using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccess.Insert
{
    public class QuestionsInsertDAL : DataAccessBase
    {
        private Common.Quiz _quiz;
        private QuestionInsertDataParameters _insertParameters;

        public QuestionsInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertQuestions.ToString();
        }
        public void Add()
        {

            _insertParameters = new QuestionInsertDataParameters(Quiz);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            
            int retu = dbHelper.Run(Quiz.sqlTransaction, base.ConnectionString, _insertParameters.Parameters);

            
            Quiz.QuestionID = Convert.ToInt32(((MySqlParameter)_insertParameters.Parameters[13]).Value);
            



        }

        public Common.Quiz Quiz
        {
            get
            {
                return _quiz;
            }
            set
            {
                _quiz = value;
            }
        }
    }
    public class QuestionInsertDataParameters
    {
        private Common.Quiz _quiz;
        private MySqlParameter[] _parameters;

        public QuestionInsertDataParameters(Common.Quiz quiz)
        {
            Quiz = quiz;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {   new MySqlParameter("?p_QuestionText",Quiz.Question),
                                              new MySqlParameter("?p_QuestionExplanation",Quiz.Explanation),
                                              new MySqlParameter("?p_Answer1",Quiz.Answer1),
                                              new MySqlParameter("?p_Answer2",Quiz.Answer2),
                                              new MySqlParameter("?p_Answer3",Quiz.Answer3),
                                              new MySqlParameter("?p_Answer4",Quiz.Answer4),
                                              new MySqlParameter("?p_CorrectAnswer",Quiz.Correct),
                                              new MySqlParameter("?p_Category",Quiz.Category),
                                              new MySqlParameter("?p_SiteID",Quiz.SiteID),                                              
                                              new MySqlParameter("?p_QuizID",Quiz.QuizID),
                                              new MySqlParameter("?p_QuestionImage",Quiz.QuestionImage),
                                              new MySqlParameter("?p_QuestionImageThumbnail",Quiz.QuestionImageThumbnail),
                                              new MySqlParameter("?p_ShortQuestion",Quiz.ShortQuestion)

                                             ,new MySqlParameter("?p_Qid", MySqlDbType.Int16, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, Quiz.QuestionID)
                                              //new MySqlParameter("?p_LevelID",MySqlDbType.Int32,4,System.Data.ParameterDirection.Output,true,0,0,"Award_ID",System.Data.DataRowVersion.Current,Levels.LevelID)

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
        public Common.Quiz Quiz
        {
            get
            {
                return _quiz;
            }
            set
            {
                _quiz = value;
            }
        }
    }
}
