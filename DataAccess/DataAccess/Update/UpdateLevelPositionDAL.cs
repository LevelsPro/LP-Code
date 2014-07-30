using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
   

    public class UpdateLevelPositionDAL : DataAccessBase
    {
        private Common.Levels _levels;
        private LevelPositionParameters _updateParameters;

        public UpdateLevelPositionDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_UpdateLevelPosition.ToString();
        }
        public void Update()
        {

            _updateParameters = new LevelPositionParameters(Levels);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _updateParameters.Parameters);

        }

        public Common.Levels Levels
        {
            get
            {
                return _levels;
            }
            set
            {
                _levels = value;
            }
        }
    }
    public class LevelPositionParameters
    {
        private Common.Levels _levels;
        private MySqlParameter[] _parameters;

        public LevelPositionParameters(Common.Levels levels)
        {
            Levels = levels;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_xml", Levels.XML) };

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
        public Common.Levels Levels
        {
            get
            {
                return _levels;
            }
            set
            {
                _levels = value;
            }
        }
    }
}
