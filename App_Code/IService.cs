using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using System.Security.Cryptography;


// NOTE: If you change the interface name "IService" here, you must also update the reference to "IService" in Web.config.
[ServiceContract]
public interface IService
{

    [OperationContract]
    string GetData(int value);

    [OperationContract]
    CompositeType GetDataUsingDataContract(CompositeType composite);

    #region USERS
    [OperationContract]
    [WebInvoke(RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ManageUsers?userid={_userid}&usercode={_usercode}&firstname={_firstname}&lastname={_lastname}&password={_password}&emailid={_emailid}&active={_active}&createdby={_createdby}&createdon={_createdon}&mode={_mode}",
        Method = "GET")]
    string ManageUsers(int _USERID, string _USERCODE, string _FIRSTNAME, string _LASTNAME, string _PASSWORD, string _EMAILID,
            string _ACTIVE, int _CREATEDBY, string _CREATEDON, string _MODE);

    [OperationContract]
    [WebInvoke(RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "GetUsers?userid={_userid}&usercode={_usercode}&firstname={_firstname}&lastname={_lastname}&password={_password}&emailid={_emailid}&active={_active}&createdby={_createdby}&createdon={_createdon}&mode={_mode}",
        Method = "GET")]
    GetUser[] GetUsers(int _USERID, string _USERCODE, string _FIRSTNAME, string _LASTNAME, string _PASSWORD, string _EMAILID,
            string _ACTIVE, int _CREATEDBY, string _CREATEDON, string _MODE);
    #endregion

    #region CUSTOMERS
    [OperationContract]
    [WebInvoke(RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ManageCustomer?customerid={_customerid}&customercode={_customercode}&customername={_customername}&address={_address}&email={_email}&contactperson={_contactperson}&contactno={_contactno}&active={_active}&createdby={_createdby}&createdon={_createdon}&mode={_mode}",
        Method = "GET")]
    string ManageCustomer(int _CUSTOMERID, string _CUSTOMERCODE, string _CUSTOMERNAME, string _ADDRESS, string _EMAIL, string _CONTACTPERSON, string _CONTACTNO,
            string _ACTIVE, int _CREATEDBY, string _CREATEDON, string _MODE);

    [OperationContract]
    [WebInvoke(RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "GetCustomers?customerid={_customerid}&customercode={_customercode}&customername={_customername}&address={_address}&email={_email}&contactperson={_contactperson}&contactno={_contactno}&active={_active}&createdby={_createdby}&createdon={_createdon}&mode={_mode}",
        Method = "GET")]
    GetCustomer[] GetCustomers(int _CUSTOMERID, string _CUSTOMERCODE, string _CUSTOMERNAME, string _ADDRESS, string _EMAIL, string _CONTACTPERSON, string _CONTACTNO,
            string _ACTIVE, int _CREATEDBY, string _CREATEDON, string _MODE);
    #endregion

    #region INDUSTRYTYPE
    [OperationContract]
    [WebInvoke(RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ManageIndustrytype?industrytypeid={_industrytypeid}&industrytypecode={_industrytypecode}&industrytypename={_industrytypename}&active={_active}&createdby={_createdby}&createdon={_createdon}&mode={_mode}",
        Method = "GET")]
    string ManageIndustrytype(int _INDUSTRYTYPEID, string _INDUSTRYTYPECODE, string _INDUSTRYTYPENAME,
            string _ACTIVE, int _CREATEDBY, string _CREATEDON, string _MODE);

    [OperationContract]
    [WebInvoke(RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "GetIndustryTypes?industrytypeid={_industrytypeid}&industrytypecode={_industrytypecode}&industrytypename={_industrytypename}&active={_active}&createdby={_createdby}&createdon={_createdon}&mode={_mode}",
        Method = "GET")]
    GetIndustryType[] GetIndustryTypes(int _INDUSTRYTYPEID, string _INDUSTRYTYPECODE, string _INDUSTRYTYPENAME,
            string _ACTIVE, int _CREATEDBY, string _CREATEDON, string _MODE);
    #endregion

    #region LOCATIONS
    [OperationContract]
    [WebInvoke(RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ManageLocations?locationid={_locationid}&locationcode={_locationcode}&locationname={_locationname}&active={_active}&createdby={_createdby}&createdon={_createdon}&mode={_mode}",
        Method = "GET")]
    string ManageLocations(int _LOCATIONID, string _LOCATIONCODE, string _LOCATIONNAME,
            string _ACTIVE, int _CREATEDBY, string _CREATEDON, string _MODE);

