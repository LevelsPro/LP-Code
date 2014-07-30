using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlTypes;
namespace Common
{
  public class Roles
  {
      #region Private Members
      SqlInt32  _roleid;
      SqlString _rolename;
      SqlInt16 _active;
      SqlInt32 _activestatus;
      SqlInt32 _siteid;
      SqlString _imageName;
      SqlString _imageThumbNail;

      #endregion
      public Roles()
      {
      }
      #region Properties
      public SqlInt32 RoleID
      {
          get { return _roleid; }
          set { _roleid = value; }
      }
      public SqlInt32 ActiveStatus
      {
          get { return _activestatus; }
          set { _activestatus = value; }
      }
      public SqlString RoleName
      {
          get { return _rolename; }
          set { _rolename = value; }
      }
      public SqlInt16 Active
      {
          get { return _active; }
          set { _active = value; }
      }
      public SqlInt32 SiteID
      {
          get { return _siteid; }
          set { _siteid = value; }
      }
      public SqlString ImageName
      {
          get { return _imageName; }
          set { _imageName = value; }
      }

      public SqlString ImageThumbNail
      {
          get { return _imageThumbNail; }
          set { _imageThumbNail = value; }
      }
      #endregion
  }
}