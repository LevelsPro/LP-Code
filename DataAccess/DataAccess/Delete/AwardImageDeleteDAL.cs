using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Delete
{
 public   class AwardImageDeleteDAL : DataAccessBase
    {
      private Common.Award _award;
        private AwardImageDeleteDataParameters _deleteParameters;

        public AwardImageDeleteDAL()
        {
            StoredProcedureName = StoredProcedure.Delete.sp_DeleteAwardImage.ToString();
        }
      public object Delete()
        {

            _deleteParameters = new AwardImageDeleteDataParameters(Award);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            //dbHelper.RunScalar(base.ConnectionString, _deleteParameters.Parameters);
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

    public class AwardImageDeleteDataParameters
    {
        private Common.Award _award;
        private MySqlParameter[] _parameters;

        public AwardImageDeleteDataParameters(Common.Award award)
        {
            Award = award;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_ID", Award.ID) };
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
