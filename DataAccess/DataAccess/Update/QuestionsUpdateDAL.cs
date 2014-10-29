using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
  public  class QuestionsUpdateDAL : DataAccessBase
    {
     
        private Common.Quiz _quiz;
        private QuestionUpdateDataParameters _insertParameters;

         public QuestionsUpdateDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_UpdateQuestions.ToString();
        }
         public void Update()
        {

            _insertParameters = new QuestionUpdateDataParameters(Quiz);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
           
            int retu = dbHelper.Run(Quiz.sqlTransaction, base.ConnectionString, _insertParameters.Parameters);             
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
    public class QuestionUpdateDataParameters
    {
        private Common.Quiz _quiz;
        private MySqlParameter[] _parameters;

        public QuestionUpdateDataParameters(Common.Quiz quiz)
        {
            Quiz = quiz;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {   
                                              new MySqlParameter("?p_QuestionID",Quiz.QuestionID),
                                              new MySqlParameter("?p_QuestionText",Quiz.Question),
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
