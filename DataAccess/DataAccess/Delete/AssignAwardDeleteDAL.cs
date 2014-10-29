using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Delete
{
   public class AssignAwardDeleteDAL : DataAccessBase
    {
       
        private Common.Award _award;
        private AssignAwardDeleteDataParameters _deleteParameters;

        public AssignAwardDeleteDAL()
        {
            StoredProcedureName = StoredProcedure.Delete.sp_DeleteAssignAward.ToString();
        }
        public object Delete()
        {
            _deleteParameters = new AssignAwardDeleteDataParameters(Award);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            
            return dbHelper.Run(base.ConnectionString, _deleteParameters.Parameters);
        }

        public Common.Award Award
        {
            get
            {
                return _award;
            }
            set
            {
                _award = value;
            }
        }
    }

    public class AssignAwardDeleteDataParameters
    {
        private Common.Award _award;
        private MySqlParameter[] _parameters;

        public AssignAwardDeleteDataParameters(Common.Award award)
        {
            Award = award;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_AwardID", Award.AwardID),
                                          new MySqlParameter("?p_UserID", Award.UserID)};
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
        public Common.Award Award
        {
            get
            {
                return _award;
            }
            set
            {
                _award = value;
            }
        }
    }
}
