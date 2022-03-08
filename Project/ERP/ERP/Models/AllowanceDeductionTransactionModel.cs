using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class AllowanceDeductionTransactionModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Transation Date")]
        public string TransactionDate { get; set; }

        [Display(Name ="Employee Id")]
        public int EmployeeId { get; set; }

        public int AllowanceDeductionMasterId { get; set; }

        public int AllowanceDeductionAmount { get; set; }

        public int PayableAmount { get; set; }

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
