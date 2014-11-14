using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{

    public class ContestPositionViewDAL : DataAccessBase
    {
        private Common.Contest _contestposition;
        public ContestPositionViewDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetContestPositions.ToString();
        }

        public DataSet View()
        {
            DataSet ds;
            ContestPositionViewDataParameters _viewParameters = new ContestPositionViewDataParameters(ContestPosition);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);

            ds = dbHelper.Run(base.ConnectionString, _viewParameters.Parameters);
            return ds;
        }

        public Common.Contest ContestPosition
        {
            get
            {
                return _contestposition;
            }
            set
            {
                _contestposition = value;
            }
        }
    }

    public class ContestPositionViewDataParameters
    {
        private Common.Contest _contestposition;
        private MySqlParameter[] _parameters;

        public ContestPositionViewDataParameters(Common.Contest contestposition)
        {
            ContestPosition = contestposition;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_Where", ContestPosition.Where)
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
        public Common.Contest ContestPosition
        {
            get
            {
                return _contestposition;
            }
            set
            {
                _contestposition = value;
            }
        }
    }
}
