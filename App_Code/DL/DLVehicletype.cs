
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
    public class DLVehicletype : BaseDataLayer
    {

        public string ManageVehicletypes(BLVehicletype obj)
        {
            string result = string.Empty;

            string queryString = "CALL SP_MANAGEVEHICLETYPE(?_VEHICLETYPEID, ?_VEHICLETYPECODE, ?_VEHICLETYPENAME, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[7];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._VEHICLETYPEID, "?_VEHICLETYPEID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.String, obj._VEHICLETYPECODE, "?_VEHICLETYPECODE", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.String, obj._VEHICLETYPENAME, "?_VEHICLETYPENAME", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.String, obj._ACTIVE, "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.DateTime, obj._CREATEDONDATE, "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            return (string)MySqlHelper.ExecuteScalar(connectionString, queryString, mySqlParam);
        }

        public DataSet GetVehicletypes(BLVehicletype obj)
        {
            if (obj._MODE == "BYVEHICLETYPEID")
            {
                return GetVehicletypeByVehicletypeID(obj);
            }
            else if (obj._MODE == "GETALL")
            {
                return GetAllActiveVehicletypes(obj);
            }
            else
            {
                return SearchVehicletypes(obj);
            }
        }

        public DataSet GetVehicletypeByVehicletypeID(BLVehicletype obj)
        {
            string queryString = "CALL SP_MANAGEVEHICLETYPE(?_VEHICLETYPEID, ?_VEHICLETYPECODE, ?_VEHICLETYPENAME, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[7];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._VEHICLETYPEID, "?_VEHICLETYPEID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.String, obj._VEHICLETYPECODE, "?_VEHICLETYPECODE", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.String, obj._VEHICLETYPENAME, "?_VEHICLETYPENAME", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.String, obj._ACTIVE, "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.DateTime, obj._CREATEDONDATE, "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            DataSet _ds = (DataSet)MySqlHelper.ExecuteDataset(connectionString, queryString, mySqlParam);
            return _ds;
        }

        public DataSet GetAllActiveVehicletypes(BLVehicletype obj)
        {
            string queryString = "CALL SP_MANAGEVEHICLETYPE(?_VEHICLETYPEID, ?_VEHICLETYPECODE, ?_VEHICLETYPENAME, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[7];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._VEHICLETYPEID, "?_VEHICLETYPEID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.String, obj._VEHICLETYPECODE, "?_VEHICLETYPECODE", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.String, obj._VEHICLETYPENAME, "?_VEHICLETYPENAME", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.String, obj._ACTIVE, "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.DateTime, obj._CREATEDONDATE, "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            DataSet _ds = (DataSet)MySqlHelper.ExecuteDataset(connectionString, queryString, mySqlParam);
            return _ds;
        }

        public DataSet SearchVehicletypes(BLVehicletype obj)
        {
            string queryString = "CALL SP_MANAGEVEHICLETYPE(?_VEHICLETYPEID, ?_VEHICLETYPECODE, ?_VEHICLETYPENAME, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[7];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._VEHICLETYPEID, "?_VEHICLETYPEID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.String, obj._VEHICLETYPECODE, "?_VEHICLETYPECODE", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.String, obj._VEHICLETYPENAME, "?_VEHICLETYPENAME", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.String, obj._ACTIVE, "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.DateTime, obj._CREATEDONDATE, "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            DataSet _ds = (DataSet)MySqlHelper.ExecuteDataset(connectionString, queryString, mySqlParam);
            return _ds;
        }

    }
}
