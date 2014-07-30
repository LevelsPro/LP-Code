using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Delete
{
    public class MessageDeleteDAL : DataAccessBase
    {
        private Common.Messages _msg;
        private MessageDeleteDataParameters _deleteParameters;

        public MessageDeleteDAL()
        {
            StoredProcedureName = StoredProcedure.Delete.sp_DeleteMessage.ToString();
        }
        public object Delete()
        {

            _deleteParameters = new MessageDeleteDataParameters(Message);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
             //dbHelper.RunScalar(base.ConnectionString, _deleteParameters.Parameters);
             return dbHelper.Run(base.ConnectionString, _deleteParameters.Parameters);
        }

        public Common.Messages Message
        {
            get
            {
                return _msg;
            }
            set
            {
                _msg = value;
            }
        }
    }

    public class MessageDeleteDataParameters
    {
        private Common.Messages _msg;
        private MySqlParameter[] _parameters;

        public MessageDeleteDataParameters(Common.Messages msg)
        {
            Message = msg;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_MessageID", Message.MessageID) };
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
        public Common.Messages Message
        {
            get
            {
                return _msg;
            }
            set
            {
                _msg = value;
            }
        }
    }
}
