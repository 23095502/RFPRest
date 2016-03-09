
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
    public class DLLocation : BaseDataLayer
    {

        public string ManageLocations(BLLocation obj)
        {
            string result = string.Empty;

            if (obj._LOCATIONID == null)
            {
                obj._LOCATIONID = 0;
            }

            string queryString = "CALL SP_MANAGELOCATION(?_LOCATIONID, ?_LOCATIONCODE, ?_LOCATIONNAME, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[7];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._LOCATIONID, "?_LOCATIONID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.String, obj._LOCATIONCODE, "?_LOCATIONCODE", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.String, obj._LOCATIONNAME, "?_LOCATIONNAME", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.String, obj._ACTIVE, "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.String, obj._CREATEDON, "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            return (string)MySqlHelper.ExecuteScalar(connectionString, queryString, mySqlParam);
        }

        public DataSet GetLocations(BLLocation obj)
        {
            if (obj._MODE == "BYLOCATIONID")
            {
                return GetLocationByLocationID(obj);
            }
            else if (obj._MODE == "GETALL")
            {
                return GetAllActiveLocations(obj);
            }
            else
            {
                return SearchLocation(obj);
            }
        }

        public DataSet GetLocationByLocationID(BLLocation obj)
        {
            string queryString = "CALL SP_MANAGELOCATION(?_LOCATIONID, ?_LOCATIONCODE, ?_LOCATIONNAME, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[7];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._LOCATIONID, "?_LOCATIONID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.String, "", "?_LOCATIONCODE", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.String, "", "?_LOCATIONNAME", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.String, obj._ACTIVE, "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.DateTime, obj._CREATEDON, "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            DataSet _ds = (DataSet)MySqlHelper.ExecuteDataset(connectionString, queryString, mySqlParam);
            return _ds;
        }

        public DataSet GetAllActiveLocations(BLLocation obj)
        {
            string queryString = "CALL SP_MANAGELOCATION(?_LOCATIONID, ?_LOCATIONCODE, ?_LOCATIONNAME, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[7];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._LOCATIONID, "?_LOCATIONID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.String, "", "?_LOCATIONCODE", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.String, "", "?_LOCATIONNAME", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.String, obj._ACTIVE, "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.DateTime, obj._CREATEDON, "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            DataSet _ds = (DataSet)MySqlHelper.ExecuteDataset(connectionString, queryString, mySqlParam);
            return _ds;
        }

        public DataSet SearchLocation(BLLocation obj)
        {
            string queryString = "CALL SP_MANAGELOCATION(?_LOCATIONID, ?_LOCATIONCODE, ?_LOCATIONNAME, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[7];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._LOCATIONID, "?_LOCATIONID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.String, obj._LOCATIONCODE, "?_LOCATIONCODE", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.String, obj._LOCATIONNAME, "?_LOCATIONNAME", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.String, obj._ACTIVE, "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.DateTime, obj._CREATEDON, "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            DataSet _ds = (DataSet)MySqlHelper.ExecuteDataset(connectionString, queryString, mySqlParam);
            return _ds;
        }
    }
}
