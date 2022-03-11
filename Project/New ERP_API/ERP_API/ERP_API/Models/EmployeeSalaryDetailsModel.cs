using CustomerAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_API.Models
{
    public class EmployeeSalaryDetailsModel
    {
        public int Id { get; set; }
        public static bool errorMsg { get; set; }
        public int SalaryDetails_EmployeeId { get; set; }
     
        public int SalaryDetails_AllowanceDeductionId { get; set; }
        
        public int SalaryDetails_Amount { get; set; }

        public string EntryDate { get; set; }

        public string EntryBy { get; set; }
        public string CompanyName { get; set; }
        public string PassedBy { get; set; }
        public string PassCompanyName { get; set; }
        public string LastEditedBy { get; set; }
        public string LastCompanyName { get; set; }
        public string LastEditedDate { get; set; }


        public static bool Insert(EmployeeSalaryDetailsModel Add)
        {

            Add.EntryDate = Convert.ToString(DateTime.Today);
            Add.EntryBy = "a";
            Add.CompanyName = "a";
            Add.PassedBy = "a";
            Add.PassCompanyName = "a";
            Add.LastEditedBy = "a";
            Add.LastCompanyName = "a";
            Add.LastEditedDate = Convert.ToString(DateTime.Today);
            try
            {
                Hashtable hash = new Hashtable();
                hash.Add("@Id", Add.Id);
                hash.Add("@EmployeeId",         Add.SalaryDetails_EmployeeId);
                hash.Add("@AllowanceDeductionId", Add.SalaryDetails_AllowanceDeductionId);
                hash.Add("@Amount",              Add.SalaryDetails_Amount);                
                hash.Add("@EntryDate                    ", Add.EntryDate);
                hash.Add("@EntryBy                      ", Add.EntryBy);
                hash.Add("@CompanyName                  ", Add.CompanyName);
                hash.Add("@PassedBy                     ", Add.PassedBy);
                hash.Add("@PassCompanyName              ", Add.PassCompanyName);
                hash.Add("@LastEditedBy                 ", Add.LastEditedBy);
                hash.Add("@LastCompanyName              ", Add.LastCompanyName);
                hash.Add("@LastEditedDate               ", Add.LastEditedDate);

                DataLayer.ExecuteDMLQuery("InsUpd_EmployeeSalaryDetails", hash);
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }

        }
    }
}
