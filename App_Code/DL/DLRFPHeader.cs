
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
    public class DLRFPHeader : BaseDataLayer
    {

        public string ManageRFPHeaders(BLRFPHeader obj)
        {
            string result = string.Empty;

            if (obj._RFPID == null)
            {
                obj._RFPID = 0;
            }

            string queryString = "CALL SP_MANAGERFPHEADER(?_RFPID, ?_RFPCODE, ?_RFPDATE, ?_CUSTOMERID, ?_INDUSTRYTYPEID, ?_RFPAMOUNT, ?_STARTDATE, ?_RFPOWNER, ?_CURRENTSTAGINGOWNER, ?_DIESELRATE, ?_AGEOFTRUCK, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_SEARCH1, ?_SEARCH2, ?_SEARCH3, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[18];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._RFPID, "?_RFPID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.String, obj._RFPCODE, "?_RFPCODE", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.DateTime, obj._RFPDATE, "?_RFPDATE", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.Int32, obj._CUSTOMERID, "?_CUSTOMERID", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.Int32, obj._INDUSTRYTYPEID, "?_INDUSTRYTYPEID", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.Decimal, obj._RFPAMOUNT, "?_RFPAMOUNT", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.DateTime, "2016-01-17 14:18:21", "?_STARTDATE", ParameterDirection.Input);
            mySqlParam[7] = CreateParameters(DbType.String, obj._RFPOWNER, "?_RFPOWNER", ParameterDirection.Input);
            mySqlParam[8] = CreateParameters(DbType.String, obj._CURRENTSTAGINGOWNER, "?_CURRENTSTAGINGOWNER", ParameterDirection.Input);
            mySqlParam[9] = CreateParameters(DbType.Decimal, obj._DIESELRATE, "?_DIESELRATE", ParameterDirection.Input);
            mySqlParam[10] = CreateParameters(DbType.Int32, obj._AGEOFTRUCK, "?_AGEOFTRUCK", ParameterDirection.Input);
            mySqlParam[11] = CreateParameters(DbType.String, obj._ACTIVE, "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[12] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[13] = CreateParameters(DbType.Date, "2016-01-17 14:18:21", "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[14] = CreateParameters(DbType.String, obj._SEARCH1, "?_SEARCH1", ParameterDirection.Input);
            mySqlParam[15] = CreateParameters(DbType.String, obj._SEARCH2, "?_SEARCH2", ParameterDirection.Input);
            mySqlParam[16] = CreateParameters(DbType.String, obj._SEARCH3, "?_SEARCH3", ParameterDirection.Input);
            mySqlParam[17] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            return (string)MySqlHelper.ExecuteScalar(connectionString, queryString, mySqlParam);
        }

        public DataSet GetRFPHeaders(BLRFPHeader obj)
        {
            if (obj._MODE == "BYRFPID")
            {
                return GetRFPHeaderByRFPID(obj);
            }
            if (obj._MODE == "BYCUSTOMERID")
            {
                return GetRFPHeaderByCustomerID(obj);
            }
            else if (obj._MODE == "GETALL")
            {
                return GetAllActiveRFPHeaders(obj);
            }
            else
            {
                return SearchRFPHeader(obj);
            }
        }

        public DataSet GetRFPHeaderByRFPID(BLRFPHeader obj)
        {
            string queryString = "CALL SP_MANAGERFPHEADER(?_RFPID, ?_RFPCODE, ?_RFPDATE, ?_CUSTOMERID, ?_INDUSTRYTYPEID, ?_RFPAMOUNT, ?_STARTDATE, ?_RFPOWNER, ?_CURRENTSTAGINGOWNER, ?_DIESELRATE, ?_AGEOFTRUCK, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_SEARCH1, ?_SEARCH2, ?_SEARCH3, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[18];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._RFPID, "?_RFPID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.String, obj._RFPCODE, "?_RFPCODE", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.DateTime, obj._RFPDATE, "?_RFPDATE", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.Int32, obj._CUSTOMERID, "?_CUSTOMERID", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.Int32, obj._INDUSTRYTYPEID, "?_INDUSTRYTYPEID", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.Decimal, obj._RFPAMOUNT, "?_RFPAMOUNT", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.DateTime, "2016-01-17 14:18:21", "?_STARTDATE", ParameterDirection.Input);
            mySqlParam[7] = CreateParameters(DbType.String, obj._RFPOWNER, "?_RFPOWNER", ParameterDirection.Input);
            mySqlParam[8] = CreateParameters(DbType.String, obj._CURRENTSTAGINGOWNER, "?_CURRENTSTAGINGOWNER", ParameterDirection.Input);
            mySqlParam[9] = CreateParameters(DbType.Decimal, "10.00", "?_DIESELRATE", ParameterDirection.Input);
            mySqlParam[10] = CreateParameters(DbType.Int32, obj._AGEOFTRUCK, "?_AGEOFTRUCK", ParameterDirection.Input);
            mySqlParam[11] = CreateParameters(DbType.String, obj._ACTIVE, "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[12] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[13] = CreateParameters(DbType.Date, "2016-01-17 14:18:21", "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[14] = CreateParameters(DbType.String, "", "?_SEARCH1", ParameterDirection.Input);
            mySqlParam[15] = CreateParameters(DbType.String, "", "?_SEARCH2", ParameterDirection.Input);
            mySqlParam[16] = CreateParameters(DbType.String, "", "?_SEARCH3", ParameterDirection.Input);
            mySqlParam[17] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            DataSet _ds = (DataSet)MySqlHelper.ExecuteDataset(connectionString, queryString, mySqlParam);
            return _ds;
        }

        public DataSet GetRFPHeaderByCustomerID(BLRFPHeader obj)
        {
            string queryString = "CALL SP_MANAGERFPHEADER(?_RFPID, ?_RFPCODE, ?_RFPDATE, ?_CUSTOMERID, ?_INDUSTRYTYPEID, ?_RFPAMOUNT, ?_STARTDATE, ?_RFPOWNER, ?_CURRENTSTAGINGOWNER, ?_DIESELRATE, ?_AGEOFTRUCK, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_SEARCH1, ?_SEARCH2, ?_SEARCH3, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[18];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._RFPID, "?_RFPID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.String, obj._RFPCODE, "?_RFPCODE", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.DateTime, obj._RFPDATE, "?_RFPDATE", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.Int32, obj._CUSTOMERID, "?_CUSTOMERID", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.Int32, obj._INDUSTRYTYPEID, "?_INDUSTRYTYPEID", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.Decimal, obj._RFPAMOUNT, "?_RFPAMOUNT", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.DateTime, "2016-01-17 14:18:21", "?_STARTDATE", ParameterDirection.Input);
            mySqlParam[7] = CreateParameters(DbType.String, obj._RFPOWNER, "?_RFPOWNER", ParameterDirection.Input);
            mySqlParam[8] = CreateParameters(DbType.String, obj._CURRENTSTAGINGOWNER, "?_CURRENTSTAGINGOWNER", ParameterDirection.Input);
            mySqlParam[9] = CreateParameters(DbType.Decimal, "10.00", "?_DIESELRATE", ParameterDirection.Input);
            mySqlParam[10] = CreateParameters(DbType.Int32, obj._AGEOFTRUCK, "?_AGEOFTRUCK", ParameterDirection.Input);
            mySqlParam[11] = CreateParameters(DbType.String, obj._ACTIVE, "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[12] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[13] = CreateParameters(DbType.Date, "2016-01-17 14:18:21", "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[14] = CreateParameters(DbType.String, "", "?_SEARCH1", ParameterDirection.Input);
            mySqlParam[15] = CreateParameters(DbType.String, "", "?_SEARCH2", ParameterDirection.Input);
            mySqlParam[16] = CreateParameters(DbType.String, "", "?_SEARCH3", ParameterDirection.Input);
            mySqlParam[17] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            DataSet _ds = (DataSet)MySqlHelper.ExecuteDataset(connectionString, queryString, mySqlParam);
            return _ds;
        }

        public DataSet GetAllActiveRFPHeaders(BLRFPHeader obj)
        {
            string queryString = "CALL SP_MANAGERFPHEADER(?_RFPID, ?_RFPCODE, ?_RFPDATE, ?_CUSTOMERID, ?_INDUSTRYTYPEID, ?_RFPAMOUNT, ?_STARTDATE, ?_RFPOWNER, ?_CURRENTSTAGINGOWNER, ?_DIESELRATE, ?_AGEOFTRUCK, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_SEARCH1, ?_SEARCH2, ?_SEARCH3, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[18];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._RFPID, "?_RFPID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.String, obj._RFPCODE, "?_RFPCODE", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.DateTime, obj._RFPDATE, "?_RFPDATE", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.Int32, obj._CUSTOMERID, "?_CUSTOMERID", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.Int32, obj._INDUSTRYTYPEID, "?_INDUSTRYTYPEID", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.Decimal, obj._RFPAMOUNT, "?_RFPAMOUNT", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.DateTime, "2016-01-17 14:18:21", "?_STARTDATE", ParameterDirection.Input);
            mySqlParam[7] = CreateParameters(DbType.String, obj._RFPOWNER, "?_RFPOWNER", ParameterDirection.Input);
            mySqlParam[8] = CreateParameters(DbType.String, obj._CURRENTSTAGINGOWNER, "?_CURRENTSTAGINGOWNER", ParameterDirection.Input);
            mySqlParam[9] = CreateParameters(DbType.Decimal, "10.00", "?_DIESELRATE", ParameterDirection.Input);
            mySqlParam[10] = CreateParameters(DbType.Int32, obj._AGEOFTRUCK, "?_AGEOFTRUCK", ParameterDirection.Input);
            mySqlParam[11] = CreateParameters(DbType.String, obj._ACTIVE, "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[12] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[13] = CreateParameters(DbType.Date, "2016-01-17 14:18:21", "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[14] = CreateParameters(DbType.String, "", "?_SEARCH1", ParameterDirection.Input);
            mySqlParam[15] = CreateParameters(DbType.String, "", "?_SEARCH2", ParameterDirection.Input);
            mySqlParam[16] = CreateParameters(DbType.String, "", "?_SEARCH3", ParameterDirection.Input);
            mySqlParam[17] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            DataSet _ds = (DataSet)MySqlHelper.ExecuteDataset(connectionString, queryString, mySqlParam);
            return _ds;
        }

        public DataSet SearchRFPHeader(BLRFPHeader obj)
        {
            string queryString = "CALL SP_MANAGERFPHEADER(?_RFPID, ?_RFPCODE, ?_RFPDATE, ?_CUSTOMERID, ?_INDUSTRYTYPEID, ?_RFPAMOUNT, ?_STARTDATE, ?_RFPOWNER, ?_CURRENTSTAGINGOWNER, ?_DIESELRATE, ?_AGEOFTRUCK, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_SEARCH1, ?_SEARCH2, ?_SEARCH3, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[18];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._RFPID, "?_RFPID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.String, obj._RFPCODE, "?_RFPCODE", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.DateTime, obj._RFPDATE, "?_RFPDATE", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.Int32, obj._CUSTOMERID, "?_CUSTOMERID", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.Int32, obj._INDUSTRYTYPEID, "?_INDUSTRYTYPEID", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.Decimal, obj._RFPAMOUNT, "?_RFPAMOUNT", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.DateTime, "2016-01-17 14:18:21", "?_STARTDATE", ParameterDirection.Input);
            mySqlParam[7] = CreateParameters(DbType.String, obj._RFPOWNER, "?_RFPOWNER", ParameterDirection.Input);
            mySqlParam[8] = CreateParameters(DbType.String, obj._CURRENTSTAGINGOWNER, "?_CURRENTSTAGINGOWNER", ParameterDirection.Input);
            mySqlParam[9] = CreateParameters(DbType.Decimal, "10.00", "?_DIESELRATE", ParameterDirection.Input);
            mySqlParam[10] = CreateParameters(DbType.Int32, obj._AGEOFTRUCK, "?_AGEOFTRUCK", ParameterDirection.Input);
            mySqlParam[11] = CreateParameters(DbType.String, obj._ACTIVE, "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[12] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[13] = CreateParameters(DbType.Date, "2016-01-17 14:18:21", "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[14] = CreateParameters(DbType.String, obj._SEARCH1, "?_SEARCH1", ParameterDirection.Input);
            mySqlParam[15] = CreateParameters(DbType.String, "", "?_SEARCH2", ParameterDirection.Input);
            mySqlParam[16] = CreateParameters(DbType.String, "", "?_SEARCH3", ParameterDirection.Input);
            mySqlParam[17] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            DataSet _ds = (DataSet)MySqlHelper.ExecuteDataset(connectionString, queryString, mySqlParam);
            return _ds;
        }
    }
}
