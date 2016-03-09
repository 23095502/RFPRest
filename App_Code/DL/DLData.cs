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
    public class DLData : BaseDataLayer
    {

        public DataSet GetAllUsers(BLData obj)
        {
            string queryString = "CALL SP_GET_ALLUSERS()";

            DataSet _ds = (DataSet)MySqlHelper.ExecuteDataset(connectionString, queryString);
            return _ds;
        }

        public string ManageUsers(BLData obj)
        {
            string result = string.Empty;

            if (obj._USERID == null)
            {
                obj._USERID = 0;
            }

            string queryString = "CALL SP_MANAGEUSER(?_USERID, ?_USERCODE, ?_FIRSTNAME, ?_LASTNAME, ?_PASSWORD, ?_EMAILID, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[10];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._USERID, "?_USERID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.String, obj._USERCODE, "?_USERCODE", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.String, obj._FIRSTNAME, "?_FIRSTNAME", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.String, obj._LASTNAME, "?_LASTNAME", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.String, obj._PASSWORD, "?_PASSWORD", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.String, obj._EMAILID, "?_EMAILID", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.String, obj._ACTIVE, "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[7] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[8] = CreateParameters(DbType.String, obj._CREATEDON, "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[9] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            return (string)MySqlHelper.ExecuteScalar(connectionString, queryString, mySqlParam);
        }

        public DataSet GetUsers(BLData obj)
        {
            if (obj._MODE == "BYUSERID")
            {
                return GetUserByUserID(obj);
            }
            else if (obj._MODE == "GETALL")
            {
                return GetAllActiveUsers(obj);
            }
            else
            {
                return SearchUser(obj);
            }
        }

        public DataSet GetUserByUserID(BLData obj)
        {
            string queryString = "CALL SP_MANAGEUSER(?_USERID, ?_USERCODE, ?_FIRSTNAME, ?_LASTNAME, ?_PASSWORD, ?_EMAILID, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[10];
            
            mySqlParam[0] = CreateParameters(DbType.Int32, obj._USERID, "?_USERID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.String, "", "?_USERCODE", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.String, "", "?_FIRSTNAME", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.String, "", "?_LASTNAME", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.String, "", "?_PASSWORD", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.String, "", "?_EMAILID", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.String, "", "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[7] = CreateParameters(DbType.Int32, "1", "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[8] = CreateParameters(DbType.String, "1800-01-01", "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[9] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            DataSet _ds = (DataSet)MySqlHelper.ExecuteDataset(connectionString, queryString, mySqlParam);
            return _ds;
        }

        public DataSet GetAllActiveUsers(BLData obj)
        {
            string queryString = "CALL SP_MANAGEUSER(?_USERID, ?_USERCODE, ?_FIRSTNAME, ?_LASTNAME, ?_PASSWORD, ?_EMAILID, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[10];

            mySqlParam[0] = CreateParameters(DbType.Int32, "0", "?_USERID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.String, "", "?_USERCODE", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.String, "", "?_FIRSTNAME", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.String, "", "?_LASTNAME", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.String, "", "?_PASSWORD", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.String, "", "?_EMAILID", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.String, "", "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[7] = CreateParameters(DbType.Int32, "0", "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[8] = CreateParameters(DbType.String, "1800-01-01", "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[9] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);


            DataSet _ds = (DataSet)MySqlHelper.ExecuteDataset(connectionString, queryString, mySqlParam);
            return _ds;
        }

        public DataSet SearchUser(BLData obj)
        {
            string queryString = "CALL SP_MANAGEUSER(?_USERID, ?_USERCODE, ?_FIRSTNAME, ?_LASTNAME, ?_PASSWORD, ?_EMAILID, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[10];

            mySqlParam[0] = CreateParameters(DbType.Int32, "0", "?_USERID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.String, "", "?_USERCODE", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.String, obj._FIRSTNAME, "?_FIRSTNAME", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.String, obj._LASTNAME, "?_LASTNAME", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.String, "", "?_PASSWORD", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.String, "", "?_EMAILID", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.String, "", "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[7] = CreateParameters(DbType.Int32, "0", "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[8] = CreateParameters(DbType.String, "1800-01-01", "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[9] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);


            DataSet _ds = (DataSet)MySqlHelper.ExecuteDataset(connectionString, queryString, mySqlParam);
            return _ds;
        }
    }
}
