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
    public class DLIndustryType : BaseDataLayer
    {
        public string ManageIndustryTypes(BLIndustryType obj)
        {
            string result = string.Empty;

            if (obj._INDUSTRYTYPEID == null)
            {
                obj._INDUSTRYTYPEID = 0;
            }

            string queryString = "CALL SP_MANAGEINDUSTRYTYPE(?_INDUSTRYTYPEID, ?_INDUSTRYTYPECODE, ?_INDUSTRYTYPENAME, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[7];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._INDUSTRYTYPEID, "?_INDUSTRYTYPEID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.String, obj._INDUSTRYTYPECODE, "?_INDUSTRYTYPECODE", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.String, obj._INDUSTRYTYPENAME, "?_INDUSTRYTYPENAME", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.String, obj._ACTIVE, "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.String, obj._CREATEDON, "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            result = ((String)MySqlHelper.ExecuteScalar(connectionString, queryString, mySqlParam)).ToString();
            return result;
        }

        public DataSet GetIndustryTypes(BLIndustryType obj)
        {
            if (obj._MODE == "BYINDUSTRYTYPEID")
            {
                return GetIndustryTypeByIndustryTypeID(obj);
            }
            else if (obj._MODE == "GETALL")
            {
                return GetAllActiveIndustryTypes(obj);
            }
            else
            {
                return SearchIndustryTypes(obj);
            }
        }

        public DataSet GetIndustryTypeByIndustryTypeID(BLIndustryType obj)
        {
            string queryString = "CALL SP_MANAGEINDUSTRYTYPE(?_INDUSTRYTYPEID, ?_INDUSTRYTYPECODE, ?_INDUSTRYTYPENAME, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[7];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._INDUSTRYTYPEID, "?_INDUSTRYTYPEID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.String, "", "?_INDUSTRYTYPECODE", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.String, "", "?_INDUSTRYTYPENAME", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.String, obj._ACTIVE, "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.DateTime, obj._CREATEDON, "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            DataSet _ds = (DataSet)MySqlHelper.ExecuteDataset(connectionString, queryString, mySqlParam);
            return _ds;
        }

        public DataSet GetAllActiveIndustryTypes(BLIndustryType obj)
        {
            string queryString = "CALL SP_MANAGEINDUSTRYTYPE(?_INDUSTRYTYPEID, ?_INDUSTRYTYPECODE, ?_INDUSTRYTYPENAME, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[7];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._INDUSTRYTYPEID, "?_INDUSTRYTYPEID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.String, "", "?_INDUSTRYTYPECODE", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.String, "", "?_INDUSTRYTYPENAME", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.String, obj._ACTIVE, "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.DateTime, obj._CREATEDON, "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            DataSet _ds = (DataSet)MySqlHelper.ExecuteDataset(connectionString, queryString, mySqlParam);
            return _ds;
        }

        public DataSet SearchIndustryTypes(BLIndustryType obj)
        {
            string queryString = "CALL SP_MANAGEINDUSTRYTYPE(?_INDUSTRYTYPEID, ?_INDUSTRYTYPECODE, ?_INDUSTRYTYPENAME, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[7];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._INDUSTRYTYPEID, "?_INDUSTRYTYPEID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.String, obj._INDUSTRYTYPECODE, "?_INDUSTRYTYPECODE", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.String, obj._INDUSTRYTYPENAME, "?_INDUSTRYTYPENAME", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.String, obj._ACTIVE, "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.DateTime, obj._CREATEDON, "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            DataSet _ds = (DataSet)MySqlHelper.ExecuteDataset(connectionString, queryString, mySqlParam);
            return _ds;
        }
    }
}
