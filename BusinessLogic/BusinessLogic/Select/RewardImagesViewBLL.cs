using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
  
    public class RewardImagesViewBLL : Transaction
    {
        private DataSet _resultSet;
        public RewardImagesViewBLL()
        {
        }
        public void Invoke()
        {
            RewardImagesViewDAL selectData = new RewardImagesViewDAL();
            ResultSet = selectData.View();
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
    }
}
