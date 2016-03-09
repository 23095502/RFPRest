using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DVPRWCFService.DataLayer;

namespace DVPRWCFService.BusinessLayer
{
    public class BLManageRFPTransaction : Params, IDisposable
    {
        DLManageRFPTransaction oDLManageRFPTransaction;

        public BLManageRFPTransaction()
        {
            oDLManageRFPTransaction = new DLManageRFPTransaction();
        }

        public string ManageTransaction()
        {
            return oDLManageRFPTransaction.ManageTransaction(this);
        }
        public DataSet GetManageTransaction()
        {
            return oDLManageRFPTransaction.GetManageTransaction(this);
        }

        #region IDisposable Members

        public void Dispose()
        {
            oDLManageRFPTransaction = null;
        }

        #endregion
    }
}