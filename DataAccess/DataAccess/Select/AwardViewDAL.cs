using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{
    public class AwardViewDAL : DataAccessBase
    {
        // private Common.Award _award;

        public AwardViewDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetAward.ToString();
        }

        public DataSet View()
        {
            DataSet ds;
            //AwardViewDataParameters _viewParameters = new AwardViewDataParameters(Award);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(ConnectionString);
            return ds;
        }
        //    public Common.Award Award
        //    {
        //        get
        //        {
        //            return _award;
        //        }
        //        set
        //        {
        //            _award = value;
        //        }
        //    }
        //}

        public class PlayerAwardViewDAL : DataAccessBase
        {
            private Common.Points _points;
            private PlayerAwardViewDataParameters _viewParameters;

            public PlayerAwardViewDAL()
            {
                StoredProcedureName = StoredProcedure.Select.sp_Player_GetAward.ToString();
            }

            public Common.Points Points
            {
                get
                {
                    return _points;
                }
                set
                {
                    _points = value;
                }
            }

            public DataSet View()
            {
                DataSet ds;
                _viewParameters = new PlayerAwardViewDataParameters(Points);
                DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
                ds = dbHelper.Run(base.ConnectionString, _viewParameters.Parameters);
                return ds;
            }
        }

        public class PlayerAwardViewDataParameters
        {
            private Common.Points _points;
            private MySqlParameter[] _parameters;

            public PlayerAwardViewDataParameters(Common.Points points)
            {
                Points = points;
                Build();
            }
            public void Build()
            {
                MySqlParameter[] parameters = {new MySqlParameter("?p_UserID",Points.UserID)
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
            public Common.Points Points
            {
                get
                {
                    return _points;
                }
                set
                {
                    _points = value;
                }
            }
        }

        public class AwardViewDetailsDAL : DataAccessBase
        {
            private Common.Award _award;
            private AwardViewDataParameters _viewParameters;

            public AwardViewDetailsDAL()
            {
                StoredProcedureName = StoredProcedure.Select.sp_GetAwardDetails.ToString();
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

            public DataSet View()
            {
                DataSet ds;
                _viewParameters = new AwardViewDataParameters(Award);
                DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
                ds = dbHelper.Run(base.ConnectionString, _viewParameters.Parameters);
                return ds;
            }
        }

        public class AwardViewDataParameters
        {
            private Common.Award _award;
            private MySqlParameter[] _parameters;

            public AwardViewDataParameters(Common.Award award)
            {
                Award = award;
                Build();
            }
            public void Build()
            {
                MySqlParameter[] parameters = {new MySqlParameter("?p_AwardID",Award.AwardID)
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
}
