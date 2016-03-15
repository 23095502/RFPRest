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
public class RFPRestService : IService
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

    public GetUser[] login(string user, string pwd)
    {
        List<GetUser> returnObj = new List<GetUser>();

        using (BLData obj = new BLData())
        {
            //============
            obj._USERID = 0;
            obj._USERCODE = "";
            obj._FIRSTNAME = "";
            obj._LASTNAME = "";
            obj._PASSWORD = pwd;
            obj._EMAILID = "";
            obj._ACTIVE = "A";
            obj._CREATEDBY = 1;
            obj._CREATEDON = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            obj._MODE = "LOGIN";
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

    public GetUser[] user(string all)
    {
        Int32 _id = 0;
        string _mode = "GETALL";

        if (all != "0")
        {
            _mode = "BYUSERID";
            _id = Convert.ToInt32(all);
        }

        List<GetUser> returnObj = new List<GetUser>();

        using (BLData obj = new BLData())
        {
            //============
            obj._USERID = _id;
            obj._USERCODE = "";
            obj._FIRSTNAME = "";
            obj._LASTNAME = "";
            obj._PASSWORD = "";
            obj._EMAILID = "";
            obj._ACTIVE = "A";
            obj._CREATEDBY = 1;
            obj._CREATEDON = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            obj._MODE = _mode;
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
    public string updtcustomer(GetCustomer cust)
    {
        BLCustomer obj = new BLCustomer();
        return obj.ManageCustomer(cust);
    }

    public GetCustomer[] customer(string all)
    {

        Int32 _id = 0;
        string _mode = "GETALL";

        if (all != "0")
        {
            _mode = "BYCUSTOMERID";
            _id = Convert.ToInt32(all);
        }

        List<GetCustomer> returnObj = new List<GetCustomer>();

        using (BLCustomer obj = new BLCustomer())
        {
            //============
            obj._CUSTOMERID = _id;
            obj._CUSTOMERCODE = "";
            obj._CUSTOMERNAME = "";
            obj._ADDRESS = "";
            obj._EMAIL = "";
            obj._CONTACTPERSON = "";
            obj._CONTACTNO = "";
            obj._CASHACCOUNTID = "";
            obj._TOTALSPEND = 0;
            obj._ACTIVE = "A";
            obj._CREATEDBY = 1;
            obj._CREATEDON = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            obj._MODE = _mode;
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
                    CASHACCOUNTID = Convert.ToString(item["CASHACCOUNTID"]),
                    TOTALSPEND = Convert.ToDecimal(item["TOTALSPEND"]),
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

    public GetIndustryType[] industrytype(string all)
    {
        Int32 _id = 0;
        string _mode = "GETALL";

        if (all != "0")
        {
            _mode = "BYINDUSTRYTYPEID";
            _id = Convert.ToInt32(all);
        }

        List<GetIndustryType> returnObj = new List<GetIndustryType>();

        using (BLIndustryType obj = new BLIndustryType())
        {
            //============
            obj._INDUSTRYTYPEID = _id;
            obj._INDUSTRYTYPECODE = "";
            obj._INDUSTRYTYPENAME = "";
            obj._ACTIVE = "A";
            obj._CREATEDBY = 1;
            obj._CREATEDON = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            obj._MODE = _mode;
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
            string _STATEID, string _ACTIVE, int _CREATEDBY, string _CREATEDON, string _MODE)
    {

        using (BLLocation objbl = new BLLocation())
        {
            objbl._LOCATIONID = Convert.ToInt32(_LOCATIONID);
            objbl._LOCATIONCODE = _LOCATIONCODE;
            objbl._LOCATIONNAME = _LOCATIONNAME;
            objbl._STATEID = Convert.ToInt32(_STATEID);
            objbl._ACTIVE = _ACTIVE;
            objbl._CREATEDBY = Convert.ToInt32(_CREATEDBY);
            objbl._CREATEDON = _CREATEDON;
            objbl._MODE = _MODE;
            //==================
            return objbl.ManageLocations();
            //==================
        }
    }

    public GetLocation[] location(string all)
    {

        Int32 _Locationid = 0;
        string _mode = "GETALL";

        if (all != "0")
        {
            _mode = "BYLOCATIONID";
            _Locationid = Convert.ToInt32(all);
        }

        List<GetLocation> returnObj = new List<GetLocation>();

        using (BLLocation obj = new BLLocation())
        {
            //============
            obj._LOCATIONID = _Locationid;
            obj._LOCATIONCODE = "";
            obj._LOCATIONNAME = "";
            obj._STATEID = 0;
            obj._ACTIVE = "A";
            obj._CREATEDBY = 1;
            obj._CREATEDON = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            obj._MODE = _mode;
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
                    STATEID = Convert.ToInt32(item["STATEID"]),
                    ACTIVE = Convert.ToString(item["ACTIVE"]),
                });
            }
        }
        return returnObj.ToArray();
    }
    #endregion

    #region RFPHEADER
    public RFPHeaderResponse[] rfp(string mode, RFPTable rfpupdt)
    {
        List<RFPHeaderResponse> returnObj = new List<RFPHeaderResponse>();
        BLRFPHeader oBLRFPHeader = new BLRFPHeader();
        try
        {
            if (rfpupdt == null)
            {
                return null;
            }

            DataSet ds = oBLRFPHeader.UpdateRFPHeader(mode, rfpupdt);

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                returnObj.Add(new RFPHeaderResponse()
                {
                    RFPID = Convert.ToInt32(item["RFPID"]),
                    RFPCODE = Convert.ToString(item["RFPCODE"]),
                    RFPDATE = Convert.ToDateTime(item["RFPDATE"]).ToString("yyyy-MM-dd HH:mm:ss"),
                    CUSTOMERID = Convert.ToInt32(item["CUSTOMERID"]),
                    INDUSTRYTYPEID = Convert.ToInt32(item["INDUSTRYTYPEID"]),
                    RFPAMOUNT = Convert.ToDecimal(item["RFPAMOUNT"]),
                    STARTDATE = Convert.ToDateTime(item["STARTDATE"]).ToString("yyyy-MM-dd HH:mm:ss"),
                    RFPOWNER = Convert.ToInt32(item["RFPOWNER"]),
                    CURRENTSTAGINGOWNER = Convert.ToInt32(item["CURRENTSTAGINGOWNER"]),
                    ACTIVE = Convert.ToString(item["ACTIVE"]),

                    CREATEDBY = Convert.ToInt32(item["CREATEDBY"]),
                    CREATEDON = Convert.ToDateTime(item["CREATEDON"]).ToString("yyyy-MM-dd HH:mm:ss"),

                    RFPDESC = Convert.ToString(item["RFPDESC"]),
                    DUEDATE = Convert.ToDateTime(item["DUEDATE"]).ToString("yyyy-MM-dd HH:mm:ss"),
                    PRODUCTDESC = Convert.ToString(item["PRODUCTDESC"]),
                    CASHOPPID = Convert.ToString(item["CASHOPPID"]),
                    OPPRDOMAIN = Convert.ToString(item["OPPRDOMAIN"]),
                    DISTRIBUTIONTYPE = Convert.ToString(item["DISTRIBUTIONTYPE"]),
                    ISMULTIDROP = Convert.ToString(item["ISMULTIDROP"]),
                    ISHUBORWHREQ = Convert.ToString(item["ISHUBORWHREQ"]),
                    CARGOTYPE = Convert.ToString(item["CARGOTYPE"]),
                    PAYMENTTERM = Convert.ToInt32(item["PAYMENTTERM"]),
                    RATEUOM = Convert.ToString(item["RATEUOM"]),
                    PENALITIES = Convert.ToString(item["PENALITIES"]),
                    DETENTION = Convert.ToString(item["DETENTION"]),
                    ESCCLAUSE = Convert.ToString(item["ESCCLAUSE"]),

                    CUSTOMERNAME = Convert.ToString(item["CUSTOMERNAME"]),
                    INDUSTRYTYPENAME = Convert.ToString(item["INDUSTRYTYPENAME"]),
                    OWNERNAME = Convert.ToString(item["OWNERNAME"]),
                    CURRENTOWNERNAME = Convert.ToString(item["CURRENTOWNERNAME"]),
                    AGEOFTRUCK = Convert.ToInt32(item["AGEOFTRUCK"]),
                    DIESELRATE = Convert.ToDecimal(item["DIESELRATE"]),
                });
            }
        }
        catch (Exception e)
        {
            return null;
        }

        return returnObj.ToArray();

    }

    public RFPHeaderResponse[] getrfp(string rfpid, string mode, RFPTable rfpupdt)
    {
        //return oBLRFPHeader.GetRFPHeaderDetails(rfpid, mode, rfpupdt);

        List<RFPHeaderResponse> returnObj = new List<RFPHeaderResponse>();

        BLRFPHeader oBLRFPHeader = new BLRFPHeader();
        DataSet ds = oBLRFPHeader.GetRFPHeaderDetails(Convert.ToInt32(rfpid), mode, rfpupdt);
        //============

        foreach (DataRow item in ds.Tables[0].Rows)
        {
            returnObj.Add(new RFPHeaderResponse()
            {
                RFPID = Convert.ToInt32(item["RFPID"]),
                RFPCODE = Convert.ToString(item["RFPCODE"]),
                RFPDATE = Convert.ToDateTime(item["RFPDATE"]).ToString("yyyy-MM-dd HH:mm:ss"),
                CUSTOMERID = Convert.ToInt32(item["CUSTOMERID"]),
                INDUSTRYTYPEID = Convert.ToInt32(item["INDUSTRYTYPEID"]),
                RFPAMOUNT = Convert.ToDecimal(item["RFPAMOUNT"]),
                STARTDATE = Convert.ToDateTime(item["STARTDATE"]).ToString("yyyy-MM-dd HH:mm:ss"),
                RFPOWNER = Convert.ToInt32(item["RFPOWNER"]),
                CURRENTSTAGINGOWNER = Convert.ToInt32(item["CURRENTSTAGINGOWNER"]),
                ACTIVE = Convert.ToString(item["ACTIVE"]),

                CREATEDBY = Convert.ToInt32(item["CREATEDBY"]),
                CREATEDON = Convert.ToDateTime(item["CREATEDON"]).ToString("yyyy-MM-dd HH:mm:ss"),

                RFPDESC = Convert.ToString(item["RFPDESC"]),
                DUEDATE = Convert.ToDateTime(item["DUEDATE"]).ToString("yyyy-MM-dd HH:mm:ss"),
                PRODUCTDESC = Convert.ToString(item["PRODUCTDESC"]),
                CASHOPPID = Convert.ToString(item["CASHOPPID"]),
                OPPRDOMAIN = Convert.ToString(item["OPPRDOMAIN"]),
                DISTRIBUTIONTYPE = Convert.ToString(item["DISTRIBUTIONTYPE"]),
                ISMULTIDROP = Convert.ToString(item["ISMULTIDROP"]),
                ISHUBORWHREQ = Convert.ToString(item["ISHUBORWHREQ"]),
                CARGOTYPE = Convert.ToString(item["CARGOTYPE"]),
                PAYMENTTERM = Convert.ToInt32(item["PAYMENTTERM"]),
                RATEUOM = Convert.ToString(item["RATEUOM"]),
                PENALITIES = Convert.ToString(item["PENALITIES"]),
                DETENTION = Convert.ToString(item["DETENTION"]),
                ESCCLAUSE = Convert.ToString(item["ESCCLAUSE"]),

                CUSTOMERNAME = Convert.ToString(item["CUSTOMERNAME"]),
                INDUSTRYTYPENAME = Convert.ToString(item["INDUSTRYTYPENAME"]),
                OWNERNAME = Convert.ToString(item["OWNERNAME"]),
                CURRENTOWNERNAME = Convert.ToString(item["CURRENTOWNERNAME"]),
                AGEOFTRUCK = Convert.ToInt32(item["AGEOFTRUCK"]),
                DIESELRATE = Convert.ToDecimal(item["DIESELRATE"]),
            });
        }
        return returnObj.ToArray();
    }

    public RFPHeaderResponse[] getrfpbyrfpid(string rfpid)
    {
        //return oBLRFPHeader.GetRFPHeaderDetails(rfpid, mode, rfpupdt);

        List<RFPHeaderResponse> returnObj = new List<RFPHeaderResponse>();

        BLRFPHeader oBLRFPHeader = new BLRFPHeader();
        DataSet ds = oBLRFPHeader.GetRFPByID(Convert.ToInt32(rfpid), "BYRFPID");
        //============

        foreach (DataRow item in ds.Tables[0].Rows)
        {
            returnObj.Add(new RFPHeaderResponse()
            {
                RFPID = Convert.ToInt32(item["RFPID"]),
                RFPCODE = Convert.ToString(item["RFPCODE"]),
                RFPDATE = Convert.ToDateTime(item["RFPDATE"]).ToString("yyyy-MM-dd HH:mm:ss"),
                CUSTOMERID = Convert.ToInt32(item["CUSTOMERID"]),
                INDUSTRYTYPEID = Convert.ToInt32(item["INDUSTRYTYPEID"]),
                RFPAMOUNT = Convert.ToDecimal(item["RFPAMOUNT"]),
                STARTDATE = Convert.ToDateTime(item["STARTDATE"]).ToString("yyyy-MM-dd HH:mm:ss"),
                RFPOWNER = Convert.ToInt32(item["RFPOWNER"]),
                CURRENTSTAGINGOWNER = Convert.ToInt32(item["CURRENTSTAGINGOWNER"]),
                ACTIVE = Convert.ToString(item["ACTIVE"]),

                CREATEDBY = Convert.ToInt32(item["CREATEDBY"]),
                CREATEDON = Convert.ToDateTime(item["CREATEDON"]).ToString("yyyy-MM-dd HH:mm:ss"),

                RFPDESC = Convert.ToString(item["RFPDESC"]),
                DUEDATE = Convert.ToDateTime(item["DUEDATE"]).ToString("yyyy-MM-dd HH:mm:ss"),
                PRODUCTDESC = Convert.ToString(item["PRODUCTDESC"]),
                CASHOPPID = Convert.ToString(item["CASHOPPID"]),
                OPPRDOMAIN = Convert.ToString(item["OPPRDOMAIN"]),
                DISTRIBUTIONTYPE = Convert.ToString(item["DISTRIBUTIONTYPE"]),
                ISMULTIDROP = Convert.ToString(item["ISMULTIDROP"]),
                ISHUBORWHREQ = Convert.ToString(item["ISHUBORWHREQ"]),
                CARGOTYPE = Convert.ToString(item["CARGOTYPE"]),
                PAYMENTTERM = Convert.ToInt32(item["PAYMENTTERM"]),
                RATEUOM = Convert.ToString(item["RATEUOM"]),
                PENALITIES = Convert.ToString(item["PENALITIES"]),
                DETENTION = Convert.ToString(item["DETENTION"]),
                ESCCLAUSE = Convert.ToString(item["ESCCLAUSE"]),

                CUSTOMERNAME = Convert.ToString(item["CUSTOMERNAME"]),
                INDUSTRYTYPENAME = Convert.ToString(item["INDUSTRYTYPENAME"]),
                OWNERNAME = Convert.ToString(item["OWNERNAME"]),
                CURRENTOWNERNAME = Convert.ToString(item["CURRENTOWNERNAME"]),
                AGEOFTRUCK = Convert.ToInt32(item["AGEOFTRUCK"]),
                DIESELRATE = Convert.ToDecimal(item["DIESELRATE"]),
            });
        }
        return returnObj.ToArray();
    }

    public RFPHeaderResponse[] getrfplist(string search)
    {
        //return oBLRFPHeader.GetRFPHeaderDetails(rfpid, mode, rfpupdt);
        string mode = "GETALL";
        if (search.ToUpper() != "GETALL")
        {
            mode = "SEARCH";
        }

        List<RFPHeaderResponse> returnObj = new List<RFPHeaderResponse>();

        BLRFPHeader oBLRFPHeader = new BLRFPHeader();
        oBLRFPHeader._MODE = mode;
        oBLRFPHeader._SEARCH1 = search;
        oBLRFPHeader._RFPID = 0;
        DataSet ds = oBLRFPHeader.GetRFPHeaders();
        //============

        foreach (DataRow item in ds.Tables[0].Rows)
        {
            returnObj.Add(new RFPHeaderResponse()
            {
                RFPID = Convert.ToInt32(item["RFPID"]),
                RFPCODE = Convert.ToString(item["RFPCODE"]),
                RFPDATE = Convert.ToDateTime(item["RFPDATE"]).ToString("yyyy-MM-dd HH:mm:ss"),
                CUSTOMERID = Convert.ToInt32(item["CUSTOMERID"]),
                INDUSTRYTYPEID = Convert.ToInt32(item["INDUSTRYTYPEID"]),
                RFPAMOUNT = Convert.ToDecimal(item["RFPAMOUNT"]),
                STARTDATE = Convert.ToDateTime(item["STARTDATE"]).ToString("yyyy-MM-dd HH:mm:ss"),
                RFPOWNER = Convert.ToInt32(item["RFPOWNER"]),
                CURRENTSTAGINGOWNER = Convert.ToInt32(item["CURRENTSTAGINGOWNER"]),
                ACTIVE = Convert.ToString(item["ACTIVE"]),
                CREATEDBY = Convert.ToInt32(item["CREATEDBY"]),
                CREATEDON = Convert.ToDateTime(item["CREATEDON"]).ToString("yyyy-MM-dd HH:mm:ss"),
                RFPDESC = Convert.ToString(item["RFPDESC"]),
                DUEDATE = Convert.ToDateTime(item["DUEDATE"]).ToString("yyyy-MM-dd HH:mm:ss"),
                PRODUCTDESC = Convert.ToString(item["PRODUCTDESC"]),
                CASHOPPID = Convert.ToString(item["CASHOPPID"]),
                OPPRDOMAIN = Convert.ToString(item["OPPRDOMAIN"]),
                DISTRIBUTIONTYPE = Convert.ToString(item["DISTRIBUTIONTYPE"]),
                ISMULTIDROP = Convert.ToString(item["ISMULTIDROP"]),
                ISHUBORWHREQ = Convert.ToString(item["ISHUBORWHREQ"]),
                CARGOTYPE = Convert.ToString(item["CARGOTYPE"]),
                PAYMENTTERM = Convert.ToInt32(item["PAYMENTTERM"]),
                RATEUOM = Convert.ToString(item["RATEUOM"]),
                PENALITIES = Convert.ToString(item["PENALITIES"]),
                DETENTION = Convert.ToString(item["DETENTION"]),
                ESCCLAUSE = Convert.ToString(item["ESCCLAUSE"]),
                CUSTOMERNAME = Convert.ToString(item["CUSTOMERNAME"]),
                INDUSTRYTYPENAME = Convert.ToString(item["INDUSTRYTYPENAME"]),
                OWNERNAME = Convert.ToString(item["OWNERNAME"]),
                CURRENTOWNERNAME = Convert.ToString(item["CURRENTOWNERNAME"]),
                AGEOFTRUCK = Convert.ToInt32(item["AGEOFTRUCK"]),
                DIESELRATE = Convert.ToDecimal(item["DIESELRATE"]),
            });
        }
        return returnObj.ToArray();
    }

    public RFPHeaderResponse[] getrfpbycustomerid(string custmerid)
    {
        //return oBLRFPHeader.GetRFPHeaderDetails(rfpid, mode, rfpupdt);

        List<RFPHeaderResponse> returnObj = new List<RFPHeaderResponse>();

        BLRFPHeader oBLRFPHeader = new BLRFPHeader();
        DataSet ds = oBLRFPHeader.GetRFPByID(Convert.ToInt32(custmerid), "BYCUSTOMERID");
        //============

        foreach (DataRow item in ds.Tables[0].Rows)
        {
            returnObj.Add(new RFPHeaderResponse()
            {
                RFPID = Convert.ToInt32(item["RFPID"]),
                RFPCODE = Convert.ToString(item["RFPCODE"]),
                RFPDATE = Convert.ToDateTime(item["RFPDATE"]).ToString("yyyy-MM-dd"),
                CUSTOMERID = Convert.ToInt32(item["CUSTOMERID"]),
                INDUSTRYTYPEID = Convert.ToInt32(item["INDUSTRYTYPEID"]),
                RFPAMOUNT = Convert.ToDecimal(item["RFPAMOUNT"]),
                STARTDATE = Convert.ToDateTime(item["STARTDATE"]).ToString("yyyy-MM-dd"),
                RFPOWNER = Convert.ToInt32(item["RFPOWNER"]),
                CURRENTSTAGINGOWNER = Convert.ToInt32(item["CURRENTSTAGINGOWNER"]),
                ACTIVE = Convert.ToString(item["ACTIVE"]),

                CREATEDBY = Convert.ToInt32(item["CREATEDBY"]),
                CREATEDON = Convert.ToDateTime(item["CREATEDON"]).ToString("yyyy-MM-dd HH:mm:ss"),

                RFPDESC = Convert.ToString(item["RFPDESC"]),
                DUEDATE = Convert.ToDateTime(item["DUEDATE"]).ToString("yyyy-MM-dd"),
                PRODUCTDESC = Convert.ToString(item["PRODUCTDESC"]),
                CASHOPPID = Convert.ToString(item["CASHOPPID"]),
                OPPRDOMAIN = Convert.ToString(item["OPPRDOMAIN"]),
                DISTRIBUTIONTYPE = Convert.ToString(item["DISTRIBUTIONTYPE"]),
                ISMULTIDROP = Convert.ToString(item["ISMULTIDROP"]),
                ISHUBORWHREQ = Convert.ToString(item["ISHUBORWHREQ"]),
                CARGOTYPE = Convert.ToString(item["CARGOTYPE"]),
                PAYMENTTERM = Convert.ToInt32(item["PAYMENTTERM"]),
                RATEUOM = Convert.ToString(item["RATEUOM"]),
                PENALITIES = Convert.ToString(item["PENALITIES"]),
                DETENTION = Convert.ToString(item["DETENTION"]),
                ESCCLAUSE = Convert.ToString(item["ESCCLAUSE"]),
                CUSTOMERNAME = Convert.ToString(item["CUSTOMERNAME"]),
                INDUSTRYTYPENAME = Convert.ToString(item["INDUSTRYTYPENAME"]),
                OWNERNAME = Convert.ToString(item["OWNERNAME"]),
                CURRENTOWNERNAME = Convert.ToString(item["CURRENTOWNERNAME"]),
                AGEOFTRUCK = Convert.ToInt32(item["AGEOFTRUCK"]),
                DIESELRATE = Convert.ToDecimal(item["DIESELRATE"]),
            });
        }
        return returnObj.ToArray();
    }

    #endregion

    #region RFPDETAIL

    public string rfproute(string rfpid, string mode, RFPDetailTable rfproute)
    {
        BLRFPDetail oBLRFPDetail = new BLRFPDetail();
        try
        {
            if (rfproute == null)
            {
                return "NULL VALUE";
            }
        }
        catch (Exception e)
        {
            return e.Message;
        }
        return oBLRFPDetail.UpdateRFPDetail(Convert.ToInt32(rfpid), mode, rfproute);

    }

    public RFPDetailTable[] routeupdate(RFPDetailTable[] rfproute)
    {
        BLRFPDetail oBLRFPDetail = new BLRFPDetail();
        try
        {
            if (rfproute == null)
            {
                return null;
            }
        }
        catch (Exception e)
        {
            return null;
        }

        List<RFPDetailTable> returnObj = new List<RFPDetailTable>();

        returnObj = oBLRFPDetail.UpdateRFPDetail(rfproute);

        return returnObj.ToArray();
    }

    public RFPDetailResponse[] getrfproute(string rfpid, string mode, RFPDetailTable rfproute)
    {
        List<RFPDetailResponse> returnObj = new List<RFPDetailResponse>();

        BLRFPDetail oBLRFPDetail = new BLRFPDetail();
        DataSet ds = oBLRFPDetail.GetRFPDetails(Convert.ToInt32(rfpid), mode, rfproute);
        //============

        foreach (DataRow item in ds.Tables[0].Rows)
        {
            returnObj.Add(new RFPDetailResponse()
            {
                RFPID = Convert.ToInt32(item["RFPID"]),
                FROMLOCATION = Convert.ToInt32(item["FROMLOCATION"]),
                TOLOCATION = Convert.ToInt32(item["TOLOCATION"]),
                VEHICLETYPEID = Convert.ToInt32(item["VEHICLETYPEID"]),
                SERVICETYPE = Convert.ToString(item["SERVICETYPE"]),
                APPROVEDAMOUNT = Convert.ToDecimal(item["APPROVEDAMOUNT"]),
                ACTIVE = Convert.ToString(item["ACTIVE"]),
                FROMLOCATIONNAME = Convert.ToString(item["FROMLOCATIONNAME"]),
                TOLOCATIONNAME = Convert.ToString(item["TOLOCATIONNAME"]),
                RFPVOLUME = Convert.ToDecimal(item["RFPVOLUME"]),
                RFPDURATION = Convert.ToDecimal(item["RFPDURATION"]),
                LOADINGUNLOADINGTIME = Convert.ToDecimal(item["LOADINGUNLOADINGTIME"]),
                BACKHAUL = Convert.ToInt32(item["BACKHAUL"]),
                DISTANCE = Convert.ToInt32(item["DISTANCE"]),
                VEHICLETYPENAME = Convert.ToString(item["VEHICLETYPENAME"]),
                PACKAGETYPEID = Convert.ToInt32(item["PACKAGETYPEID"]),
                PACKDIMENSION = Convert.ToString(item["PACKDIMENSION"]),
                STACKINGNORMS = Convert.ToString(item["STACKINGNORMS"]),
                CUSTTARGETRATE = Convert.ToString(item["CUSTTARGETRATE"]),
                ISLOADUNLOADCHARG = Convert.ToString(item["ISLOADUNLOADCHARG"]),
                AVERAGELOAD = Convert.ToString(item["AVERAGELOAD"]),
                FREQUENCY = Convert.ToString(item["FREQUENCY"]),
                MHEREQUIREMENT = Convert.ToString(item["MHEREQUIREMENT"]),
                OTHERREQUIREMENT = Convert.ToString(item["OTHERREQUIREMENT"]),
                NOOFTRIPS = Convert.ToInt32(item["NOOFTRIPS"]),
                ISROUNDTRIP = Convert.ToString(item["ISROUNDTRIP"]),
                FROMSTATE = Convert.ToString(item["FROMSTATE"]),
                TOSTATE = Convert.ToString(item["TOSTATE"]),
                FROMSTATEID = Convert.ToInt32(item["FROMSTATEID"]),
                TOSTATEID = Convert.ToInt32(item["TOSTATEID"]),
                PACKAGETYPENAME = Convert.ToString(item["PACKAGETYPENAME"]),
            });
        }
        return returnObj.ToArray();
    }

    public RFPDetailResponse[] getrfproutebyid(string rfpid)
    {
        List<RFPDetailResponse> returnObj = new List<RFPDetailResponse>();

        BLRFPDetail oBLRFPDetail = new BLRFPDetail();
        DataSet ds = oBLRFPDetail.GetRFPDetailsBYID(Convert.ToInt32(rfpid), "BYRFPID");
        //============

        foreach (DataRow item in ds.Tables[0].Rows)
        {
            returnObj.Add(new RFPDetailResponse()
            {
                RFPID = Convert.ToInt32(item["RFPID"]),
                FROMLOCATION = Convert.ToInt32(item["FROMLOCATION"]),
                TOLOCATION = Convert.ToInt32(item["TOLOCATION"]),
                VEHICLETYPEID = Convert.ToInt32(item["VEHICLETYPEID"]),
                SERVICETYPE = Convert.ToString(item["SERVICETYPE"]),
                APPROVEDAMOUNT = Convert.ToDecimal(item["APPROVEDAMOUNT"]),
                ACTIVE = Convert.ToString(item["ACTIVE"]),
                FROMLOCATIONNAME = Convert.ToString(item["FROMLOCATIONNAME"]),
                TOLOCATIONNAME = Convert.ToString(item["TOLOCATIONNAME"]),
                RFPVOLUME = Convert.ToDecimal(item["RFPVOLUME"]),
                RFPDURATION = Convert.ToDecimal(item["RFPDURATION"]),
                LOADINGUNLOADINGTIME = Convert.ToDecimal(item["LOADINGUNLOADINGTIME"]),
                BACKHAUL = Convert.ToInt32(item["BACKHAUL"]),
                DISTANCE = Convert.ToInt32(item["DISTANCE"]),
                VEHICLETYPENAME = Convert.ToString(item["VEHICLETYPENAME"]),
                PACKAGETYPEID = Convert.ToInt32(item["PACKAGETYPEID"]),
                PACKDIMENSION = Convert.ToString(item["PACKDIMENSION"]),
                STACKINGNORMS = Convert.ToString(item["STACKINGNORMS"]),
                CUSTTARGETRATE = Convert.ToString(item["CUSTTARGETRATE"]),
                ISLOADUNLOADCHARG = Convert.ToString(item["ISLOADUNLOADCHARG"]),
                AVERAGELOAD = Convert.ToString(item["AVERAGELOAD"]),
                FREQUENCY = Convert.ToString(item["FREQUENCY"]),
                MHEREQUIREMENT = Convert.ToString(item["MHEREQUIREMENT"]),
                OTHERREQUIREMENT = Convert.ToString(item["OTHERREQUIREMENT"]),
                NOOFTRIPS = Convert.ToInt32(item["NOOFTRIPS"]),
                ISROUNDTRIP = Convert.ToString(item["ISROUNDTRIP"]),
                FROMSTATE = Convert.ToString(item["FROMSTATE"]),
                TOSTATE = Convert.ToString(item["TOSTATE"]),
                FROMSTATEID = Convert.ToInt32(item["FROMSTATEID"]),
                TOSTATEID = Convert.ToInt32(item["TOSTATEID"]),
                PACKAGETYPENAME = Convert.ToString(item["PACKAGETYPENAME"]),
            });
        }
        return returnObj.ToArray();
    }

    public RFPDetailResponse[] getrfproutebycustomerid(string rfpid)
    {
        List<RFPDetailResponse> returnObj = new List<RFPDetailResponse>();

        BLRFPDetail oBLRFPDetail = new BLRFPDetail();
        DataSet ds = oBLRFPDetail.GetRFPDetailsBYID(Convert.ToInt32(rfpid), "BYCUSTOMERID");
        //============

        foreach (DataRow item in ds.Tables[0].Rows)
        {
            returnObj.Add(new RFPDetailResponse()
            {
                RFPID = Convert.ToInt32(item["RFPID"]),
                FROMLOCATION = Convert.ToInt32(item["FROMLOCATION"]),
                TOLOCATION = Convert.ToInt32(item["TOLOCATION"]),
                VEHICLETYPEID = Convert.ToInt32(item["VEHICLETYPEID"]),
                SERVICETYPE = Convert.ToString(item["SERVICETYPE"]),
                APPROVEDAMOUNT = Convert.ToDecimal(item["APPROVEDAMOUNT"]),
                ACTIVE = Convert.ToString(item["ACTIVE"]),
                FROMLOCATIONNAME = Convert.ToString(item["FROMLOCATIONNAME"]),
                TOLOCATIONNAME = Convert.ToString(item["TOLOCATIONNAME"]),
                RFPVOLUME = Convert.ToDecimal(item["RFPVOLUME"]),
                RFPDURATION = Convert.ToDecimal(item["RFPDURATION"]),
                LOADINGUNLOADINGTIME = Convert.ToDecimal(item["LOADINGUNLOADINGTIME"]),
                BACKHAUL = Convert.ToInt32(item["BACKHAUL"]),
                DISTANCE = Convert.ToInt32(item["DISTANCE"]),
                VEHICLETYPENAME = Convert.ToString(item["VEHICLETYPENAME"]),
                PACKAGETYPEID = Convert.ToInt32(item["PACKAGETYPEID"]),
                PACKDIMENSION = Convert.ToString(item["PACKDIMENSION"]),
                STACKINGNORMS = Convert.ToString(item["STACKINGNORMS"]),
                CUSTTARGETRATE = Convert.ToString(item["CUSTTARGETRATE"]),
                ISLOADUNLOADCHARG = Convert.ToString(item["ISLOADUNLOADCHARG"]),
                AVERAGELOAD = Convert.ToString(item["AVERAGELOAD"]),
                FREQUENCY = Convert.ToString(item["FREQUENCY"]),
                MHEREQUIREMENT = Convert.ToString(item["MHEREQUIREMENT"]),
                OTHERREQUIREMENT = Convert.ToString(item["OTHERREQUIREMENT"]),
                NOOFTRIPS = Convert.ToInt32(item["NOOFTRIPS"]),
                ISROUNDTRIP = Convert.ToString(item["ISROUNDTRIP"]),
                FROMSTATE = Convert.ToString(item["FROMSTATE"]),
                TOSTATE = Convert.ToString(item["TOSTATE"]),
                FROMSTATEID = Convert.ToInt32(item["FROMSTATEID"]),
                TOSTATEID = Convert.ToInt32(item["TOSTATEID"]),
                PACKAGETYPENAME = Convert.ToString(item["PACKAGETYPENAME"]),
            });
        }
        return returnObj.ToArray();
    }
    #endregion

    #region MANAGERFPTRANSACTION

    //public string ManageTransaction(int _RFPID, int _FROMLOCATION, int _TOLOCATION, int _VEHICLETYPEID, string _SERVICETYPE, decimal _CLEANSHEETRATE, decimal _CONTRACTRATE, decimal _SHIPXRATE, decimal _PVSRFPRATE, decimal _MARKETRATE, decimal _BAQUOTE, string _BACKHAULAVL, decimal _BACKHAULPERCENT, decimal _APPROVEDAMOUNT,
    //       string _ACTIVE, int _CREATEDBY, string _CREATEDON, string _MODE)
    //{

    //    using (BLManageRFPTransaction objbl = new BLManageRFPTransaction())
    //    {
    //        objbl._RFPID = Convert.ToInt32(_RFPID);
    //        objbl._FROMLOCATION = Convert.ToInt32(_FROMLOCATION);
    //        objbl._TOLOCATION = Convert.ToInt32(_TOLOCATION);
    //        objbl._VEHICLETYPEID = Convert.ToInt32(_VEHICLETYPEID);
    //        objbl._SERVICETYPE = _SERVICETYPE;
    //        objbl._CLEANSHEETRATE = Convert.ToDecimal(_CLEANSHEETRATE);
    //        objbl._CONTRACTRATE = Convert.ToDecimal(_CONTRACTRATE);
    //        objbl._SHIPXRATE = Convert.ToDecimal(_SHIPXRATE);
    //        objbl._PVSRFPRATE = Convert.ToDecimal(_PVSRFPRATE);
    //        objbl._MARKETRATE = Convert.ToDecimal(_MARKETRATE);
    //        objbl._BAQUOTE = Convert.ToDecimal(_BAQUOTE);
    //        objbl._BACKHAULAVL = _BACKHAULAVL;
    //        objbl._BACKHAULPERCENT = Convert.ToDecimal(_BACKHAULPERCENT);
    //        objbl._APPROVEDAMOUNT = Convert.ToDecimal(_APPROVEDAMOUNT);
    //        objbl._ACTIVE = _ACTIVE;
    //        objbl._CREATEDBY = Convert.ToInt32(_CREATEDBY);
    //        objbl._CREATEDON = _CREATEDON;
    //        objbl._MODE = _MODE;
    //        //==================
    //        return objbl.ManageTransaction();
    //        //==================
    //    }
    //}

    //public GetManageTransaction[] GetManageTransaction(int _RFPID, int _FROMLOCATION, int _TOLOCATION, int _VEHICLETYPEID, string _SERVICETYPE, decimal _CLEANSHEETRATE, decimal _CONTRACTRATE, decimal _SHIPXRATE, decimal _PVSRFPRATE, decimal _MARKETRATE, decimal _BAQUOTE, string _BACKHAULAVL, decimal _BACKHAULPERCENT, decimal _APPROVEDAMOUNT,
    //       string _ACTIVE, int _CREATEDBY, string _CREATEDON, string _MODE)
    //{
    //    List<GetManageTransaction> returnObj = new List<GetManageTransaction>();

    //    using (BLManageRFPTransaction obj = new BLManageRFPTransaction())
    //    {
    //        //============
    //        obj._RFPID = _RFPID;
    //        obj._FROMLOCATION = _FROMLOCATION;
    //        obj._TOLOCATION = _TOLOCATION;
    //        obj._VEHICLETYPEID = _VEHICLETYPEID;
    //        obj._SERVICETYPE = _SERVICETYPE;
    //        obj._CLEANSHEETRATE = _CLEANSHEETRATE;
    //        obj._CONTRACTRATE = _CONTRACTRATE;
    //        obj._SHIPXRATE = _SHIPXRATE;
    //        obj._PVSRFPRATE = _PVSRFPRATE;
    //        obj._MARKETRATE = _MARKETRATE;
    //        obj._BAQUOTE = _BAQUOTE;
    //        obj._BACKHAULAVL = _BACKHAULAVL;
    //        obj._BACKHAULPERCENT = _BACKHAULPERCENT;
    //        obj._APPROVEDAMOUNT = _APPROVEDAMOUNT;
    //        obj._ACTIVE = _ACTIVE;
    //        obj._MODE = _MODE;

    //        //============
    //        DataSet ds = obj.GetManageTransaction();
    //        //============
    //        foreach (DataRow item in ds.Tables[0].Rows)
    //        {
    //            returnObj.Add(new GetManageTransaction()
    //            {
    //                RFPID = Convert.ToInt32(item["RFPID"]),
    //                FROMLOCATION = Convert.ToInt32(item["FROMLOCATION"]),
    //                TOLOCATION = Convert.ToInt32(item["TOLOCATION"]),
    //                VEHICLETYPEID = Convert.ToInt32(item["VEHICLETYPEID"]),
    //                SERVICETYPE = Convert.ToString(item["SERVICETYPE"]),
    //                CLEANSHEETRATE = Convert.ToDecimal(item["CLEANSHEETRATE"]),
    //                CONTRACTRATE = Convert.ToDecimal(item["CONTRACTRATE"]),
    //                SHIPXRATE = Convert.ToDecimal(item["SHIPXRATE"]),
    //                PVSRFPRATE = Convert.ToDecimal(item["PVSRFPRATE"]),
    //                MARKETRATE = Convert.ToDecimal(item["MARKETRATE"]),
    //                BAQUOTE = Convert.ToDecimal(item["BAQUOTE"]),
    //                BACKHAULAVL = Convert.ToString(item["BACKHAULAVL"]),
    //                BACKHAULPERCENT = Convert.ToDecimal(item["BACKHAULPERCENT"]),
    //                APPROVEDAMOUNT = Convert.ToDecimal(item["APPROVEDAMOUNT"]),
    //                ACTIVE = Convert.ToString(item["ACTIVE"]),
    //            });
    //        }
    //    }
    //    return returnObj.ToArray();
    //}

    public string getpreviousrfprate(string rfpid, string fromcity, string fromstate, string tocity, string tostate, string vehtype)
    {
        string ds = string.Empty;
        using (BLManageRFPTransaction obj = new BLManageRFPTransaction())
        {
            ds = obj.GetPreviousRFPRate(Convert.ToInt32(rfpid), Convert.ToInt32(fromcity), Convert.ToInt32(fromstate), Convert.ToInt32(tocity), Convert.ToInt32(tostate), Convert.ToInt32(vehtype));
        }
        return ds;
    }

    public string apptrans(RFPApproval apptrans)
    {
        string ds = string.Empty;
        using (BLManageRFPTransaction obj = new BLManageRFPTransaction())
        {
            ds = obj.UpdateApproveTransaction(apptrans);
        }
        return ds;
    }

    public RFPTransaction[] gettrans(string rfpid)
    {
        List<RFPTransaction> returnObj = new List<RFPTransaction>();

        BLManageRFPTransaction oBLRFPDetail = new BLManageRFPTransaction();
        DataSet ds = oBLRFPDetail.GetManageTransactionBYRFPID(Convert.ToInt32(rfpid));
        //============

        foreach (DataRow item in ds.Tables[0].Rows)
        {
            returnObj.Add(new RFPTransaction()
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
                BACKHAULPERCENT = Convert.ToDecimal(item["BACKHAULPERCENT"]),
                BACKHAULAVL = Convert.ToString(item["BACKHAULAVL"]),
                APPROVEDAMOUNT = Convert.ToDecimal(item["APPROVEDAMOUNT"]),
                ACTIVE = Convert.ToString(item["ACTIVE"]),
                FROMLOCATIONNAME = Convert.ToString(item["FROMLOCATIONNAME"]),
                TOLOCATIONNAME = Convert.ToString(item["TOLOCATIONNAME"]),
                BANAME = Convert.ToString(item["BANAME"]),
                VEHICLETYPENAME = Convert.ToString(item["VEHICLETYPENAME"]),
                FROMSTATE = Convert.ToString(item["FROMSTATE"]),
                TOSTATE = Convert.ToString(item["TOSTATE"]),
                FROMSTATEID = Convert.ToInt32(item["FROMSTATEID"]),
                TOSTATEID = Convert.ToInt32(item["TOSTATEID"]),
                CUSTOMERNAME = Convert.ToString(item["CUSTOMERNAME"]),
                ADDRESS = Convert.ToString(item["ADDRESS"]),
                CONTACTNO = Convert.ToString(item["CONTACTNO"]),
                CONTACTPERSON = Convert.ToString(item["CONTACTPERSON"]),
                TOTALSPEND = Convert.ToDecimal(item["TOTALSPEND"]),
                CASHACCOUNTID = Convert.ToString(item["CASHACCOUNTID"]),
            });
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
            objbl._CREATEDON = _CREATEDON.ToString("yyyy-MM-dd HH:mm:ss");
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
            obj._CREATEDON = _CREATEDON.ToString("yyyy-MM-dd HH:mm:ss");
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
            objbl._CREATEDON = Convert.ToDateTime(_CREATEDON).ToString("yyyy-MM-dd HH:mm:ss");
            objbl._MODE = _MODE;
            //==================
            return objbl.ManageVehicletypes();
            //==================
        }
    }

    public string vehicletype(VehicleType vehtype)
    {
        if (vehtype == null)
        {
            return "NO DATA";
        }
        else
        {
            using (BLVehicletype objbl = new BLVehicletype())
            {
                objbl._VEHICLETYPEID = vehtype.VEHICLETYPEID;
                objbl._VEHICLETYPECODE = vehtype.VEHICLETYPECODE;
                objbl._VEHICLETYPENAME = vehtype.VEHICLETYPENAME;
                objbl._ACTIVE = vehtype.ACTIVE;
                objbl._CREATEDBY = vehtype.CREATEDBY;
                objbl._CREATEDON = vehtype.CREATEDON;
                objbl._MODE = vehtype.MODE;
                //==================
                return objbl.ManageVehicletypes();
                //==================
            }
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
            obj._CREATEDON = _CREATEDON.ToString("yyyy-MM-dd HH:mm:ss");
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

    public GetVehicletype[] vehicletypes(string all)
    {
        List<GetVehicletype> returnObj = new List<GetVehicletype>();

        Int32 _vehicletypeid = 0;
        string _mode = "GETALL";

        if (all != "0")
        {
            _mode = "BYVEHICLETYPEID";
            _vehicletypeid = Convert.ToInt32(all);
        }

        using (BLVehicletype obj = new BLVehicletype())
        {
            //============
            obj._VEHICLETYPEID = _vehicletypeid;
            obj._VEHICLETYPECODE = "";
            obj._VEHICLETYPENAME = "";
            obj._ACTIVE = "A";
            obj._CREATEDBY = 1;
            obj._CREATEDON = DateTime.Now.ToString("yyyy-MM-dd");
            obj._MODE = _mode;
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

    #region STATE
    public string ManageState(int _STATEID, string _STATECODE, string _STATENAME, string _ACTIVE, int _CREATEDBY, DateTime _CREATEDON, string _MODE)
    {
        using (BLState objbl = new BLState())
        {
            objbl._STATEID = Convert.ToInt32(_STATEID);
            objbl._STATECODE = Convert.ToString(_STATECODE);
            objbl._STATENAME = _STATENAME;
            objbl._ACTIVE = _ACTIVE;
            objbl._CREATEDBY = Convert.ToInt32(_CREATEDBY);
            objbl._CREATEDON = _CREATEDON.ToString("yyyy-MM-dd HH:mm:ss");
            objbl._MODE = _MODE;
            //==================
            return objbl.ManageStates();
            //==================
        }
    }

    public GetStates[] state(string all)
    {

        Int32 _Stateid = 0;
        string _mode = "GETALL";

        if (all != "0")
        {
            _mode = "BYSTATEID";
            _Stateid = Convert.ToInt32(all);
        }

        List<GetStates> returnObj = new List<GetStates>();

        using (BLState obj = new BLState())
        {
            //============
            obj._STATEID = _Stateid;
            obj._STATECODE = "";
            obj._STATENAME = "";
            obj._ACTIVE = "A";
            obj._CREATEDBY = 1;
            obj._CREATEDON = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            obj._MODE = _mode;
            //============
            DataSet ds = obj.GetStates();
            //============
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    returnObj.Add(new GetStates()
                    {
                        STATEID = Convert.ToInt32(item["STATEID"]),
                        STATECODE = Convert.ToString(item["STATECODE"]),
                        STATENAME = Convert.ToString(item["STATENAME"]),
                        ACTIVE = Convert.ToString(item["ACTIVE"]),
                    });
                }
            }
        }
        return returnObj.ToArray();
    }
    #endregion

    #region "OVERALL API"

    public string apiupdate(string rfpid)
    {
        BLRFPDetail oBLRFPDetail = new BLRFPDetail();

        return oBLRFPDetail.APIUpdate(Convert.ToInt32(rfpid));
    }

    #endregion
}
