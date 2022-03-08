using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class DesignationMasterModel
    {
        public int Id { get; set; }

        public string DesignationName { get; set; }

        public string EntryDate { get; set; }

        public string EntryBy { get; set; }

        public string CompanyName { get; set; }

        public string PassedBy { get; set; }

        public string PassCompanyName { get; set; }

        public string LastEditedBy { get; set; }

        public string LastCompanyName { get; set; }

        public string LastEditedDate { get; set; }
    }
}
