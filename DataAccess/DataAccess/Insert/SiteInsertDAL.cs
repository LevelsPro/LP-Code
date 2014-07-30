using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
    public class SiteInsertDAL : DataAccessBase
    {
    
        private Common.Site _site;
        private SiteInsertDataParameters _insertParameters;

        public SiteInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertSite.ToString();
        }
        public void Add()
        {

            _insertParameters = new SiteInsertDataParameters(Site);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
        }

        public Common.Site Site
        {
            get
            {
                return _site;
            }
            set
            {
                _site = value;
            }
        }
    }
    public class SiteInsertDataParameters
    {
        private Common.Site _site;
        private MySqlParameter[] _parameters;

        public SiteInsertDataParameters(Common.Site site)
        {
            Site = site;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_SiteName",Site.SiteName),
                                              new MySqlParameter("?p_SiteType", Site.SiteTypeName),
                                          new MySqlParameter("?p_SiteAddress", Site.SiteAddress)};
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
        public Common.Site Site
        {
            get
            {
                return _site;
            }
            set
            {
                _site = value;
            }
        }
    }
}
