using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DVPRWCFService.DataLayer;

namespace DVPRWCFService.BusinessLayer
{
    public class BLData : Params, IDisposable
    {
        DLData oDLData;

        public BLData()
        {
            oDLData = new DLData();
        }

        public DataSet GetAllUsers()
        {
            return oDLData.GetAllUsers(this);
        }

        public string ManageUsers()
        {
            return oDLData.ManageUsers(this);
        }

        public DataSet GetUsers()
        {
            return oDLData.GetUsers(this);
        }

        #region IDisposable Members

        public void Dispose()
        {
            oDLData = null;
        }

        #endregion
    }
}
