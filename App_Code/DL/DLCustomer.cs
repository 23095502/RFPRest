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
    public class DLCustomer : BaseDataLayer
    {

        
        public string ManageCustomer(BLCustomer obj)
        {
            string result = string.Empty;

            if (obj._CUSTOMERID == null)
            {
                obj._CUSTOMERID = 0;
            }

            string queryString = "CALL SP_MANAGECUSTOMER(?_CUSTOMERID, ?_CUSTOMERCODE, ?_CUSTOMERNAME, ?_ADDRESS, ?_EMAIL, ?_CONTACTPERSON, ?_CONTACTNO, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[11];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._CUSTOMERID, "?_CUSTOMERID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.String, obj._CUSTOMERCODE, "?_CUSTOMERCODE", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.String, obj._CUSTOMERNAME, "?_CUSTOMERNAME", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.String, obj._ADDRESS, "?_ADDRESS", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.String, obj._EMAIL, "?_EMAIL", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.String, obj._CONTACTPERSON, "?_CONTACTPERSON", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.String, obj._CONTACTNO, "?_CONTACTNO", ParameterDirection.Input);
            mySqlParam[7] = CreateParameters(DbType.String, obj._ACTIVE, "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[8] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[9] = CreateParameters(DbType.DateTime, obj._CREATEDON, "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[10] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            result = ((String)MySqlHelper.ExecuteScalar(connectionString, queryString, mySqlParam)).ToString();
            return result;
        }

        public DataSet GetCustomers(BLCustomer obj)
        {
            if (obj._MODE == "BYCUSTOMERID")
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

        public DataSet GetUserByUserID(BLCustomer obj)
        {
            string queryString = "CALL SP_MANAGECUSTOMER(?_CUSTOMERID, ?_CUSTOMERCODE, ?_CUSTOMERNAME, ?_ADDRESS, ?_EMAIL, ?_CONTACTPERSON, ?_CONTACTNO, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[11];
            
            mySqlParam[0] = CreateParameters(DbType.Int32, obj._CUSTOMERID, "?_CUSTOMERID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.String, "", "?_CUSTOMERCODE", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.String, "", "?_CUSTOMERNAME", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.String, "", "?_ADDRESS", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.String, "", "?_EMAIL", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.String, "", "?_CONTACTPERSON", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.String, "", "?_CONTACTNO", ParameterDirection.Input);
            mySqlParam[7] = CreateParameters(DbType.String, "", "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[8] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[9] = CreateParameters(DbType.DateTime, obj._CREATEDON, "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[10] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            DataSet _ds = (DataSet)MySqlHelper.ExecuteDataset(connectionString, queryString, mySqlParam);
            return _ds;
        }

        public DataSet GetAllActiveUsers(BLCustomer obj)
        {
            string queryString = "CALL SP_MANAGECUSTOMER(?_CUSTOMERID, ?_CUSTOMERCODE, ?_CUSTOMERNAME, ?_ADDRESS, ?_EMAIL, ?_CONTACTPERSON, ?_CONTACTNO, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[11];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._CUSTOMERID, "?_CUSTOMERID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.String, "", "?_CUSTOMERCODE", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.String, "", "?_CUSTOMERNAME", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.String, "", "?_ADDRESS", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.String, "", "?_EMAIL", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.String, "", "?_CONTACTPERSON", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.String, "", "?_CONTACTNO", ParameterDirection.Input);
            mySqlParam[7] = CreateParameters(DbType.String, "", "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[8] = CreateParameters(DbType.Int32, "1", "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[9] = CreateParameters(DbType.DateTime, obj._CREATEDON, "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[10] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            DataSet _ds = (DataSet)MySqlHelper.ExecuteDataset(connectionString, queryString, mySqlParam);
            return _ds;
        }

        public DataSet SearchUser(BLCustomer obj)
        {
            string queryString = "CALL SP_MANAGECUSTOMER(?_CUSTOMERID, ?_CUSTOMERCODE, ?_CUSTOMERNAME, ?_ADDRESS, ?_EMAIL, ?_CONTACTPERSON, ?_CONTACTNO, ?_ACTIVE, ?_CREATEDBY, ?_CREATEDON, ?_MODE)";
            MySqlParameter[] mySqlParam = new MySqlParameter[11];

            mySqlParam[0] = CreateParameters(DbType.Int32, obj._CUSTOMERID, "?_CUSTOMERID", ParameterDirection.Input);
            mySqlParam[1] = CreateParameters(DbType.String, obj._CUSTOMERCODE, "?_CUSTOMERCODE", ParameterDirection.Input);
            mySqlParam[2] = CreateParameters(DbType.String, obj._CUSTOMERNAME, "?_CUSTOMERNAME", ParameterDirection.Input);
            mySqlParam[3] = CreateParameters(DbType.String, "", "?_ADDRESS", ParameterDirection.Input);
            mySqlParam[4] = CreateParameters(DbType.String, "", "?_EMAIL", ParameterDirection.Input);
            mySqlParam[5] = CreateParameters(DbType.String, "", "?_CONTACTPERSON", ParameterDirection.Input);
            mySqlParam[6] = CreateParameters(DbType.String, "", "?_CONTACTNO", ParameterDirection.Input);
            mySqlParam[7] = CreateParameters(DbType.String, "", "?_ACTIVE", ParameterDirection.Input);
            mySqlParam[8] = CreateParameters(DbType.Int32, obj._CREATEDBY, "?_CREATEDBY", ParameterDirection.Input);
            mySqlParam[9] = CreateParameters(DbType.DateTime, obj._CREATEDON, "?_CREATEDON", ParameterDirection.Input);
            mySqlParam[10] = CreateParameters(DbType.String, obj._MODE, "?_MODE", ParameterDirection.Input);

            DataSet _ds = (DataSet)MySqlHelper.ExecuteDataset(connectionString, queryString, mySqlParam);
            return _ds;
        }
    }
}
