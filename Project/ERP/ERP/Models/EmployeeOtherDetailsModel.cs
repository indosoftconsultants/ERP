using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class EmployeeOtherDetailsModel
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public string JoiningDate { get; set; }

        public int Department { get; set; }

        public int Designation { get; set; }

        public bool IsResign { get; set; }

        public string ResignDate { get; set; }

        public int ShiftScheduleId { get; set; }

        public string WeeklyOff { get; set; }

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
