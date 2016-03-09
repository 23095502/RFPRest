using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DVPRWCFService.DataLayer;

namespace DVPRWCFService.BusinessLayer
{
    public class BLIndustryType : Params, IDisposable
    {
        DLIndustryType oDLIndustryType;

        public BLIndustryType()
        {
            oDLIndustryType = new DLIndustryType();
        }

        public string ManageIndustryTypes()
        {
            return oDLIndustryType.ManageIndustryTypes(this);
        }

        public DataSet GetIndustryTypes()
        {
            return oDLIndustryType.GetIndustryTypes(this);
        }

        #region IDisposable Members

        public void Dispose()
        {
            oDLIndustryType = null;
        }

        #endregion
    }
}
