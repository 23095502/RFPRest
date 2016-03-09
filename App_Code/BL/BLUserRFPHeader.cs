using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DVPRWCFService.DataLayer;

namespace DVPRWCFService.BusinessLayer
{
    public class BLUserRFPHeader : Params, IDisposable
    {
        DLUserRFPHeader oDLUserRFPHeader;

        public BLUserRFPHeader()
        {
            oDLUserRFPHeader = new DLUserRFPHeader();
        }

        public string ManageRFPHeaders()
        {
            return oDLUserRFPHeader.ManageUserRFPHeaders(this);
        }

        public DataSet GetUserRFPHeaders()
        {
            return oDLUserRFPHeader.GetUserRFPHeaders(this);
        }

        #region IDisposable Members

        public void Dispose()
        {
            oDLUserRFPHeader = null;
        }

        #endregion
    }
}
