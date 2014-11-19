using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;
using MySql.Data.MySqlClient;

namespace Common
{
    public class Contest
    {
        #region Private Members
        SqlInt32 _contestid;        
        SqlString _contestname;        
        SqlString _fromdate;        
        SqlString _todate;        
        SqlInt32 _kpiid;        

        SqlInt32 _roleid;        
        SqlInt32 _siteid; 
       
        SqlInt32 _awardid;
        SqlInt32 _points;
        SqlInt32 _position;        

        SqlInt32 _userid;        
        SqlString _u_type;        
        SqlInt32 _typeid;        
        SqlInt32 _score;        
        SqlString _measure;        
        SqlString _entrydate;
        SqlString _where;
        SqlDateTime _ImportDate;
        private MySqlTransaction _sqlTrans;

        #endregion

        public Contest()
        {
        }

        #region Properties
        public SqlDateTime ImportDate
        {
            get { return _ImportDate; }
            set { _ImportDate = value; }
        }
        public SqlInt32 ContestID
        {
            get { return _contestid; }
            set { _contestid = value; }
        }
        public SqlString ContestName
        {
            get { return _contestname; }
            set { _contestname = value; }
        }
        public SqlString FromDate
        {
            get { return _fromdate; }
            set { _fromdate = value; }
        }
        public SqlString ToDate
        {
            get { return _todate; }
            set { _todate = value; }
        }
        public SqlInt32 KPIID
        {
            get { return _kpiid; }
            set { _kpiid = value; }
        }
        public SqlInt32 RoleID
        {
            get { return _roleid; }
            set { _roleid = value; }
        }
        public SqlInt32 SiteID
        {
            get { return _siteid; }
            set { _siteid = value; }
        }
        public SqlInt32 AwardID
        {
            get { return _awardid; }
            set { _awardid = value; }
        }
        public SqlInt32 Points
        {
            get { return _points; }
            set { _points = value; }
        }
        public SqlInt32 Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public SqlInt32 UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        public SqlString U_Type
        {
            get { return _u_type; }
            set { _u_type = value; }
        }
        public SqlInt32 TypeID
        {
            get { return _typeid; }
            set { _typeid = value; }
        }
        public SqlInt32 Score
        {
            get { return _score; }
            set { _score = value; }
        }
        public SqlString Measure
        {
            get { return _measure; }
            set { _measure = value; }
        }
        public SqlString EntryDate
        {
            get { return _entrydate; }
            set { _entrydate = value; }
        }
        public SqlString Where
        {
            get { return _where; }
            set { _where = value; }
        }
        public MySqlTransaction sqlTransaction
        {
            get { return _sqlTrans; }
            set { _sqlTrans = value; }
        }
        #endregion
    }
}
