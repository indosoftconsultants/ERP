using CustomerAPI.Models;
using Syncfusion.EJ2.DropDowns;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class Utility:IDisposable
    {
        public static DataTable GetData(string procName)
         {
            try
            {
                var dtvalues = DataLayer.FillDataTable(procName);
                return dtvalues;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
