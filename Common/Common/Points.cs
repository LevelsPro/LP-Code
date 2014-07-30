using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace Common
{
   public class Points
    {
        #region Private Members
      SqlInt32  _userid;
      SqlString _type;
      SqlInt32  _typeid;
      SqlInt32 _score;
      SqlString _measure;
      

      #endregion
      public Points()
      {
      }
      #region Properties

      public SqlInt32 UserID
      {
          get { return _userid; }
          set { _userid = value; }
      }

      public SqlString Type
      {
          get { return _type; }
          set { _type = value; }
      }
      public SqlInt32 RewardID
      {
          get { return _typeid; }
          set { _typeid = value; }
      }
      public SqlInt32 RedeemPoints
      {
          get { return _score; }
          set { _score = value; }
      }
      public SqlString Measure
      {
          get { return _measure; }
          set { _measure = value; }
      }
      
      #endregion
    }
}
