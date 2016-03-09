using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DVPRWCFService.DataLayer;

namespace DVPRWCFService.BusinessLayer
{
    public class BLVehicletype : Params, IDisposable
    {
        DLVehicletype oDLVehicletype;

        public BLVehicletype()
        {
            oDLVehicletype = new DLVehicletype();
        }

        public string ManageVehicletypes()
        {
            return oDLVehicletype.ManageVehicletypes(this);
        }

        public DataSet GetVehicletypes()
        {
            return oDLVehicletype.GetVehicletypes(this);
        }

        #region IDisposable Members

        public void Dispose()
        {
            oDLVehicletype = null;
        }

        #endregion
    }
}
