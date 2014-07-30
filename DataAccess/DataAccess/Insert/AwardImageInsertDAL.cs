using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
  public  class AwardImageInsertDAL: DataAccessBase
    {
      private Common.Award _award;
        private AwardImageInsertDataParameters _insertParameters;

        public AwardImageInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertAwardImage.ToString();
        }
        public void Add()
        {

            _insertParameters = new AwardImageInsertDataParameters(Award);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
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
    public class AwardImageInsertDataParameters
    {
        private Common.Award _award;
        private MySqlParameter[] _parameters;

        public AwardImageInsertDataParameters(Common.Award award)
        {
            Award = award;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {
                                          new MySqlParameter("?p_AwardImage",Award.AwardImage),
                                          new MySqlParameter("?p_AwardThumbnail",Award.AwardThumbnail),
                                          new MySqlParameter("?p_AwardID",Award.AwardID),
                                          new MySqlParameter("?p_CurrentImage",Award.CurrentImage)};
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
