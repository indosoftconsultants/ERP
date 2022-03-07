using CustomerAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_API.Models
{
    public class EmployeeBasicDetailsModel
    {
        public int Id { get; set; }

        public int NamePrefix { get; set; }//

        public string CurrentPinCode { get; set; }   //

        public int CurrentCityId { get; set; }      //

        public int CurrentStateId { get; set; }     //

        public string PermanentPinCode { get; set; }   //

        public int PermanentCityId { get; set; }      //

        public int PermanentStateId { get; set; }
        public string MobileNumber { get; set; }//

        public string AlternateMobileNumber { get; set; }//

        public int MaritialStatusId { get; set; }  //

        public string PassportNumber { get; set; }      //

        public string AadhaarNumber { get; set; }         //

        public string DrivingLicenseNumber { get; set; }  //

        public string ReferencePerson1Contact { get; set; }//
    
        public string ReferencePerson2Contact { get; set; }//
        
        public int NoOfGirlChild { get; set; }//
        
        public int NoOfBoyChild { get; set; }//
        public int Children { get; set; }//
        public float Height { get; set; }//
        public float Weight { get; set; }//
        
        public string DateOfBirth { get; set; }//

        
        public string DrivingLiscenseExpiryDate { get; set; }//
       
        public string FirstName { get; set; }//
        
        public string MiddleName { get; set; }//
        
        public string LastName { get; set; }//
        public string SpouseName { get; set; }//
        
        public string Email { get; set; }//
       
        
        public int GenderId { get; set; }//
       
        public string CurrentAddress { get; set; }//
        
        public string PermanentAddress { get; set; }//
        public string PANCardNumber { get; set; }//
       

        public int EducationId { get; set; }//
        public string ReferencePerson1 { get; set; }//
        public string ReferencePerson2 { get; set; }//
        public string ProvidentFundNumber { get; set; }
        public int lastid { get; set; }




        //Common Fields
        public string EntryDate { get; set; }

        public string EntryBy { get; set; }
        public string CompanyName { get; set; }
        public string PassedBy { get; set; }
        public string PassCompanyName { get; set; }
        public string LastEditedBy { get; set; }
        public string LastCompanyName { get; set; }
        public string LastEditedDate { get; set; }



        public static SqlConnection con = new SqlConnection();
        public static bool errorMsg;

        public static bool Insert(EmployeeBasicDetailsModel Add)
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
                hash.Add("@Id                           "  ,Add.Id);
                hash.Add("@NamePrefix                   "  ,Add.NamePrefix);
                hash.Add("@FirstName                    "  ,Add.FirstName);
                hash.Add("@MiddleName                   "  ,Add.MiddleName);
                hash.Add("@LastName                     "  ,Add.LastName);
                hash.Add("@Email                        "  ,Add.Email);
                hash.Add("@GenderId                     "  ,Add.GenderId);
                hash.Add("@CurrentAddress               "  ,Add.CurrentAddress);
                hash.Add("@PermanentAddress             "  ,Add.PermanentAddress);
                hash.Add("@PANCardNumber                "  ,Add.PANCardNumber);
                hash.Add("@EducationId                  "  ,Add.EducationId);
                hash.Add("@ReferencePerson1             "  ,Add.ReferencePerson1);
                hash.Add("@ReferencePerson2             "  ,Add.ReferencePerson2);
                hash.Add("@ReferencePerson1Contact      "  ,Add.ReferencePerson1Contact);
                hash.Add("@ReferencePerson2Contact      "  ,Add.ReferencePerson2Contact);
                hash.Add("@CurrentPinCode               "  ,Add.CurrentPinCode);
                hash.Add("@CurrentCityId                "  ,Add.CurrentCityId);
                hash.Add("@CurrentStateId               "  ,Add.CurrentStateId);
                hash.Add("@PermanentPinCode             "  ,Add.PermanentPinCode);
                hash.Add("@PermanentCityId              "  ,Add.PermanentCityId);
                hash.Add("@PermanentStateId             "  ,Add.PermanentStateId);
                hash.Add("@MobileNumber                 "  ,Add.MobileNumber);
                hash.Add("@AlternateMobileNumber        "  ,Add.AlternateMobileNumber);
                hash.Add("@MaritialStatusId             "  ,Add.MaritialStatusId);
                hash.Add("@PassportNumber               "  ,Add.PassportNumber);
                hash.Add("@AadhaarNumber                "  ,Add.AadhaarNumber);
                hash.Add("@DrivingLicenseNumber         "  ,Add.DrivingLicenseNumber);
                hash.Add("@NoOfBoyChild                 "  ,Add.NoOfBoyChild);
                hash.Add("@NoOfGirlChild                "  ,Add.NoOfGirlChild);
                hash.Add("@Height                       "  ,Add.Height);
                hash.Add("@Weight                       "  ,Add.Weight);
                hash.Add("@SpouseName                   "  ,Add.SpouseName);
                hash.Add("@DateOfBirth                  "  ,Add.DateOfBirth);
                hash.Add("@DrivingLiscenseExpiryDate    "  ,Add.DrivingLiscenseExpiryDate);
                hash.Add("@ProvidentFundNumber          "  ,Add.ProvidentFundNumber);
                hash.Add("@EntryDate                    "  ,Add.EntryDate);
                hash.Add("@EntryBy                      "  ,Add.EntryBy);
                hash.Add("@CompanyName                  "  ,Add.CompanyName);
                hash.Add("@PassedBy                     "  ,Add.PassedBy);
                hash.Add("@PassCompanyName              "  ,Add.PassCompanyName);
                hash.Add("@LastEditedBy                 "  ,Add.LastEditedBy);
                hash.Add("@LastCompanyName              "  ,Add.LastCompanyName);
                hash.Add("@LastEditedDate               "  ,Add.LastEditedDate);

                DataLayer.ExecuteDMLQuery("InsUpd_EmployeeBasicDetail", hash);
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }
    }
}
