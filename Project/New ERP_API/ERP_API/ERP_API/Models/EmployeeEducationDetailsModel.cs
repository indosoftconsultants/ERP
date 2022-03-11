using CustomerAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_API.Models
{
    public class EmployeeEducationDetailsModel
    {
        public int Id { get; set; }
        public static bool errorMsg { get; set; }
        public int EducationDetails_EmployeeId { get; set; }

        public int EducationDetails_EducationId { get; set; }
      
       
        
        public string EducationDetails_PassingYear { get; set; }
       
        public string EducationDetails_University { get; set; }
      
        public string EducationDetails_CollegeName { get; set; }
       
        public string EducationDetails_Grade { get; set; }

        public string EntryDate { get; set; }

        public string EntryBy { get; set; }
        public string CompanyName { get; set; }
        public string PassedBy { get; set; }
        public string PassCompanyName { get; set; }
        public string LastEditedBy { get; set; }
        public string LastCompanyName { get; set; }
        public string LastEditedDate { get; set; }


        public static bool Insert(EmployeeEducationDetailsModel Add)
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
                hash.Add("@EmployeeId", Add.EducationDetails_EmployeeId);
                hash.Add("@Education", Add.EducationDetails_EducationId);
                hash.Add("@PassingYear", Add.EducationDetails_PassingYear);
                hash.Add("@University", Add.EducationDetails_University);
                hash.Add("@CollegeName", Add.EducationDetails_CollegeName);
                hash.Add("@Grade",      Add.EducationDetails_Grade);
                hash.Add("@EntryDate                    ", Add.EntryDate);
                hash.Add("@EntryBy                      ", Add.EntryBy);
                hash.Add("@CompanyName                  ", Add.CompanyName);
                hash.Add("@PassedBy                     ", Add.PassedBy);
                hash.Add("@PassCompanyName              ", Add.PassCompanyName);
                hash.Add("@LastEditedBy                 ", Add.LastEditedBy);
                hash.Add("@LastCompanyName              ", Add.LastCompanyName);
                hash.Add("@LastEditedDate               ", Add.LastEditedDate);

                DataLayer.ExecuteDMLQuery("InsUpd_EmployeeEducationDetail", hash);
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }

        }
    }
}
