using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class ApproveLeaveTransactionModel
    {
        public int Id { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        [Display(Name = "Employee Id")]
        public int EmployeeId { get; set; }

        public int LeaveMasterId { get; set; }

        public int NoOfLeaves { get; set; }

        public int UsedLeaves { get; set; }

        public int RemainingLeaves { get; set; }

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
