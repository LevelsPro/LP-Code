using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{

    public class ContestPositionListViewDAL : DataAccessBase
    {
        private Common.Contest _contestpositionlist;
        public ContestPositionListViewDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetContestList.ToString();
        }

        public DataSet View()
        {
            DataSet ds;
            ContestPositionListViewDataParameters _viewParameters = new ContestPositionListViewDataParameters(ContestPositionList);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);

            ds = dbHelper.Run(base.ConnectionString, _viewParameters.Parameters);
            return ds;
        }

        public Common.Contest ContestPositionList
        {
            get
            {
                return _contestpositionlist;
            }
            set
            {
                _contestpositionlist = value;
            }
        }
    }

    public class ContestPositionListViewDataParameters
    {
        private Common.Contest _contestpositionlist;
        private MySqlParameter[] _parameters;

        public ContestPositionListViewDataParameters(Common.Contest contestpositionlist)
        {
            ContestPositionList = contestpositionlist;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_Where", ContestPositionList.Where)
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
        public Common.Contest ContestPositionList
        {
            get
            {
                return _contestpositionlist;
            }
            set
            {
                _contestpositionlist = value;
            }
        }
    }
}
