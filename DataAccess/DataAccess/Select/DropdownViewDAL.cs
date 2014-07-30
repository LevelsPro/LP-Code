using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccess.Select
{
    public class DropdownViewDAL : DataAccessBase
    {
        private Common.Dropdown _dropdown;
        private DropdownViewDataParameters _viewParameters;

        public DropdownViewDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetDropDown.ToString();
        }
        public DataSet View()
        {
            DataSet ds;
            _viewParameters = new DropdownViewDataParameters(Dropdown);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(base.ConnectionString, _viewParameters.Parameters);
            return ds;
        }

        public Common.Dropdown Dropdown
        {
            get
            {
                return _dropdown;
            }
            set
            {
                _dropdown = value;
            }
        }
    }

    public class DropdownViewDataParameters
    {
        private Common.Dropdown _dropdown;
        private MySqlParameter[] _parameters;

        public DropdownViewDataParameters(Common.Dropdown dropdown)
        {
            Dropdown = dropdown;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_ReferenceCode",Dropdown.ReferenceCode)
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
        public Common.Dropdown Dropdown
        {
            get
            {
                return _dropdown;
            }
            set
            {
                _dropdown = value;
            }
        }
    }
}
