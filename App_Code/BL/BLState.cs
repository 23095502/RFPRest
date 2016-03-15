using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DVPRWCFService.DataLayer;

namespace DVPRWCFService.BusinessLayer
{
    public class BLState : Params, IDisposable
    {
        DLState oDLState;

        public BLState()
        {
            oDLState = new DLState();
        }

        public string ManageStates()
        {
            return oDLState.ManageStates(this);
        }

        public DataSet GetStates()
        {
            return oDLState.GetStates(this);
        }

        #region IDisposable Members

        public void Dispose()
        {
            oDLState = null;
        }

        #endregion
    }
}