    [OperationContract]
    [WebInvoke(RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "GetLocations?locationid={_locationid}&locationcode={_locationcode}&locationname={_locationname}&active={_active}&createdby={_createdby}&createdon={_createdon}&mode={_mode}",
        Method = "GET")]
    GetLocation[] GetLocations(int _LOCATIONID, string _LOCATIONCODE, string _LOCATIONNAME,
            string _ACTIVE, int _CREATEDBY, string _CREATEDON, string _MODE);
    #endregion

    #region RFPHEADERS
    [OperationContract]
    [WebInvoke(RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ManageRFPHeaders?rfpid={_rfpid}&rfpcode={_rfpcode}&rfpdate={_rfpdate}&customerid={_customerid}&industrytypeid={_industrytypeid}&rfpamount={_rfpamount}&startdate={_startdate}&rfpowner={_rfpowner}&currentstagingowner={_currentstagingowner}&dieselrate={_dieselrate}&ageoftruck={_ageoftruck}&active={_active}&createdby={_createdby}&createdon={_createdon}&search1={_search1}&search2={_search2}&search3={_search3}&mode={_mode}",
        Method = "GET")]
    string ManageRFPHeaders(int _RFPID, string _RFPCODE, DateTime _RFPDATE, int _CUSTOMERID, int _INDUSTRYTYPEID, decimal _RFPAMOUNT,
            DateTime _STARTDATE, int _RFPOWNER, int _CURRENTSTAGINGOWNER, decimal _DIESELRATE, int _AGEOFTRUCK,
            string _ACTIVE, int _CREATEDBY, DateTime _CREATEDON, string _SEARCH1, string _SEARCH2, string _SEARCH3, string _MODE);

    [OperationContract]
    [WebInvoke(RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "GetRFPHeaders?rfpid={_rfpid}&rfpcode={_rfpcode}&rfpdate={_rfpdate}&customerid={_customerid}&industrytypeid={_industrytypeid}&rfpamount={_rfpamount}&startdate={_startdate}&rfpowner={_rfpowner}&currentstagingowner={_currentstagingowner}&dieselrate={_dieselrate}&ageoftruck={_ageoftruck}&active={_active}&createdby={_createdby}&createdon={_createdon}&search1={_search1}&search2={_search2}&search3={_search3}&mode={_mode}",
        Method = "GET")]
    GetRFPHeader[] GetRFPHeaders(int _RFPID, string _RFPCODE, DateTime _RFPDATE, int _CUSTOMERID, int _INDUSTRYTYPEID, decimal _RFPAMOUNT,
            DateTime _STARTDATE, int _RFPOWNER, int _CURRENTSTAGINGOWNER, decimal _DIESELRATE, int _AGEOFTRUCK,
            string _ACTIVE, int _CREATEDBY, DateTime _CREATEDON, string _SEARCH1, string _SEARCH2, string _SEARCH3, string _MODE);
    #endregion

    #region RFPDETAILS
    [OperationContract]
    [WebInvoke(RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ManageRFPDetails?rfpid={_rfpid}&fromlocation={_fromlocation}&tolocation={_tolocation}&vehicletypeid={_vehicletypeid}&approvedamount={_approvedamount}&servicetype={_servicetype}&rfpvolume={_rfpvolume}&rfpduration={_rfpduration}&active={_active}&createdby={_createdby}&createdon={_createdon}&search1={_search1}&search2={_search2}&search3={_search3}&mode={_mode}",
        Method = "GET")]
    string ManageRFPDetails(int _RFPID, int _FROMLOCATION, int _TOLOCATION, int _VEHICLETYPEID, decimal _APPROVEDAMOUNT, string _SERVICETYPE,
            decimal _RFPVOLUME, decimal _RFPDURATION,
            string _ACTIVE, int _CREATEDBY, DateTime _CREATEDON, string _SEARCH1, string _SEARCH2, string _SEARCH3, string _MODE);

