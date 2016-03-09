
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
    public class DLUserRFPHeader : BaseDataLayer
    {

        public string ManageUserRFPHeaders(BLUserRFPHeader obj)
        {
            string result = string.Empty;

            string queryString = "CALL SP_MANAGEUSERRFPHEADER(?_RFPID, ?_USERID, ?_CURRENTSTAGINGOWNER, ?_RECENTDATE, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[8];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._RFPID, "?_RFPID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.Int32, obj._USERID, "?_USERID", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.Int32, obj._CURRENTSTAGINGOWNERVALUE, "?_CURRENTSTAGINGOWNER", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.DateTime, obj._RECENTDATE, "?_RECENTDATE", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.String, obj._ACTIVE, "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.DateTime, obj._CREATEDONDATE, "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[7] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            return (string)MySqlHelper.ExecuteScalar(connectionString, queryString, mySqlParam);
        }

        public DataSet GetUserRFPHeaders(BLUserRFPHeader obj)
        {
            if (obj._MODE == "BYID")
            {
                return GetUserRFPHeaderByID(obj);
            }
            else
            {
                return GetAllActiveUserRFPHeaders(obj);
            }
        }

        public DataSet GetUserRFPHeaderByID(BLUserRFPHeader obj)
        {
            string queryString = "CALL SP_MANAGEUSERRFPHEADER(?_RFPID, ?_USERID, ?_CURRENTSTAGINGOWNER, ?_RECENTDATE, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[8];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._RFPID, "?_RFPID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.Int32, obj._USERID, "?_USERID", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.Int32, obj._CURRENTSTAGINGOWNERVALUE, "?_CURRENTSTAGINGOWNER", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.DateTime, obj._RECENTDATE, "?_RECENTDATE", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.String, obj._ACTIVE, "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.DateTime, obj._CREATEDONDATE, "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[7] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);


            DataSet _ds = (DataSet)MySqlHelper.ExecuteDataset(connectionString, queryString, mySqlParam);
            return _ds;
        }

        public DataSet GetAllActiveUserRFPHeaders(BLUserRFPHeader obj)
        {
            string queryString = "CALL SP_MANAGEUSERRFPHEADER(?_RFPID, ?_USERID, ?_CURRENTSTAGINGOWNER, ?_RECENTDATE, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[8];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._RFPID, "?_RFPID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.Int32, obj._USERID, "?_USERID", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.Int32, obj._CURRENTSTAGINGOWNERVALUE, "?_CURRENTSTAGINGOWNER", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.DateTime, obj._RECENTDATE, "?_RECENTDATE", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.String, obj._ACTIVE, "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.DateTime, obj._CREATEDONDATE, "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[7] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            DataSet _ds = (DataSet)MySqlHelper.ExecuteDataset(connectionString, queryString, mySqlParam);
            return _ds;
        }

    }
}
