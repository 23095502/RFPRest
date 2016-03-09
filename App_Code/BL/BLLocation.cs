using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DVPRWCFService.DataLayer;

namespace DVPRWCFService.BusinessLayer
{
    public class BLLocation : Params, IDisposable
    {
        DLLocation oDLLocation;

        public BLLocation()
        {
            oDLLocation = new DLLocation();
        }

        public string ManageLocations()
        {
            return oDLLocation.ManageLocations(this);
        }

        public DataSet GetLocations()
        {
            return oDLLocation.GetLocations(this);
        }

        #region IDisposable Members

        public void Dispose()
        {
            oDLLocation = null;
        }

        #endregion
    }
}
