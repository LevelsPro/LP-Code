using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace Common
{
    public class UserAwards
    {
        # region "Private Members"

        private SqlInt32 _userid;
        private SqlInt32 _awardid;
        private SqlDateTime _awarddate;
        private SqlInt32 _manual;
        private SqlInt32 _awardedby;

        #endregion

        public UserAwards()
        {
        }

        #region "Properties"

        public SqlInt32 User_Id
        {
            get
            {
                return _userid;
            }
            set
            {
                _userid = value;
            }
        }

        public SqlInt32 Award_Id
        {
            get
            {
                return _awardid;
            }
            set
            {
                _awardid = value;
            }
        }
        public SqlDateTime AwardDate
        {
            get
            {
                return _awarddate;
            }
            set
            {
                _awarddate = value;
            }
        }

        public SqlInt32 Manual
        {
            get
            {
                return _manual;
            }
            set
            {
                _manual = value;
            }
        }

        public SqlInt32 AwardedBy
        {
            get
            {
                return _awardedby;
            }
            set
            {
                _awardedby = value;
            }
        }

        #endregion
    }
}
