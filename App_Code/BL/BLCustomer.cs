using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DVPRWCFService.DataLayer;

namespace DVPRWCFService.BusinessLayer
{
    public class BLCustomer : Params, IDisposable
    {
        DLCustomer oDLCustomer;

        public BLCustomer()
        {
            oDLCustomer = new DLCustomer();
        }

        public string ManageCustomer()
        {
            return oDLCustomer.ManageCustomer(this);
        }

        public DataSet GetCustomers()
        {
            return oDLCustomer.GetCustomers(this);
        }

        #region IDisposable Members

        public void Dispose()
        {
            oDLCustomer = null;
        }

        #endregion
    }
}
