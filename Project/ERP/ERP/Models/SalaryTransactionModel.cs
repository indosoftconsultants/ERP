
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class SalaryTransactionModel
    {
        public int Id { get; set; }

        public string TransationDate { get; set; }

        public int EmployeeId { get; set; }

        public int NoOfPayableDays { get; set; }
       
        public int NoOfPresentDays { get; set; }

        public int NoOfLeaveDays { get; set; }

        public string NetSalary { get; set; }//decimal(18,2)

        public float OtInHour { get; set; }

        public string  OtAmount{ get; set; }//decimal(18,2)

        public string TotalAllowance { get; set; }//decimal(18,2)

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
