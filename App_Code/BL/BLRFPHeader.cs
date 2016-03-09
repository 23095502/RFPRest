using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DVPRWCFService.DataLayer;

namespace DVPRWCFService.BusinessLayer
{
    public class BLRFPHeader : Params, IDisposable
    {
        DLRFPHeader oDLRFPHeader;

        public BLRFPHeader()
        {
            oDLRFPHeader = new DLRFPHeader();
        }

        public string ManageRFPHeaders()
        {
            return oDLRFPHeader.ManageRFPHeaders(this);
        }

        public DataSet GetRFPHeaders()
        {
            return oDLRFPHeader.GetRFPHeaders(this);
        }

        #region IDisposable Members

        public void Dispose()
        {
            oDLRFPHeader = null;
        }

        #endregion
    }
}
