using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
   public class CategoryUpdateDAL : DataAccessBase
    {
       private Common.Quiz _quiz;
         private CategoryUpdateDataParameters _insertParameters;

         public CategoryUpdateDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_UpdateCategory.ToString();
        }
        public void Update()
        {

            _insertParameters = new CategoryUpdateDataParameters(Quiz);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);

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
    public class CategoryUpdateDataParameters
    {
        private Common.Quiz _quiz;
        private MySqlParameter[] _parameters;

        public CategoryUpdateDataParameters(Common.Quiz quiz)
        {
            Quiz = quiz;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_CategoryName", Quiz.CategoryName), 
                                            new MySqlParameter("?p_CategoryID", Quiz.Category)};
            
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
