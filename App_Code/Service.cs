using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using DVPRWCFService.BusinessLayer;
using System.Security.Cryptography;

// NOTE: If you change the class name "Service" here, you must also update the reference to "Service" in Web.config and in the associated .svc file.
public class Service : IService
{
    public string GetData(int value)
    {
        return string.Format("You entered: {0}", value);
    }

    public CompositeType GetDataUsingDataContract(CompositeType composite)
    {
        if (composite.BoolValue)
        {
            composite.StringValue += "Suffix";
        }
        return composite;
    }

    #region USER
    public string ManageUsers(int _USERID, string _USERCODE, string _FIRSTNAME, string _LASTNAME, string _PASSWORD, string _EMAILID,
        string _ACTIVE, int _CREATEDBY, string _CREATEDON, string _MODE)
    {

        using (BLData objbl = new BLData())
        {
            objbl._USERID = Convert.ToInt32(_USERID);
            objbl._USERCODE = _USERCODE;
            objbl._FIRSTNAME = _FIRSTNAME;
            objbl._LASTNAME = _LASTNAME;
            objbl._PASSWORD = _PASSWORD;
            objbl._EMAILID = _EMAILID;
            objbl._ACTIVE = _ACTIVE;
            objbl._CREATEDBY = Convert.ToInt32(_CREATEDBY);
            objbl._CREATEDON = _CREATEDON;
            objbl._MODE = _MODE;
            //==================
            return objbl.ManageUsers();
            //==================
        }
    }

