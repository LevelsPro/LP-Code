using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace Common
{
    public class PostTypes
    {
        #region Private Members
        SqlInt32 _postTypeID;
        SqlString _name;
        SqlDateTime _createDate;
        SqlInt32 _createdBy;
        SqlDateTime _modifiedDate;
        SqlInt32 _modifiedBy;

        #endregion

        #region "Properties"

        public SqlInt32 PostTypeID
        {
            get { return _postTypeID; }
            set { _postTypeID = value; }
        }
        public SqlString Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public SqlDateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }

        public SqlInt32 CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }

        public SqlDateTime ModifiedDate
        {
            get { return _modifiedDate; }
            set { _modifiedDate = value; }
        }

        public SqlInt32 ModifiedBy
        {
            get { return _modifiedBy; }
            set { _modifiedBy = value; }
        }
        #endregion
    }
}
