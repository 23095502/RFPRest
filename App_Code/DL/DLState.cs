
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using DVPRWCFService.BusinessLayer;

namespace DVPRWCFService.DataLayer
{
    public class DLState : BaseDataLayer
    {
        public string ManageStates(BLState obj)
        {
            string result = string.Empty;

            string queryString = "CALL SP_MANAGESTATE(?_STATEID, ?_STATECODE, ?_STATENAME, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[7];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._STATEID, "?_STATEID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.String, obj._STATECODE, "?_STATECODE", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.String, obj._STATENAME, "?_STATENAME", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.String, obj._ACTIVE, "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.DateTime, obj._CREATEDON, "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            return (string)MySqlHelper.ExecuteScalar(connectionString, queryString, mySqlParam);
        }

        public DataSet GetStates(BLState obj)
        {
            if (obj._MODE == "BYSTATEID")
            {
                return GetStateByStateID(obj);
            }
            else if (obj._MODE == "GETALL")
            {
                return GetAllActiveStates(obj);
            }
            else
            {
                return SearchStates(obj);
            }
        }

        public DataSet GetStateByStateID(BLState obj)
        {
            string queryString = "CALL SP_MANAGEState(?_STATEID, ?_STATECODE, ?_STATENAME, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[7];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._STATEID, "?_STATEID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.String, obj._STATECODE, "?_STATECODE", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.String, obj._STATENAME, "?_STATENAME", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.String, obj._ACTIVE, "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.DateTime, obj._CREATEDON, "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            DataSet _ds = (DataSet)MySqlHelper.ExecuteDataset(connectionString, queryString, mySqlParam);
            return _ds;
        }

        public DataSet GetAllActiveStates(BLState obj)
        {
            string queryString = "CALL SP_MANAGEState(?_STATEID, ?_STATECODE, ?_STATENAME, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[7];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._STATEID, "?_STATEID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.String, obj._STATECODE, "?_STATECODE", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.String, obj._STATENAME, "?_STATENAME", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.String, obj._ACTIVE, "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.DateTime, obj._CREATEDON, "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            DataSet _ds = (DataSet)MySqlHelper.ExecuteDataset(connectionString, queryString, mySqlParam);
            return _ds;
        }

        public DataSet SearchStates(BLState obj)
        {
            string queryString = "CALL SP_MANAGEState(?_STATEID, ?_STATECODE, ?_STATENAME, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[7];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._STATEID, "?_STATEID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.String, obj._STATECODE, "?_STATECODE", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.String, obj._STATENAME, "?_STATENAME", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.String, obj._ACTIVE, "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.DateTime, obj._CREATEDON, "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            DataSet _ds = (DataSet)MySqlHelper.ExecuteDataset(connectionString, queryString, mySqlParam);
            return _ds;
        }

    }
}
