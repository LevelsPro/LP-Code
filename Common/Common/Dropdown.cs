using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace Common
{
    public class Dropdown
    {
        #region Private Members
        SqlInt32 _referencedataid;
        SqlString _referencecode;
        SqlString _itemcode;
        SqlString _description;
        SqlInt32 _sortorder;
        SqlInt16 _active;        

        #endregion

        public Dropdown()
        {
        }

        #region Properties
        public SqlInt32 ReferenceDataID
        {
            get { return _referencedataid; }
            set { _referencedataid = value; }
        }
        public SqlString ReferenceCode
        {
            get { return _referencecode; }
            set { _referencecode = value; }
        }
        public SqlString ItemCode
        {
            get { return _itemcode; }
            set { _itemcode = value; }
        }
        public SqlString Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public SqlInt32 SortOrder
        {
            get { return _sortorder; }
            set { _sortorder = value; }
        }
        public SqlInt16 Active
        {
            get { return _active; }
            set { _active = value; }
        }        
        #endregion
    }
}
