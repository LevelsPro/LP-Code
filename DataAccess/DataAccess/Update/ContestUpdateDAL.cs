using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
    public class ContestUpdateDAL : DataAccessBase
    {
        private Common.Contest _contest;
         private ContestUpdateDataParameters _insertParameters;

         public ContestUpdateDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_UpdateContest.ToString();
        }
        public void Update()
        {

            _insertParameters = new ContestUpdateDataParameters(Contest);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
        }

        public Common.Contest Contest
        {
            get
            {
                return _contest;
            }
            set
            {
                _contest = value;
            }
        }
    }
    public class ContestUpdateDataParameters
    {
        private Common.Contest _contest;
        private MySqlParameter[] _parameters;

        public ContestUpdateDataParameters(Common.Contest contest)
        {
            Contest = contest;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_ContestID",Contest.ContestID),
                                            new MySqlParameter("?p_ContestName",Contest.ContestName),
                                          new MySqlParameter("?p_RoleID",Contest.RoleID),
                                          new MySqlParameter("?p_Active",Contest.Active),
                                          new MySqlParameter("?p_ContestGraphics",Contest.ContestGraphics),
                                          new MySqlParameter("?p_ContestGraphicsExt",Contest.ContestGraphicsExt),
                                          new MySqlParameter("?p_ContestStartDate",Contest.ContestStartDate),
                                          new MySqlParameter("?p_ContestEndDate",Contest.ContestEndDate),
                                          new MySqlParameter("?p_Site_ID",Contest.SiteID),
                                          new MySqlParameter("?p_KPIID",Contest.KPIID)};
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
        public Common.Contest Contest
        {
            get
            {
                return _contest;
            }
            set
            {
                _contest = value;
            }
        }
    }
}