    public GetUser[] GetUsers(int _USERID, string _USERCODE, string _FIRSTNAME, string _LASTNAME, string _PASSWORD, string _EMAILID,
        string _ACTIVE, int _CREATEDBY, string _CREATEDON, string _MODE)
    {
        List<GetUser> returnObj = new List<GetUser>();

        using (BLData obj = new BLData())
        {
            //============
            obj._USERID = _USERID;
            obj._USERCODE = _USERCODE;
            obj._FIRSTNAME = _FIRSTNAME;
            obj._LASTNAME = _LASTNAME;
            obj._PASSWORD = _PASSWORD;
            obj._EMAILID = _EMAILID;
            obj._ACTIVE = _ACTIVE;
            obj._CREATEDBY = _CREATEDBY;
            obj._CREATEDON = _CREATEDON;
            obj._MODE = _MODE;
            //============
            DataSet ds = obj.GetUsers();
            //============
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                returnObj.Add(new GetUser()
                {
                    USERID = Convert.ToInt32(item["USERID"]),
                    USERCODE = Convert.ToString(item["USERCODE"]),
                    FIRSTNAME = Convert.ToString(item["FIRSTNAME"]),
                    LASTNAME = Convert.ToString(item["LASTNAME"]),
                    DISPLAYNAME = Convert.ToString(item["DISPLAYNAME"]),
                    PASSWORD = Convert.ToString(item["PASSWORD"]),
                    EMAILID = Convert.ToString(item["EMAILID"]),
                    ACTIVE = Convert.ToString(item["ACTIVE"]),
                });
            }
        }
        return returnObj.ToArray();
    }
    #endregion

    #region CUSTOMER
    public string ManageCustomer(int _CUSTOMERID, string _CUSTOMERCODE, string _CUSTOMERNAME, string _ADDRESS, string _EMAIL, string _CONTACTPERSON, string _CONTACTNO,
            string _ACTIVE, int _CREATEDBY, string _CREATEDON, string _MODE)
    {

        using (BLCustomer objbl = new BLCustomer())
        {
            objbl._CUSTOMERID = Convert.ToInt32(_CUSTOMERID);
            objbl._CUSTOMERCODE = _CUSTOMERCODE;
            objbl._CUSTOMERNAME = _CUSTOMERNAME;
            objbl._ADDRESS = _ADDRESS;
            objbl._EMAIL = _EMAIL;
            objbl._CONTACTPERSON = _CONTACTPERSON;
            objbl._CONTACTNO = _CONTACTNO;
            objbl._ACTIVE = _ACTIVE;
            objbl._CREATEDBY = Convert.ToInt32(_CREATEDBY);
            objbl._CREATEDON = _CREATEDON;
            objbl._MODE = _MODE;
            //==================
            return objbl.ManageCustomer();
            //==================
        }
    }

    public GetCustomer[] GetCustomers(int _CUSTOMERID, string _CUSTOMERCODE, string _CUSTOMERNAME, string _ADDRESS, string _EMAIL, string _CONTACTPERSON, string _CONTACTNO,
            string _ACTIVE, int _CREATEDBY, string _CREATEDON, string _MODE)
    {
        List<GetCustomer> returnObj = new List<GetCustomer>();

        using (BLCustomer obj = new BLCustomer())
        {
            //============
            obj._CUSTOMERID = _CUSTOMERID;
            obj._CUSTOMERCODE = _CUSTOMERCODE;
            obj._CUSTOMERNAME = _CUSTOMERNAME;
            obj._ADDRESS = _ADDRESS;
            obj._EMAIL = _EMAIL;
            obj._CONTACTPERSON = _CONTACTPERSON;
            obj._CONTACTNO = _CONTACTNO;
            obj._ACTIVE = _ACTIVE;
            obj._CREATEDBY = _CREATEDBY;
            obj._CREATEDON = _CREATEDON;
            obj._MODE = _MODE;
            //============
            DataSet ds = obj.GetCustomers();
            //============
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                returnObj.Add(new GetCustomer()
                {
                    CUSTOMERID = Convert.ToInt32(item["CUSTOMERID"]),
                    CUSTOMERCODE = Convert.ToString(item["CUSTOMERCODE"]),
                    CUSTOMERNAME = Convert.ToString(item["CUSTOMERNAME"]),
                    ADDRESS = Convert.ToString(item["ADDRESS"]),
                    CONTACTPERSON = Convert.ToString(item["CONTACTPERSON"]),
                    CONTACTNO = Convert.ToString(item["CONTACTNO"]),
                    EMAIL = Convert.ToString(item["EMAIL"]),
                    ACTIVE = Convert.ToString(item["ACTIVE"]),
                });
            }
        }
        return returnObj.ToArray();
    }
    #endregion

    #region INDUSTRYTYPE
    public string ManageIndustrytype(int _INDUSTRYTYPEID, string _INDUSTRYTYPECODE, string _INDUSTRYTYPENAME,
            string _ACTIVE, int _CREATEDBY, string _CREATEDON, string _MODE)
    {

        using (BLIndustryType objbl = new BLIndustryType())
        {
            objbl._INDUSTRYTYPEID = Convert.ToInt32(_INDUSTRYTYPEID);
            objbl._INDUSTRYTYPECODE = _INDUSTRYTYPECODE;
            objbl._INDUSTRYTYPENAME = _INDUSTRYTYPENAME;
            objbl._ACTIVE = _ACTIVE;
            objbl._CREATEDBY = Convert.ToInt32(_CREATEDBY);
            objbl._CREATEDON = _CREATEDON;
            objbl._MODE = _MODE;
            //==================
            return objbl.ManageIndustryTypes();
            //==================
        }
    }

    public GetIndustryType[] GetIndustryTypes(int _INDUSTRYTYPEID, string _INDUSTRYTYPECODE, string _INDUSTRYTYPENAME,
            string _ACTIVE, int _CREATEDBY, string _CREATEDON, string _MODE)
    {
        List<GetIndustryType> returnObj = new List<GetIndustryType>();

        using (BLIndustryType obj = new BLIndustryType())
        {
            //============
            obj._INDUSTRYTYPEID = _INDUSTRYTYPEID;
            obj._INDUSTRYTYPECODE = _INDUSTRYTYPECODE;
            obj._INDUSTRYTYPENAME = _INDUSTRYTYPENAME;
            obj._ACTIVE = _ACTIVE;
            obj._CREATEDBY = _CREATEDBY;
            obj._CREATEDON = _CREATEDON;
            obj._MODE = _MODE;
            //============
            DataSet ds = obj.GetIndustryTypes();
            //============
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                returnObj.Add(new GetIndustryType()
                {
                    INDUSTRYTYPEID = Convert.ToInt32(item["INDUSTRYTYPEID"]),
                    INDUSTRYTYPECODE = Convert.ToString(item["INDUSTRYTYPECODE"]),
                    INDUSTRYTYPENAME = Convert.ToString(item["INDUSTRYTYPENAME"]),
                    ACTIVE = Convert.ToString(item["ACTIVE"]),
                });
            }
        }
        return returnObj.ToArray();
    }
    #endregion

    #region LOCATION
    public string ManageLocations(int _LOCATIONID, string _LOCATIONCODE, string _LOCATIONNAME,
            string _ACTIVE, int _CREATEDBY, string _CREATEDON, string _MODE)
    {

        using (BLLocation objbl = new BLLocation())
        {
            objbl._LOCATIONID = Convert.ToInt32(_LOCATIONID);
            objbl._LOCATIONCODE = _LOCATIONCODE;
            objbl._LOCATIONNAME = _LOCATIONNAME;
            objbl._ACTIVE = _ACTIVE;
            objbl._CREATEDBY = Convert.ToInt32(_CREATEDBY);
            objbl._CREATEDON = _CREATEDON;
            objbl._MODE = _MODE;
            //==================
            return objbl.ManageLocations();
            //==================
        }
    }

    public GetLocation[] GetLocations(int _LOCATIONID, string _LOCATIONCODE, string _LOCATIONNAME,
            string _ACTIVE, int _CREATEDBY, string _CREATEDON, string _MODE)
    {
        List<GetLocation> returnObj = new List<GetLocation>();

        using (BLLocation obj = new BLLocation())
        {
            //============
            obj._LOCATIONID = _LOCATIONID;
            obj._LOCATIONCODE = _LOCATIONCODE;
            obj._LOCATIONNAME = _LOCATIONNAME;
            obj._ACTIVE = _ACTIVE;
            obj._CREATEDBY = _CREATEDBY;
            obj._CREATEDON = _CREATEDON;
            obj._MODE = _MODE;
            //============
            DataSet ds = obj.GetLocations();
            //============
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                returnObj.Add(new GetLocation()
                {
                    LOCATIONID = Convert.ToInt32(item["LOCATIONID"]),
                    LOCATIONCODE = Convert.ToString(item["LOCATIONCODE"]),
                    LOCATIONNAME = Convert.ToString(item["LOCATIONNAME"]),
                    ACTIVE = Convert.ToString(item["ACTIVE"]),
                });
            }
        }
        return returnObj.ToArray();
    }
    #endregion

    #region RFPHEADER
    public string ManageRFPHeaders(int _RFPID, string _RFPCODE, DateTime _RFPDATE, int _CUSTOMERID, int _INDUSTRYTYPEID, decimal _RFPAMOUNT,
            DateTime _STARTDATE, int _RFPOWNER, int _CURRENTSTAGINGOWNER, decimal _DIESELRATE, int _AGEOFTRUCK,
            string _ACTIVE, int _CREATEDBY, DateTime _CREATEDON, string _SEARCH1, string _SEARCH2, string _SEARCH3, string _MODE)
    {

        using (BLRFPHeader objbl = new BLRFPHeader())
        {
            objbl._RFPID = Convert.ToInt32(_RFPID);
            objbl._RFPCODE = _RFPCODE;
            objbl._RFPDATE = Convert.ToDateTime(_RFPDATE);
            objbl._CUSTOMERID = Convert.ToInt32(_CUSTOMERID);
            objbl._INDUSTRYTYPEID = Convert.ToInt32(_INDUSTRYTYPEID);
            objbl._RFPAMOUNT = Convert.ToDecimal(_RFPAMOUNT);
            objbl._STARTDATE = Convert.ToDateTime(_STARTDATE);
            objbl._RFPOWNER = Convert.ToInt32(_RFPOWNER);
            objbl._CURRENTSTAGINGOWNER = Convert.ToInt32(_CURRENTSTAGINGOWNER);
            objbl._DIESELRATE = Convert.ToDecimal(_DIESELRATE);
            objbl._AGEOFTRUCK = Convert.ToInt32(_AGEOFTRUCK);
            objbl._ACTIVE = _ACTIVE;
            objbl._CREATEDBY = Convert.ToInt32(_CREATEDBY);
            objbl._CREATEDONDATE = Convert.ToDateTime(_CREATEDON);
            objbl._SEARCH1 = _SEARCH1;
            objbl._SEARCH2 = _SEARCH2;
            objbl._SEARCH3 = _SEARCH3;
            objbl._MODE = _MODE;
            //==================
            return objbl.ManageRFPHeaders();
            //==================
        }
    }

    public GetRFPHeader[] GetRFPHeaders(int _RFPID, string _RFPCODE, DateTime _RFPDATE, int _CUSTOMERID, int _INDUSTRYTYPEID, decimal _RFPAMOUNT,
            DateTime _STARTDATE, int _RFPOWNER, int _CURRENTSTAGINGOWNER, decimal _DIESELRATE, int _AGEOFTRUCK,
            string _ACTIVE, int _CREATEDBY, DateTime _CREATEDON, string _SEARCH1, string _SEARCH2, string _SEARCH3, string _MODE)
    {
        List<GetRFPHeader> returnObj = new List<GetRFPHeader>();

        using (BLRFPHeader obj = new BLRFPHeader())
        {
            //============
            obj._RFPID = _RFPID;
            obj._RFPCODE = _RFPCODE;
            obj._RFPDATE = _RFPDATE;
            obj._CUSTOMERID = _CUSTOMERID;
            obj._INDUSTRYTYPEID = _INDUSTRYTYPEID;
            obj._RFPAMOUNT = _RFPAMOUNT;
            obj._STARTDATE = _STARTDATE;
            obj._RFPOWNER = _RFPOWNER;
            obj._CURRENTSTAGINGOWNER = _CURRENTSTAGINGOWNER;
            obj._DIESELRATE = _DIESELRATE;
            obj._AGEOFTRUCK = _AGEOFTRUCK;
            obj._ACTIVE = _ACTIVE;
            obj._CREATEDBY = _CREATEDBY;
            obj._CREATEDONDATE = _CREATEDON;
            obj._SEARCH1 = _SEARCH1;
            obj._SEARCH2 = _SEARCH2;
            obj._SEARCH3 = _SEARCH3;
            obj._MODE = _MODE;
            //============
            DataSet ds = obj.GetRFPHeaders();
            //============
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                returnObj.Add(new GetRFPHeader()
                {
                    RFPID = Convert.ToInt32(item["RFPID"]),
                    RFPCODE = Convert.ToString(item["RFPCODE"]),
                    RFPDATE = Convert.ToDateTime(item["RFPDATE"]),
                    CUSTOMERID = Convert.ToInt32(item["CUSTOMERID"]),
                    INDUSTRYTYPEID = Convert.ToInt32(item["INDUSTRYTYPEID"]),
                    RFPAMOUNT = Convert.ToDecimal(item["RFPAMOUNT"]),
                    STARTDATE = Convert.ToDateTime(item["STARTDATE"]),
                    RFPOWNER = Convert.ToInt32(item["RFPOWNER"]),
                    CURRENTSTAGINGOWNER = Convert.ToInt32(item["CURRENTSTAGINGOWNER"]),
                    ACTIVE = Convert.ToString(item["ACTIVE"]),
                    CUSTOMERNAME = Convert.ToString(item["CUSTOMERNAME"]),
                    INDUSTRYTYPENAME = Convert.ToString(item["INDUSTRYTYPENAME"]),
                    OWNERNAME = Convert.ToString(item["OWNERNAME"]),
                    CURRENTOWNERNAME = Convert.ToString(item["CURRENTOWNERNAME"]),
                });
            }
        }
        return returnObj.ToArray();
    }
    #endregion

    #region RFPDETAIL
    public string ManageRFPDetails(int _RFPID, int _FROMLOCATION, int _TOLOCATION, int _VEHICLETYPEID, decimal _APPROVEDAMOUNT, string _SERVICETYPE,
            decimal _RFPVOLUME, decimal _RFPDURATION,
            string _ACTIVE, int _CREATEDBY, DateTime _CREATEDON, string _SEARCH1, string _SEARCH2, string _SEARCH3, string _MODE)
    {

        using (BLRFPDetail objbl = new BLRFPDetail())
        {
            objbl._RFPID = Convert.ToInt32(_RFPID);
            objbl._FROMLOCATION = Convert.ToInt32(_FROMLOCATION);
            objbl._TOLOCATION = Convert.ToInt32(_TOLOCATION);
            objbl._VEHICLETYPEID = Convert.ToInt32(_VEHICLETYPEID);
            objbl._APPROVEDAMOUNT = Convert.ToDecimal(_APPROVEDAMOUNT);
            objbl._SERVICETYPE = Convert.ToString(_SERVICETYPE);
            objbl._RFPVOLUME = Convert.ToDecimal(_RFPVOLUME);
            objbl._RFPDURATION = Convert.ToDecimal(_RFPDURATION);
            objbl._ACTIVE = _ACTIVE;
            objbl._CREATEDBY = Convert.ToInt32(_CREATEDBY);
            objbl._CREATEDONDATE = Convert.ToDateTime(_CREATEDON);
            objbl._SEARCH1 = _SEARCH1;
            objbl._SEARCH2 = _SEARCH2;
            objbl._SEARCH3 = _SEARCH3;
            objbl._MODE = _MODE;
            //==================
            return objbl.ManageRFPDetails();
            //==================
        }
    }

    public GetRFPDetail[] GetRFPDetails(int _RFPID, int _FROMLOCATION, int _TOLOCATION, int _VEHICLETYPEID, decimal _APPROVEDAMOUNT, string _SERVICETYPE,
            decimal _RFPVOLUME, decimal _RFPDURATION,
            string _ACTIVE, int _CREATEDBY, DateTime _CREATEDON, string _SEARCH1, string _SEARCH2, string _SEARCH3, string _MODE)
    {
        List<GetRFPDetail> returnObj = new List<GetRFPDetail>();

        using (BLRFPDetail obj = new BLRFPDetail())
        {
            //============
            obj._RFPID = _RFPID;
            obj._FROMLOCATION = _FROMLOCATION;
            obj._TOLOCATION = _TOLOCATION;
            obj._VEHICLETYPEID = _VEHICLETYPEID;
            obj._APPROVEDAMOUNT = _APPROVEDAMOUNT;
            obj._SERVICETYPE = _SERVICETYPE;
            obj._RFPVOLUME = _RFPVOLUME;
            obj._RFPDURATION = _RFPDURATION;
            obj._ACTIVE = _ACTIVE;
            obj._CREATEDBY = _CREATEDBY;
            obj._CREATEDONDATE = _CREATEDON;
            obj._SEARCH1 = _SEARCH1;
            obj._SEARCH2 = _SEARCH2;
            obj._SEARCH3 = _SEARCH3;
            obj._MODE = _MODE;
            //============
            DataSet ds = obj.GetRFPDetails();
            //============
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                returnObj.Add(new GetRFPDetail()
                {
                    RFPID = Convert.ToInt32(item["RFPID"]),
                    FROMLOCATION = Convert.ToInt32(item["FROMLOCATION"]),
                    TOLOCATION = Convert.ToInt32(item["TOLOCATION"]),
                    VEHICLETYPEID = Convert.ToInt32(item["VEHICLETYPEID"]),
                    SERVICETYPE = Convert.ToString(item["SERVICETYPE"]),
                    APPROVEDAMOUNT = Convert.ToDecimal(item["APPROVEDAMOUNT"]),
                    ACTIVE = Convert.ToString(item["ACTIVE"]),
                    //LOCATIONNAME = Convert.ToString(item["LOCATIONNAME"]),
                    FROMLOCATIONNAME = Convert.ToString(item["FROMLOCATIONNAME"]),
                    TOLOCATIONNAME = Convert.ToString(item["TOLOCATIONNAME"]),
                    RFPVOLUME = Convert.ToDecimal(item["RFPVOLUME"]),
                    RFPDURATION = Convert.ToDecimal(item["RFPDURATION"]),
                    VEHICLETYPENAME = Convert.ToString(item["VEHICLETYPENAME"]),
                });
            }
        }
        return returnObj.ToArray();
    }
    #endregion

    #region MANAGERFPTRANSACTION

    public string ManageTransaction(int _RFPID, int _FROMLOCATION, int _TOLOCATION, int _VEHICLETYPEID, string _SERVICETYPE, decimal _CLEANSHEETRATE, decimal _CONTRACTRATE, decimal _SHIPXRATE, decimal _PVSRFPRATE, decimal _MARKETRATE, decimal _BAQUOTE, string _BACKHAULAVL, decimal _BACKHAULPERCENT, decimal _APPROVEDAMOUNT,
           string _ACTIVE, int _CREATEDBY, string _CREATEDON, string _MODE)
    {

        using (BLManageRFPTransaction objbl = new BLManageRFPTransaction())
        {
            objbl._RFPID = Convert.ToInt32(_RFPID);
            objbl._FROMLOCATION = Convert.ToInt32(_FROMLOCATION);
            objbl._TOLOCATION = Convert.ToInt32(_TOLOCATION);
            objbl._VEHICLETYPEID = Convert.ToInt32(_VEHICLETYPEID);
            objbl._SERVICETYPE = _SERVICETYPE;
            objbl._CLEANSHEETRATE = Convert.ToDecimal(_CLEANSHEETRATE);
            objbl._CONTRACTRATE = Convert.ToDecimal(_CONTRACTRATE);
            objbl._SHIPXRATE = Convert.ToDecimal(_SHIPXRATE);
            objbl._PVSRFPRATE = Convert.ToDecimal(_PVSRFPRATE);
            objbl._MARKETRATE = Convert.ToDecimal(_MARKETRATE);
            objbl._BAQUOTE = Convert.ToDecimal(_BAQUOTE);
            objbl._BACKHAULAVL = _BACKHAULAVL;
            objbl._BACKHAULPERCENT = Convert.ToDecimal(_BACKHAULPERCENT);
            objbl._APPROVEDAMOUNT = Convert.ToDecimal(_APPROVEDAMOUNT);
            objbl._ACTIVE = _ACTIVE;
            objbl._CREATEDBY = Convert.ToInt32(_CREATEDBY);
            objbl._CREATEDON = _CREATEDON;
            objbl._MODE = _MODE;
            //==================
            return objbl.ManageTransaction();
            //==================
        }
    }
    public GetManageTransaction[] GetManageTransaction(int _RFPID, int _FROMLOCATION, int _TOLOCATION, int _VEHICLETYPEID, string _SERVICETYPE, decimal _CLEANSHEETRATE, decimal _CONTRACTRATE, decimal _SHIPXRATE, decimal _PVSRFPRATE, decimal _MARKETRATE, decimal _BAQUOTE, string _BACKHAULAVL, decimal _BACKHAULPERCENT, decimal _APPROVEDAMOUNT,
           string _ACTIVE, int _CREATEDBY, string _CREATEDON, string _MODE)
    {
        List<GetManageTransaction> returnObj = new List<GetManageTransaction>();

        using (BLManageRFPTransaction obj = new BLManageRFPTransaction())
        {
            //============
            obj._RFPID = _RFPID;
            obj._FROMLOCATION = _FROMLOCATION;
            obj._TOLOCATION = _TOLOCATION;
            obj._VEHICLETYPEID = _VEHICLETYPEID;
            obj._SERVICETYPE = _SERVICETYPE;
            obj._CLEANSHEETRATE = _CLEANSHEETRATE;
            obj._CONTRACTRATE = _CONTRACTRATE;
            obj._SHIPXRATE = _SHIPXRATE;
            obj._PVSRFPRATE = _PVSRFPRATE;
            obj._MARKETRATE = _MARKETRATE;
            obj._BAQUOTE = _BAQUOTE;
            obj._BACKHAULAVL = _BACKHAULAVL;
            obj._BACKHAULPERCENT = _BACKHAULPERCENT;
            obj._APPROVEDAMOUNT = _APPROVEDAMOUNT;
            obj._ACTIVE = _ACTIVE;
            obj._MODE = _MODE;

            //============
            DataSet ds = obj.GetManageTransaction();
            //============
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                returnObj.Add(new GetManageTransaction()
                {
                    RFPID = Convert.ToInt32(item["RFPID"]),
                    FROMLOCATION = Convert.ToInt32(item["FROMLOCATION"]),
                    TOLOCATION = Convert.ToInt32(item["TOLOCATION"]),
                    VEHICLETYPEID = Convert.ToInt32(item["VEHICLETYPEID"]),
                    SERVICETYPE = Convert.ToString(item["SERVICETYPE"]),
                    CLEANSHEETRATE = Convert.ToDecimal(item["CLEANSHEETRATE"]),
                    CONTRACTRATE = Convert.ToDecimal(item["CONTRACTRATE"]),
                    SHIPXRATE = Convert.ToDecimal(item["SHIPXRATE"]),
                    PVSRFPRATE = Convert.ToDecimal(item["PVSRFPRATE"]),
                    MARKETRATE = Convert.ToDecimal(item["MARKETRATE"]),
                    BAQUOTE = Convert.ToDecimal(item["BAQUOTE"]),
                    BACKHAULAVL = Convert.ToString(item["BACKHAULAVL"]),
                    BACKHAULPERCENT = Convert.ToDecimal(item["BACKHAULPERCENT"]),
                    APPROVEDAMOUNT = Convert.ToDecimal(item["APPROVEDAMOUNT"]),
                    ACTIVE = Convert.ToString(item["ACTIVE"]),
                });
            }
        }
        return returnObj.ToArray();
    }

    #endregion

    #region USERRFPHEADER
    public string ManageUserRFPHeaders(int _RFPID, int _USERID, int _CURRENTSTAGINGOWNER, DateTime _RECENTDATE, string _ACTIVE, int _CREATEDBY, DateTime _CREATEDON, string _MODE)
    {

        using (BLUserRFPHeader objbl = new BLUserRFPHeader())
        {
            objbl._RFPID = Convert.ToInt32(_RFPID);
            objbl._USERID = Convert.ToInt32(_USERID);
            objbl._CURRENTSTAGINGOWNERVALUE = Convert.ToInt32(_CURRENTSTAGINGOWNER);
            objbl._RECENTDATE = Convert.ToDateTime(_RECENTDATE);
            objbl._ACTIVE = _ACTIVE;
            objbl._CREATEDBY = Convert.ToInt32(_CREATEDBY);
            objbl._CREATEDONDATE = Convert.ToDateTime(_CREATEDON);
            objbl._MODE = _MODE;
            //==================
            return objbl.ManageRFPHeaders();
            //==================
        }
    }

    public GetUserRFPHeader[] GetUserRFPHeaders(int _RFPID, int _USERID, int _CURRENTSTAGINGOWNER, DateTime _RECENTDATE, string _ACTIVE, int _CREATEDBY, DateTime _CREATEDON, string _MODE)
    {
        List<GetUserRFPHeader> returnObj = new List<GetUserRFPHeader>();

        using (BLUserRFPHeader obj = new BLUserRFPHeader())
        {
            //============
            obj._RFPID = Convert.ToInt32(_RFPID);
            obj._USERID = Convert.ToInt32(_USERID);
            obj._CURRENTSTAGINGOWNERVALUE = Convert.ToInt32(_CURRENTSTAGINGOWNER);
            obj._RECENTDATE = _RECENTDATE;
            obj._ACTIVE = _ACTIVE;
            obj._CREATEDBY = _CREATEDBY;
            obj._CREATEDONDATE = _CREATEDON;
            obj._MODE = _MODE;
            //============
            DataSet ds = obj.GetUserRFPHeaders();
            //============
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                returnObj.Add(new GetUserRFPHeader()
                {
                    USERID = Convert.ToInt32(item["USERID"]),
                    _CURRENTSTAGINGOWNER = Convert.ToInt32(item["CURRENTSTAGINGOWNER"]),
                    RECENTDATE = Convert.ToDateTime(item["RECENTDATE"]),
                    ACTIVE = Convert.ToString(item["ACTIVE"]),
                });
            }
        }
        return returnObj.ToArray();
    }
    #endregion

    #region VEHICLETYPE
    public string ManageVehicletypes(int _VEHICLETYPEID, string _VEHICLETYPECODE, string _VEHICLETYPENAME, string _ACTIVE, int _CREATEDBY, DateTime _CREATEDON, string _MODE)
    {
        using (BLVehicletype objbl = new BLVehicletype())
        {
            objbl._VEHICLETYPEID = Convert.ToInt32(_VEHICLETYPEID);
            objbl._VEHICLETYPECODE = Convert.ToString(_VEHICLETYPECODE);
            objbl._VEHICLETYPENAME = _VEHICLETYPENAME;
            objbl._ACTIVE = _ACTIVE;
            objbl._CREATEDBY = Convert.ToInt32(_CREATEDBY);
            objbl._CREATEDONDATE = Convert.ToDateTime(_CREATEDON);
            objbl._MODE = _MODE;
            //==================
            return objbl.ManageVehicletypes();
            //==================
        }
    }

    public GetVehicletype[] GetVehicletypes(int _VEHICLETYPEID, string _VEHICLETYPECODE, string _VEHICLETYPENAME, string _ACTIVE, int _CREATEDBY, DateTime _CREATEDON, string _MODE)
    {
        List<GetVehicletype> returnObj = new List<GetVehicletype>();

        using (BLVehicletype obj = new BLVehicletype())
        {
            //============
            obj._VEHICLETYPEID = _VEHICLETYPEID;
            obj._VEHICLETYPECODE = _VEHICLETYPECODE;
            obj._VEHICLETYPENAME = _VEHICLETYPENAME;
            obj._ACTIVE = _ACTIVE;
            obj._CREATEDBY = _CREATEDBY;
            obj._CREATEDONDATE = _CREATEDON;
            obj._MODE = _MODE;
            //============
            DataSet ds = obj.GetVehicletypes();
            //============
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    returnObj.Add(new GetVehicletype()
                    {
                        VEHICLETYPEID = Convert.ToInt32(item["VEHICLETYPEID"]),
                        VEHICLETYPECODE = Convert.ToString(item["VEHICLETYPECODE"]),
                        VEHICLETYPENAME = Convert.ToString(item["VEHICLETYPENAME"]),
                        ACTIVE = Convert.ToString(item["ACTIVE"]),
                    });
                }
            }
        }
        return returnObj.ToArray();
    }
    #endregion
}
