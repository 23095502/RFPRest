using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DVPRWCFService.DataLayer;

namespace DVPRWCFService.BusinessLayer
{
    public class BLRFPDetail : Params, IDisposable
    {
        DLRFPDetail oDLRFPDetail;

        public BLRFPDetail()
        {
            oDLRFPDetail = new DLRFPDetail();
        }

        public string ManageRFPDetails()
        {
            return oDLRFPDetail.ManageRFPDetails(this);
        }

        public DataSet GetRFPDetails()
        {
            return oDLRFPDetail.GetRFPDetails(this);
        }

        #region IDisposable Members

        public void Dispose()
        {
            oDLRFPDetail = null;
        }

        #endregion
    }
}
