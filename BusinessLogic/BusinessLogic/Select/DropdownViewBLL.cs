using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Select;
using System.Data;

namespace BusinessLogic.Select
{
    public class DropdownViewBLL : Transaction
    {
        private Common.Dropdown _dropdown;
        private DataSet _resultSet;

        public DropdownViewBLL()
        {
        }
        public void Invoke()
        {
            DropdownViewDAL viewData = new DropdownViewDAL();
            viewData.Dropdown = this.Dropdown;

            ResultSet = viewData.View();
        }

        public DataSet ResultSet
        {
            get
            {
                return _resultSet;
            }
            set
            {
                _resultSet = value;
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
