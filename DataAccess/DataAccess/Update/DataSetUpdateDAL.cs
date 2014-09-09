using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
  public  class DataSetUpdateDAL : DataAccessBase
    {
     
        private Common.Match _match;
        private DataSetUpdateDataParameters _insertParameters;

         public DataSetUpdateDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_UpdateDataSet.ToString();
        }
         public void Update()
        {

            _insertParameters = new DataSetUpdateDataParameters(Match);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            //dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
            int retu = dbHelper.Run(Match.sqlTransaction, base.ConnectionString, _insertParameters.Parameters);             
        }

        public Common.Match Match
        {
            get
            {
                return _match;
            }
            set
            {
                _match = value;
            }
        }
    }
    public class DataSetUpdateDataParameters
    {
        private Common.Match _match;
        private MySqlParameter[] _parameters;

        public DataSetUpdateDataParameters(Common.Match match)
        {
            Match = match;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {   
                                              new MySqlParameter("?p_DataSetID", Match.DataSetID),
                                              new MySqlParameter("?p_DataSetElementsData", Match.DataElementData),
                                              new MySqlParameter("?p_SiteID",Match.SiteID),
                                              new MySqlParameter("?p_MatchID",Match.MatchID),
                                              new MySqlParameter("?p_DataSetImage",Match.DataSetImage),
                                              new MySqlParameter("?p_DataSetImageThumbnail",Match.DataSetImageThumbnail)
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
        public Common.Match Match
        {
            get
            {
                return _match;
            }
            set
            {
                _match = value;
            }
        }
    }
}