    [OperationContract]
    [WebInvoke(RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "GetRFPDetails?rfpid={_rfpid}&fromlocation={_fromlocation}&tolocation={_tolocation}&vehicletypeid={_vehicletypeid}&approvedamount={_approvedamount}&servicetype={_servicetype}&rfpvolume={_rfpvolume}&rfpduration={_rfpduration}&active={_active}&createdby={_createdby}&createdon={_createdon}&search1={_search1}&search2={_search2}&search3={_search3}&mode={_mode}",
        Method = "GET")]
    GetRFPDetail[] GetRFPDetails(int _RFPID, int _FROMLOCATION, int _TOLOCATION, int _VEHICLETYPEID, decimal _APPROVEDAMOUNT, string _SERVICETYPE,
            decimal _RFPVOLUME, decimal _RFPDURATION,
            string _ACTIVE, int _CREATEDBY, DateTime _CREATEDON, string _SEARCH1, string _SEARCH2, string _SEARCH3, string _MODE);
    #endregion

    #region MANAGERFPTRANSACTION
    [OperationContract]
    [WebInvoke(RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ManageTransaction?RFPID={_RFPID}&FROMLOCATION={_FROMLOCATION}&TOLOCATION={_TOLOCATION}&VEHICLETYPEID={_VEHICLETYPEID}&SERVICETYPE={_SERVICETYPE}&CLEANSHEETRATE={_CLEANSHEETRATE}&CONTRACTRATE={_CONTRACTRATE}&SHIPXRATE={_SHIPXRATE}&PVSRFPRATE={_PVSRFPRATE}&MARKETRATE={_MARKETRATE}&BAQUOTE={_BAQUOTE}&BACKHAULAVL={_BACKHAULAVL}&BACKHAULPERCENT={_BACKHAULPERCENT}&APPROVEDAMOUNT={_APPROVEDAMOUNT}&active={_active}&createdby={_createdby}&createdon={_createdon}&mode={_mode}",
        Method = "GET")]
    string ManageTransaction(int _RFPID, int _FROMLOCATION, int _TOLOCATION, int _VEHICLETYPEID, string _SERVICETYPE, decimal _CLEANSHEETRATE, decimal _CONTRACTRATE, decimal _SHIPXRATE, decimal _PVSRFPRATE, decimal _MARKETRATE,
        decimal _BAQUOTE, string _BACKHAULAVL, decimal _BACKHAULPERCENT, decimal _APPROVEDAMOUNT,
        string _ACTIVE, int _CREATEDBY, string _CREATEDON, string _MODE);

    [OperationContract]
    [WebInvoke(RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "GetManageTransaction?RFPID={_RFPID}&FROMLOCATION={_FROMLOCATION}&TOLOCATION={_TOLOCATION}&VEHICLETYPEID={_VEHICLETYPEID}&SERVICETYPE={_SERVICETYPE}&CLEANSHEETRATE={_CLEANSHEETRATE}&CONTRACTRATE={_CONTRACTRATE}&SHIPXRATE={_SHIPXRATE}&PVSRFPRATE={_PVSRFPRATE}&MARKETRATE={_MARKETRATE}&BAQUOTE={_BAQUOTE}&BACKHAULAVL={_BACKHAULAVL}&BACKHAULPERCENT={_BACKHAULPERCENT}&APPROVEDAMOUNT={_APPROVEDAMOUNT}&active={_active}&createdby={_createdby}&createdon={_createdon}&mode={_mode}",
        Method = "GET")]
    GetManageTransaction[] GetManageTransaction(int _RFPID, int _FROMLOCATION, int _TOLOCATION, int _VEHICLETYPEID, string _SERVICETYPE, decimal _CLEANSHEETRATE, decimal _CONTRACTRATE, decimal _SHIPXRATE, decimal _PVSRFPRATE, decimal _MARKETRATE,
        decimal _BAQUOTE, string _BACKHAULAVL, decimal _BACKHAULPERCENT, decimal _APPROVEDAMOUNT,
        string _ACTIVE, int _CREATEDBY, string _CREATEDON, string _MODE);
    #endregion

    #region USERRFPHEADERS
    [OperationContract]
    [WebInvoke(RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ManageUserRFPHeaders?RFPID={_RFPID}&USERID={_USERID}&CURRENTSTAGINGOWNER={_CURRENTSTAGINGOWNER}&RECENTDATE={_RECENTDATE}&ACTIVE={_ACTIVE}&CREATEDBY={_CREATEDBY}&CREATEDON={_CREATEDON}&MODE={_MODE}",
        Method = "GET")]
    string ManageUserRFPHeaders(int _RFPID, int _USERID, int _CURRENTSTAGINGOWNER, DateTime _RECENTDATE, string _ACTIVE, int _CREATEDBY, DateTime _CREATEDON, string _MODE);

