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
    public class DLManageRFPTransaction : BaseDataLayer
    {
        public string ManageTransaction(BLManageRFPTransaction obj)
        {
            string result = string.Empty;

            if (obj._RFPID == null)
            {
                obj._RFPID = 0;
            }

            string queryString = "CALL SP_MANAGERFPTRANSACTION(?_RFPID, ?_FROMLOCATION, ?_TOLOCATION, ?_VEHICLETYPEID, ?_SERVICETYPE, ?_CLEANSHEETRATE, ?_CONTRACTRATE, ?_SHIPXRATE, ?_PVSRFPRATE, ?_MARKETRATE, ?_BAQUOTE, ?_BACKHAULAVL, ?_BACKHAULPERCENT, ?_APPROVEDAMOUNT, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[18];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._RFPID, "?_RFPID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.Int32, obj._FROMLOCATION, "?_FROMLOCATION", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.Int32, obj._TOLOCATION, "?_TOLOCATION", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.Int32, obj._VEHICLETYPEID, "?_VEHICLETYPEID", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.String, obj._SERVICETYPE, "?_SERVICETYPE", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.Decimal, obj._CLEANSHEETRATE, "?_CLEANSHEETRATE", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.Decimal, obj._CONTRACTRATE, "?_CONTRACTRATE", ParameterDirection.Input);
            mySqlParam[7] = CreateParameters(DbType.Decimal, obj._SHIPXRATE, "?_SHIPXRATE", ParameterDirection.Input);
            mySqlParam[8] = CreateParameters(DbType.Decimal, obj._PVSRFPRATE, "?_PVSRFPRATE", ParameterDirection.Input);
            mySqlParam[9] = CreateParameters(DbType.Decimal, obj._MARKETRATE, "?_MARKETRATE", ParameterDirection.Input);
            mySqlParam[10] = CreateParameters(DbType.Decimal, obj._BAQUOTE, "?_BAQUOTE", ParameterDirection.Input);
            mySqlParam[11] = CreateParameters(DbType.String, obj._BACKHAULAVL, "?_BACKHAULAVL", ParameterDirection.Input);
            mySqlParam[12] = CreateParameters(DbType.Decimal, obj._BACKHAULPERCENT, "?_BACKHAULPERCENT", ParameterDirection.Input);
            mySqlParam[13] = CreateParameters(DbType.Decimal, obj._APPROVEDAMOUNT, "?_APPROVEDAMOUNT", ParameterDirection.Input);
            mySqlParam[14] = CreateParameters(DbType.String, obj._ACTIVE, "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[15] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[16] = CreateParameters(DbType.String, obj._CREATEDON, "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[17] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            return (string)MySqlHelper.ExecuteScalar(connectionString, queryString, mySqlParam);
        }

        public DataSet GetManageTransaction(BLManageRFPTransaction obj)
        {
            if (obj._MODE == "BYRFPID")
            {
                return GetManageTransactionBYRFPID(obj);
            }
            else if (obj._MODE == "GETALL")
            {
                return GetAllActiveManageTransaction(obj);
            }
            else
            {
                return SearchManageTransaction(obj);
            }
        }

        public DataSet GetManageTransactionBYRFPID(BLManageRFPTransaction obj)
        {
            string queryString = "CALL SP_MANAGERFPTRANSACTION(?_RFPID, ?_FROMLOCATION, ?_TOLOCATION, ?_VEHICLETYPEID, ?_SERVICETYPE, ?_CLEANSHEETRATE, ?_CONTRACTRATE, ?_SHIPXRATE, ?_PVSRFPRATE, ?_MARKETRATE, ?_BAQUOTE, ?_BACKHAULAVL, ?_BACKHAULPERCENT, ?_APPROVEDAMOUNT, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[18];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._RFPID, "?_RFPID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.Int32, "0", "?_FROMLOCATION", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.Int32, "0", "?_TOLOCATION", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.Int32, "0", "?_VEHICLETYPEID", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.String, "", "?_SERVICETYPE", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.Decimal, "0", "?_CLEANSHEETRATE", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.Decimal, "0", "?_CONTRACTRATE", ParameterDirection.Input);
            mySqlParam[7] = CreateParameters(DbType.Decimal, "0", "?_SHIPXRATE", ParameterDirection.Input);
            mySqlParam[8] = CreateParameters(DbType.Decimal, "0", "?_PVSRFPRATE", ParameterDirection.Input);
            mySqlParam[9] = CreateParameters(DbType.Decimal, "0", "?_MARKETRATE", ParameterDirection.Input);
            mySqlParam[10] = CreateParameters(DbType.Decimal,"0", "?_BAQUOTE", ParameterDirection.Input);
            mySqlParam[11] = CreateParameters(DbType.String, "N", "?_BACKHAULAVL", ParameterDirection.Input);
            mySqlParam[12] = CreateParameters(DbType.Decimal, "0", "?_BACKHAULPERCENT", ParameterDirection.Input);
            mySqlParam[13] = CreateParameters(DbType.Decimal, "0", "?_APPROVEDAMOUNT", ParameterDirection.Input);
            mySqlParam[14] = CreateParameters(DbType.String, "A", "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[15] = CreateParameters(DbType.Int32, "0", "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[16] = CreateParameters(DbType.String, "1800-01-01", "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[17] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);


            DataSet _ds = (DataSet)MySqlHelper.ExecuteDataset(connectionString, queryString, mySqlParam);
            return _ds;
        }

        public DataSet GetAllActiveManageTransaction(BLManageRFPTransaction obj)
        {
            string queryString = "CALL SP_MANAGERFPTRANSACTION(?_RFPID, ?_FROMLOCATION, ?_TOLOCATION, ?_VEHICLETYPEID, ?_SERVICETYPE, ?_CLEANSHEETRATE, ?_CONTRACTRATE, ?_SHIPXRATE, ?_PVSRFPRATE, ?_MARKETRATE, ?_BAQUOTE, ?_BACKHAULAVL, ?_BACKHAULPERCENT, ?_APPROVEDAMOUNT, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[18];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._RFPID, "?_RFPID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.Int32, "", "?_FROMLOCATION", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.Int32, "", "?_TOLOCATION", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.Int32, "", "?_VEHICLETYPEID", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.String, "", "?_SERVICETYPE", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.Decimal, "", "?_CLEANSHEETRATE", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.Decimal, "", "?_CONTRACTRATE", ParameterDirection.Input);
            mySqlParam[7] = CreateParameters(DbType.Decimal, "", "?_SHIPXRATE", ParameterDirection.Input);
            mySqlParam[8] = CreateParameters(DbType.Decimal, "", "?_PVSRFPRATE", ParameterDirection.Input);
            mySqlParam[9] = CreateParameters(DbType.Decimal, "", "?_MARKETRATE", ParameterDirection.Input);
            mySqlParam[10] = CreateParameters(DbType.String, "", "?_BACKHAULAVL", ParameterDirection.Input);
            mySqlParam[11] = CreateParameters(DbType.Decimal, "", "?_BACKHAULPERCENT", ParameterDirection.Input);
            mySqlParam[12] = CreateParameters(DbType.Decimal, "", "?_APPROVEDAMOUNT", ParameterDirection.Input);
            mySqlParam[13] = CreateParameters(DbType.String, "", "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[14] = CreateParameters(DbType.Int32, "1", "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[15] = CreateParameters(DbType.String, "1800-01-01", "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[16] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);


            DataSet _ds = (DataSet)MySqlHelper.ExecuteDataset(connectionString, queryString, mySqlParam);
            return _ds;
        }
        public DataSet SearchManageTransaction(BLManageRFPTransaction obj)
        {
            string queryString = "CALL SP_MANAGERFPTRANSACTION(?_RFPID, ?_FROMLOCATION, ?_TOLOCATION, ?_VEHICLETYPEID, ?_SERVICETYPE, ?_CLEANSHEETRATE, ?_CONTRACTRATE, ?_SHIPXRATE, ?_PVSRFPRATE, ?_MARKETRATE, ?_BAQUOTE, ?_BACKHAULAVL, ?_BACKHAULPERCENT, ?_APPROVEDAMOUNT, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[18];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._RFPID, "?_RFPID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.Int32, "", "?_FROMLOCATION", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.Int32, "", "?_TOLOCATION", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.Int32, "", "?_VEHICLETYPEID", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.String, "", "?_SERVICETYPE", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.Decimal, "", "?_CLEANSHEETRATE", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.Decimal, "", "?_CONTRACTRATE", ParameterDirection.Input);
            mySqlParam[7] = CreateParameters(DbType.Decimal, "", "?_SHIPXRATE", ParameterDirection.Input);
            mySqlParam[8] = CreateParameters(DbType.Decimal, "", "?_PVSRFPRATE", ParameterDirection.Input);
            mySqlParam[9] = CreateParameters(DbType.Decimal, "", "?_MARKETRATE", ParameterDirection.Input);
            mySqlParam[10] = CreateParameters(DbType.String, "", "?_BACKHAULAVL", ParameterDirection.Input);
            mySqlParam[11] = CreateParameters(DbType.Decimal, "", "?_BACKHAULPERCENT", ParameterDirection.Input);
            mySqlParam[12] = CreateParameters(DbType.Decimal, "", "?_APPROVEDAMOUNT", ParameterDirection.Input);
            mySqlParam[13] = CreateParameters(DbType.String, "", "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[14] = CreateParameters(DbType.Int32, "1", "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[15] = CreateParameters(DbType.String, "1800-01-01", "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[16] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);


            DataSet _ds = (DataSet)MySqlHelper.ExecuteDataset(connectionString, queryString, mySqlParam);
            return _ds;
        }
    }
}
