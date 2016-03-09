using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Data;

namespace DVPRWCFService.BusinessLayer
{
    public class Params
    {
        public int _USERID { get; set; }
        public string _USERCODE { get; set; }
        public string _FIRSTNAME { get; set; }
        public string _LASTNAME { get; set; }
        public string _PASSWORD { get; set; }
        public string _EMAILID { get; set; }
        public string _ACTIVE { get; set; }
        public int _CREATEDBY { get; set; }
        public string _CREATEDON { get; set; }
        public string _MODE { get; set; }

        //CUSTOMERS
        public int _CUSTOMERID { get; set; }
        public string _CUSTOMERCODE { get; set; }
        public string _CUSTOMERNAME { get; set; }
        public string _ADDRESS { get; set; }
        public string _EMAIL { get; set; }
        public string _CONTACTPERSON { get; set; }
        public string _CONTACTNO { get; set; }
        //CUSTOMERS

        //INDUSTRYTYPEID
        public int _INDUSTRYTYPEID { get; set; }
        public string _INDUSTRYTYPECODE { get; set; }
        public string _INDUSTRYTYPENAME { get; set; }
        //INDUSTRYTYPEID

        //LOCATION
        public int _LOCATIONID { get; set; }
        public string _LOCATIONCODE { get; set; }
        public string _LOCATIONNAME { get; set; }
        //LOCATION

        //RFPHEADER
        public int _RFPID { get; set; }
        public string _RFPCODE { get; set; }
        public DateTime _RFPDATE { get; set; }
        public decimal _RFPAMOUNT { get; set; }
        public DateTime _STARTDATE { get; set; }
        public int _RFPOWNER { get; set; }
        public DateTime _CREATEDONDATE { get; set; }
        public int _CURRENTSTAGINGOWNER { get; set; }
        public decimal _DIESELRATE { get; set; }
        public int _AGEOFTRUCK { get; set; }
        public string _SEARCH1 { get; set; }
        public string _SEARCH2 { get; set; }
        public string _SEARCH3 { get; set; }
        //RFPHEADER

        //RFPDETAIL
        public int _FROMLOCATION { get; set; }
        public int _TOLOCATION { get; set; }
        public int _VEHICLETYPEID { get; set; }
        public decimal _APPROVEDAMOUNT { get; set; }
        public string _SERVICETYPE { get; set; }
        public decimal _RFPVOLUME { get; set; }
        public decimal _RFPDURATION { get; set; }
        //RFPDETAIL

        //USERRFPHEADER
        public int _TRANID { get; set; }
        public DateTime _RECENTDATE { get; set; }
        public int _CURRENTSTAGINGOWNERVALUE { get; set; }
        //USERRFPHEADER

        //VEHICLETYPE
        public string _VEHICLETYPECODE { get; set; }
        public string _VEHICLETYPENAME { get; set; }
        //VEHICLETYPE

        //ManageTransactionRFT
        /*
        public int _RFPID { get; set; }
        public int _FROMLOCATION { get; set; }
        public int _TOLOCATION { get; set; }
        public int _VEHICLETYPEID { get; set; }
        public string _SERVICETYPE { get; set; }
        public decimal _APPROVEDAMOUNT { get; set; }
        */
        public decimal _CLEANSHEETRATE { get; set; }
        public decimal _CONTRACTRATE { get; set; }
        public decimal _SHIPXRATE { get; set; }
        public decimal _PVSRFPRATE { get; set; }
        public decimal _MARKETRATE { get; set; }
        public decimal _BAQUOTE { get; set; }
        public string _BACKHAULAVL { get; set; }
        public decimal _BACKHAULPERCENT { get; set; }
        
        //ManageTransactionRFT
    }
}