    [OperationContract]
    [WebInvoke(RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "GetUserRFPHeaders?RFPID={_RFPID}&USERID={_USERID}&CURRENTSTAGINGOWNER={_CURRENTSTAGINGOWNER}&RECENTDATE={_RECENTDATE}&ACTIVE={_ACTIVE}&CREATEDBY={_CREATEDBY}&CREATEDON={_CREATEDON}&MODE={_MODE}",
        Method = "GET")]
    GetUserRFPHeader[] GetUserRFPHeaders(int _RFPID, int _USERID, int _CURRENTSTAGINGOWNER, DateTime _RECENTDATE, string _ACTIVE, int _CREATEDBY, DateTime _CREATEDON, string _MODE);
    #endregion

    #region VEHICLETYPES
    [OperationContract]
    [WebInvoke(RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "ManageVehicletypes?VEHICLETYPEID={_VEHICLETYPEID}&VEHICLETYPECODE={_VEHICLETYPECODE}&VEHICLETYPENAME={_VEHICLETYPENAME}&ACTIVE={_ACTIVE}&CREATEDBY={_CREATEDBY}&CREATEDON={_CREATEDON}&MODE={_MODE}",
        Method = "GET")]
    string ManageVehicletypes(int _VEHICLETYPEID, string _VEHICLETYPECODE, string _VEHICLETYPENAME, string _ACTIVE, int _CREATEDBY, DateTime _CREATEDON, string _MODE);

    [OperationContract]
    [WebInvoke(RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "GetVehicletypes?VEHICLETYPEID={_VEHICLETYPEID}&VEHICLETYPECODE={_VEHICLETYPECODE}&VEHICLETYPENAME={_VEHICLETYPENAME}&ACTIVE={_ACTIVE}&CREATEDBY={_CREATEDBY}&CREATEDON={_CREATEDON}&MODE={_MODE}",
        Method = "GET")]
    GetVehicletype[] GetVehicletypes(int _VEHICLETYPEID, string _VEHICLETYPECODE, string _VEHICLETYPENAME, string _ACTIVE, int _CREATEDBY, DateTime _CREATEDON, string _MODE);
    #endregion
}

// Use a data contract as illustrated in the sample below to add composite types to service operations.
[DataContract]
public class CompositeType
{
    bool boolValue = true;
    string stringValue = "Hello ";

    [DataMember]
    public bool BoolValue
    {
        get { return boolValue; }
        set { boolValue = value; }
    }

    [DataMember]
    public string StringValue
    {
        get { return stringValue; }
        set { stringValue = value; }
    }
}

[DataContract(Name = "GetUser", Namespace = "")]
public class GetUser
{
    [DataMember]
    public int USERID { get; set; }
    [DataMember]
    public string USERCODE { get; set; }
    [DataMember]
    public string FIRSTNAME { get; set; }
    [DataMember]
    public string LASTNAME { get; set; }
    [DataMember]
    public string DISPLAYNAME { get; set; }
    [DataMember]
    public string PASSWORD { get; set; }
    [DataMember]
    public string EMAILID { get; set; }
    [DataMember]
    public string ACTIVE { get; set; }
}

[DataContract(Name = "GetCustomer", Namespace = "")]
public class GetCustomer
{

    [DataMember]
    public int CUSTOMERID { get; set; }
    [DataMember]
    public string CUSTOMERCODE { get; set; }
    [DataMember]
    public string CUSTOMERNAME { get; set; }
    [DataMember]
    public string ADDRESS { get; set; }
    [DataMember]
    public string CONTACTPERSON { get; set; }
    [DataMember]
    public string CONTACTNO { get; set; }
    [DataMember]
    public string EMAIL { get; set; }
    [DataMember]
    public string ACTIVE { get; set; }
}

[DataContract(Name = "GetIndustryType", Namespace = "")]
public class GetIndustryType
{
    [DataMember]
    public int INDUSTRYTYPEID { get; set; }
    [DataMember]
    public string INDUSTRYTYPECODE { get; set; }
    [DataMember]
    public string INDUSTRYTYPENAME { get; set; }
    [DataMember]
    public string ACTIVE { get; set; }
}

