using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
   public class CategoryInsertDAL : DataAccessBase
    {
         private Common.Quiz _quiz;
        private CategoryInsertDataParameters _insertParameters;

        public CategoryInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertCategory.ToString();
        }
        public void Add()
        {

            _insertParameters = new CategoryInsertDataParameters(Quiz);
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
    public class CategoryInsertDataParameters
    {
        private Common.Quiz _quiz;
        private MySqlParameter[] _parameters;

        public CategoryInsertDataParameters(Common.Quiz quiz)
        {
            Quiz = quiz;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_CategoryName", Quiz.CategoryName) };
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
