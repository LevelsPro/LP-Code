using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
    public class SiteUpdateDAL : DataAccessBase
    {
         private Common.Site _site;
         private SiteUpdateDataParameters _insertParameters;

        public SiteUpdateDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_UpdateSite.ToString();
        }
        public void Update()
        {

            _insertParameters = new SiteUpdateDataParameters(Site);
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
    public class SiteUpdateDataParameters
    {
        private Common.Site _site;
        private MySqlParameter[] _parameters;

        public SiteUpdateDataParameters(Common.Site site)
        {
            Site = site;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_SiteID", Site.SiteID), 
                                            new MySqlParameter("?p_SiteName", Site.SiteName),
                                            new MySqlParameter("?p_SiteType", Site.SiteTypeName),
                                            new MySqlParameter("?p_SiteAddress", Site.SiteAddress),
                                          new MySqlParameter("?p_Active", Site.Active)};
            
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
