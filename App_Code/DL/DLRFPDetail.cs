
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
    public class DLRFPDetail : BaseDataLayer
    {

        public string ManageRFPDetails(BLRFPDetail obj)
        {
            string result = string.Empty;

            if (obj._RFPID == null)
            {
                obj._RFPID = 0;
            }

            string queryString = "CALL SP_MANAGERFPDETAIL(?_RFPID, ?_FROMLOCATION, ?_TOLOCATION, ?_VEHICLETYPEID, ?_APPROVEDAMOUNT, ?_SERVICETYPE, ?_RFPVOLUME, ?_RFPDURATION, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_SEARCH1, ?_SEARCH2, ?_SEARCH3, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[15];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._RFPID, "?_RFPID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.Int32, obj._FROMLOCATION, "?_FROMLOCATION", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.Int32, obj._TOLOCATION, "?_TOLOCATION", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.Int32, obj._VEHICLETYPEID, "?_VEHICLETYPEID", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.Decimal, obj._APPROVEDAMOUNT, "?_APPROVEDAMOUNT", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.String, obj._SERVICETYPE, "?_SERVICETYPE", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.Decimal, obj._RFPVOLUME, "?_RFPVOLUME", ParameterDirection.Input);
            mySqlParam[7] = CreateParameters(DbType.Decimal, obj._RFPDURATION, "?_RFPDURATION", ParameterDirection.Input);
            mySqlParam[8] = CreateParameters(DbType.String, obj._ACTIVE, "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[9] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[10] = CreateParameters(DbType.Date, obj._CREATEDONDATE, "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[11] = CreateParameters(DbType.String, obj._SEARCH1, "?_SEARCH1", ParameterDirection.Input);
            mySqlParam[12] = CreateParameters(DbType.String, obj._SEARCH2, "?_SEARCH2", ParameterDirection.Input);
            mySqlParam[13] = CreateParameters(DbType.String, obj._SEARCH3, "?_SEARCH3", ParameterDirection.Input);
            mySqlParam[14] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            return (string)MySqlHelper.ExecuteScalar(connectionString, queryString, mySqlParam);
        }

        public DataSet GetRFPDetails(BLRFPDetail obj)
        {
            return GetRFPDetailByRFPID(obj);
        }

        public DataSet GetRFPDetailByRFPID(BLRFPDetail obj)
        
        {
            string queryString = "CALL SP_MANAGERFPDETAIL(?_RFPID, ?_FROMLOCATION, ?_TOLOCATION, ?_VEHICLETYPEID, ?_APPROVEDAMOUNT, ?_SERVICETYPE, ?_RFPVOLUME, ?_RFPDURATION, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_SEARCH1, ?_SEARCH2, ?_SEARCH3, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[15];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._RFPID, "?_RFPID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.Int32, obj._FROMLOCATION, "?_FROMLOCATION", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.Int32, obj._TOLOCATION, "?_TOLOCATION", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.Int32, obj._VEHICLETYPEID, "?_VEHICLETYPEID", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.Decimal, obj._APPROVEDAMOUNT, "?_APPROVEDAMOUNT", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.String, obj._SERVICETYPE, "?_SERVICETYPE", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.Decimal, obj._RFPVOLUME, "?_RFPVOLUME", ParameterDirection.Input);
            mySqlParam[7] = CreateParameters(DbType.Decimal, obj._RFPDURATION, "?_RFPDURATION", ParameterDirection.Input);
            mySqlParam[8] = CreateParameters(DbType.String, obj._ACTIVE, "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[9] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[10] = CreateParameters(DbType.Date, obj._CREATEDONDATE, "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[11] = CreateParameters(DbType.String, obj._SEARCH1, "?_SEARCH1", ParameterDirection.Input);
            mySqlParam[12] = CreateParameters(DbType.String, obj._SEARCH2, "?_SEARCH2", ParameterDirection.Input);
            mySqlParam[13] = CreateParameters(DbType.String, obj._SEARCH3, "?_SEARCH3", ParameterDirection.Input);
            mySqlParam[14] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            DataSet _ds = (DataSet)MySqlHelper.ExecuteDataset(connectionString, queryString, mySqlParam);
            return _ds;
        }

        /*
        public DataSet GetAllActiveRFPDetails(BLRFPDetail obj)
        {
            string queryString = "CALL SP_MANAGERFPDETAIL(?_RFPID, ?_FROMLOCATION, ?_TOLOCATION, ?_VEHICLETYPEID, ?_APPROVEDAMOUNT, ?_SERVICETYPE, ?_RFPVOLUME, ?_RFPDURATION, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_SEARCH1, ?_SEARCH2, ?_SEARCH3, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[15];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._RFPID, "?_RFPID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.String, obj._FROMLOCATION, "?_FROMLOCATION", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.String, obj._TOLOCATION, "?_TOLOCATION", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.Int32, obj._VEHICLETYPEID, "?_VEHICLETYPEID", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.Decimal, obj._APPROVEDAMOUNT, "?_APPROVEDAMOUNT", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.String, obj._SERVICETYPE, "?_SERVICETYPE", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.Decimal, obj._RFPVOLUME, "?_RFPVOLUME", ParameterDirection.Input);
            mySqlParam[7] = CreateParameters(DbType.Decimal, obj._RFPDURATION, "?_RFPDURATION", ParameterDirection.Input);
            mySqlParam[8] = CreateParameters(DbType.String, obj._ACTIVE, "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[9] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[10] = CreateParameters(DbType.Date, obj._CREATEDON, "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[11] = CreateParameters(DbType.String, obj._SEARCH1, "?_SEARCH1", ParameterDirection.Input);
            mySqlParam[12] = CreateParameters(DbType.String, obj._SEARCH2, "?_SEARCH2", ParameterDirection.Input);
            mySqlParam[13] = CreateParameters(DbType.String, obj._SEARCH3, "?_SEARCH3", ParameterDirection.Input);
            mySqlParam[14] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            DataSet _ds = (DataSet)MySqlHelper.ExecuteDataset(connectionString, queryString, mySqlParam);
            return _ds;
        }

        public DataSet SearchRFPDetail(BLRFPDetail obj)
        {
            string queryString = "CALL SP_MANAGERFPDETAIL(?_RFPID, ?_FROMLOCATION, ?_TOLOCATION, ?_VEHICLETYPEID, ?_APPROVEDAMOUNT, ?_SERVICETYPE, ?_RFPVOLUME, ?_RFPDURATION, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_SEARCH1, ?_SEARCH2, ?_SEARCH3, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[15];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._RFPID, "?_RFPID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.String, obj._FROMLOCATION, "?_FROMLOCATION", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.String, obj._TOLOCATION, "?_TOLOCATION", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.Int32, obj._VEHICLETYPEID, "?_VEHICLETYPEID", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.Decimal, obj._APPROVEDAMOUNT, "?_APPROVEDAMOUNT", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.String, obj._SERVICETYPE, "?_SERVICETYPE", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.Decimal, obj._RFPVOLUME, "?_RFPVOLUME", ParameterDirection.Input);
            mySqlParam[7] = CreateParameters(DbType.Decimal, obj._RFPDURATION, "?_RFPDURATION", ParameterDirection.Input);
            mySqlParam[8] = CreateParameters(DbType.String, obj._ACTIVE, "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[9] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[10] = CreateParameters(DbType.Date, obj._CREATEDON, "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[11] = CreateParameters(DbType.String, obj._SEARCH1, "?_SEARCH1", ParameterDirection.Input);
            mySqlParam[12] = CreateParameters(DbType.String, obj._SEARCH2, "?_SEARCH2", ParameterDirection.Input);
            mySqlParam[13] = CreateParameters(DbType.String, obj._SEARCH3, "?_SEARCH3", ParameterDirection.Input);
            mySqlParam[14] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            DataSet _ds = (DataSet)MySqlHelper.ExecuteDataset(connectionString, queryString, mySqlParam);
            return _ds;
        }
        */
    }
}