[DataContract(Name = "GetLocation", Namespace = "")]
public class GetLocation
{
    [DataMember]
    public int LOCATIONID { get; set; }
    [DataMember]
    public string LOCATIONCODE { get; set; }
    [DataMember]
    public string LOCATIONNAME { get; set; }
    [DataMember]
    public string ACTIVE { get; set; }
}

[DataContract(Name = "GetRFPHeader", Namespace = "")]
public class GetRFPHeader
{

    [DataMember]
    public int RFPID { get; set; }
    [DataMember]
    public string RFPCODE { get; set; }
    [DataMember]
    public DateTime RFPDATE { get; set; }
    [DataMember]
    public int CUSTOMERID { get; set; }
    [DataMember]
    public int INDUSTRYTYPEID { get; set; }

    [DataMember]
    public decimal RFPAMOUNT { get; set; }
    [DataMember]
    public DateTime STARTDATE { get; set; }
    [DataMember]
    public int RFPOWNER { get; set; }
    [DataMember]
    public int CURRENTSTAGINGOWNER { get; set; }
    [DataMember]
    public string ACTIVE { get; set; }

    [DataMember]
    public string CUSTOMERNAME { get; set; }
    [DataMember]
    public string INDUSTRYTYPENAME { get; set; }
    [DataMember]
    public string OWNERNAME { get; set; }
    [DataMember]
    public string CURRENTOWNERNAME { get; set; }

}

[DataContract(Name = "GetRFPDetail", Namespace = "")]
public class GetRFPDetail
{

    [DataMember]
    public int RFPID { get; set; }
    [DataMember]
    public int FROMLOCATION { get; set; }
    [DataMember]
    public int TOLOCATION { get; set; }
    [DataMember]
    public int VEHICLETYPEID { get; set; }
    [DataMember]
    public string SERVICETYPE { get; set; }
    [DataMember]
    public decimal APPROVEDAMOUNT { get; set; }
    [DataMember]
    public string ACTIVE { get; set; }
    [DataMember]
    public string LOCATIONNAME { get; set; }
    [DataMember]
    public string FROMLOCATIONNAME { get; set; }
    [DataMember]
    public string TOLOCATIONNAME { get; set; }
    [DataMember]
    public decimal RFPVOLUME { get; set; }
    [DataMember]
    public decimal RFPDURATION { get; set; }
    [DataMember]
    public string VEHICLETYPENAME { get; set; }

}


[DataContract(Name = "GetManageTransaction", Namespace = "")]
public class GetManageTransaction
{
    [DataMember]
    public int RFPID { get; set; }
    [DataMember]
    public int FROMLOCATION { get; set; }
    [DataMember]
    public int TOLOCATION { get; set; }
    [DataMember]
    public int VEHICLETYPEID { get; set; }
    [DataMember]
    public string SERVICETYPE { get; set; }
    [DataMember]
    public decimal CLEANSHEETRATE { get; set; }
    [DataMember]
    public decimal CONTRACTRATE { get; set; }
    [DataMember]
    public decimal SHIPXRATE { get; set; }
    [DataMember]
    public decimal PVSRFPRATE { get; set; }
    [DataMember]
    public decimal MARKETRATE { get; set; }
    [DataMember]
    public decimal BAQUOTE { get; set; }
    [DataMember]
    public string BACKHAULAVL { get; set; }
    [DataMember]
    public decimal BACKHAULPERCENT { get; set; }
    [DataMember]
    public decimal APPROVEDAMOUNT { get; set; }
    [DataMember]
    public string ACTIVE { get; set; }

}

[DataContract(Name = "GetUserRFPHeader", Namespace = "")]
public class GetUserRFPHeader
{
    [DataMember]
    public int USERID { get; set; }
    [DataMember]
    public int _CURRENTSTAGINGOWNER { get; set; }
    [DataMember]
    public DateTime RECENTDATE { get; set; }
    [DataMember]
    public string ACTIVE { get; set; }
    

}

[DataContract(Name = "GetVehicletype", Namespace = "")]
public class GetVehicletype
{
    [DataMember]
    public int VEHICLETYPEID { get; set; }
    [DataMember]
    public string VEHICLETYPECODE { get; set; }
    [DataMember]
    public string VEHICLETYPENAME { get; set; }
    [DataMember]
    public string ACTIVE { get; set; }
 
}