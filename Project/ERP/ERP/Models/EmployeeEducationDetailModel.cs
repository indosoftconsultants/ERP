
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class EmployeeEducationDetailModel
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public int EducationId { get; set; }

        public int CourseName { get; set; }

        public string PassingYear { get; set; }

        public string University { get; set; }

        public string CollegeName { get; set; }

        public string Grade { get; set; }

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
