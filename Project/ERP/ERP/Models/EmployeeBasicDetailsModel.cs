using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ERP.Models;
using CustomerAPI.Models;
using System.Data;
using System.Web.Mvc;

namespace ERP.Models
{
    public class EmployeeBasicDetailsModel
    {
        #region
        //[Key]
        //public int EmpId { get; set; }


        //public int Prefix { get; set; }


        //[Required(ErrorMessage ="Enter Your Name")]
        //public string FirstName { get; set; }


        //[Required(ErrorMessage = "Enter Your MiddleName")]
        //public string MiddleName { get; set; }


        //[Required(ErrorMessage = "Enter Your LastName")]
        //public string LastName { get; set; }


        //public string SpouseName { get; set; }

        //[Required(ErrorMessage = "Enter Your Email")]
        //[RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Please enter a valid email address")]
        //public string Email { get; set; }


        //public int Gender { get; set; }

        //[Display(Name = "Current Pincode")]
        //public string C_PinCode { get; set; }   

        //[Display(Name ="Current City")]
        //public int C_City { get; set; }

        //[Display(Name = "Current State")]
        //public int C_State { get; set; }

        //[Display(Name = "Current Pincode")]
        //public string P_PinCode { get; set; }

        //[Display(Name = "Current City")]
        //public int P_City { get; set; }

        //[Display(Name = "Current State")]
        //public int P_State { get; set; }

        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Mobile number")]
        //public string Mobile { get; set; }

        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Mobile number")]
        //[Display(Name = "Alternate Mobile No.")]
        //public string AltMobile { get; set; } 


        //public int MaritialStatus { get; set; }

        //[Display(Name = "Passport No")]
        //public string PassportNo { get; set; }

        //[Display(Name = "Adhar Card No")]
        //public string AdharNo { get; set; }

        //[Display(Name = "Driving License No")]
        //public string DrivingLicense { get; set; }

        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Mobile number")]
        //public string RefPerson1Contact { get; set; }

        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Mobile number")]
        //public string RefPerson2Contact { get; set; }

        //[Display(Name = "No Of Girl Child")]
        //public int GirlChild { get; set; }

        //[Display(Name = "No Of Boy Child")]
        //public int BoyChild { get; set; }  


        //public int Children { get; set; }  


        //public float Height { get; set; }  


        //public float Weight { get; set; }

        //[DataType(DataType.Date)]
        //[Display(Name = "Date Of Birth")]
        //public DateTime DateOfBirth { get; set; } 


        ////public string JoiningDate { get; set; } 
        //[DataType(DataType.Date)]
        //[Display(Name = "Driving Liscense Expiry Date")]
        //public DateTime DrivingLiscenseExpiryDate { get; set; }




        //[Display(Name = "PAN Card No")]
        //public string PANNo { get; set; } 


        ////public string MaxEducation { get; set; }

        //[Display(Name = "Reference Person 1")]
        //public string ReferencePerson1 { get; set; }

        //[Display(Name = "Reference Person 2")]
        //public string ReferencePerson2 { get; set; } 

        //[Display(Name = "Provident Fund No")]
        //public string ProvidentFundNo { get; set; }


        //public int lastid { get; set; }



        #endregion

        ////---------------------
        [Key]
        public int EmpId { get; set; }
        //[Required(ErrorMessage = "Select NamePrefix")]
        public int NamePrefix { get; set; }//
        [Display(Name = "Current PinCode")]
        public string CurrentPinCode { get; set; }   //
        [Display(Name = "Current City")]
        //[Required(ErrorMessage = "Select City")]
        public int CurrentCityId { get; set; }      //
        [Display(Name = "Current State")]
        //[Required(ErrorMessage = "Select State")]
        public int CurrentStateId { get; set; }     //
        [Display(Name = "Permanent PinCode")]
        public string PermanentPinCode { get; set; }   //
        [Display(Name = "Permanent City")]
        //[Required(ErrorMessage = "Select City")]
        public int PermanentCityId { get; set; }      //
        [Display(Name = "Permanent State")]
        public int PermanentStateId { get; set; }
        //[Required(ErrorMessage = "Mobile Number")]//
        public string MobileNumber { get; set; }//
        [Display(Name = "AlternateMobileNumber")]
        public string AlternateMobileNumber { get; set; }//
        //[Required(ErrorMessage ="Select Maritial Status ")]
        [Display(Name = "Maritial Status")]
        public int MaritialStatusId { get; set; }  //
        [Display(Name = "Passport Number")]
        public string PassportNumber { get; set; }      //
        [Display(Name = "Aadhaar Number")]
        public string AadhaarNumber { get; set; }         //
        [Display(Name = "Driving License Number")]
        public string DrivingLicenseNumber { get; set; }  //
        [Display(Name = "Reference Person1 Contact")]
        public string ReferencePerson1Contact { get; set; }//
        [Display(Name = "Reference Person2 Contact")]
        public string ReferencePerson2Contact { get; set; }//
        [Display(Name = "No Of Girl Child  ")]
        public int NoOfGirlChild { get; set; }//
        [Display(Name = "No Of Boy Child ")]
        public int NoOfBoyChild { get; set; }//
        public int Children { get; set; }//
        public float Height { get; set; }//
        public float Weight { get; set; }//
        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }//

        [DataType(DataType.Date)]
        public string DrivingLiscenseExpiryDate { get; set; }//
        [Required(ErrorMessage = "Enter Your FirstName")]
        public string FirstName { get; set; }//
        [Required(ErrorMessage = "Enter Your MiddleName")]
        public string MiddleName { get; set; }//
        [Required(ErrorMessage = "Enter Your LastName")]
        public string LastName { get; set; }//
        public string SpouseName { get; set; }//
        //[Required(ErrorMessage = "Enter Your Email")]
        public string Email { get; set; }//
        [Display(Name = "Gender")]
        //[Required(ErrorMessage = "Select Gender")]
        public int GenderId { get; set; }//
        [Display(Name = "Current Address")]
        public string CurrentAddress { get; set; }//
        [Display(Name = "Permanent Address")]
        public string PermanentAddress { get; set; }//
        public string PANCardNumber { get; set; }//

        
        [Display(Name = "Education")]  
        [DataType(DataType.Text)]
        public int EducationId { get; set; }//
        public string ReferencePerson1 { get; set; }//
        public string ReferencePerson2 { get; set; }//
        public string ProvidentFundNumber { get; set; }
        public int lastid { get; set; }

        //Other Details*******************************************
        [Display(Name ="EmployeeId")]
        [DataType(DataType.Text)]
        public int OtherDetails_EmployeeId { get; set; }
        [Display(Name = "JoiningDate")]
        [DataType(DataType.Date)]
        public string OtherDetails_JoiningDate { get; set; }
        [Display(Name = "Department")]
        public int OtherDetails_Department { get; set; }
       
        public string OtherDetails_DepartmentName { get; set; }
        [Display(Name = "Designation")]
        public int OtherDetails_Designation { get; set; }
        
        public string OtherDetails_DesignationName { get; set; }
        [Display(Name = "IsResign")]
        public bool OtherDetails_IsResign { get; set; }
        [Display(Name = "ResignDate")]
        [DataType(DataType.Date)]
        public string OtherDetails_ResignDate { get; set; }
        [Display(Name = "ShiftScheduleId ")]
        public int OtherDetails_ShiftScheduleId { get; set; }
        [Display(Name = "WeeklyOff")]
        public string OtherDetails_WeeklyOff { get; set; }

        //Bank Details*******************************************
        [Display(Name = "EmployeeId")]
        [DataType(DataType.Text)]
        public int BankDetails_EmployeeId { get; set; }
        [Display(Name = "Account Holder's Name")]
        public string BankDetails_AccountHoldersName { get; set; }
        [Display(Name = "Account No")]
        public string BankDetails_AccountNo { get; set; }
        [Display(Name = "IFSC Code ")]
        public string BankDetails_IFSC_Code { get; set; }


        //Education Details*******************************************
        [Display(Name = "Employee Id ")]
        public int EducationDetails_EmployeeId { get; set; }
        [Display(Name = "Education Id ")]
        public int EducationDetails_EducationId { get; set; }
        
        [Display(Name = "Passing Year ")]
        [DataType(DataType.Date)]     
        public string EducationDetails_PassingYear { get; set; }
        [Display(Name = "University Name ")]
        public string EducationDetails_University { get; set; }
        [Display(Name = "College Name  ")]
        public string EducationDetails_CollegeName { get; set; }
        [Display(Name = "Grade's ")]
        public string EducationDetails_Grade { get; set; }


        //Experience Details*******************************************
        [Display(Name = "EmployeeId  ")]
        public int ExperienceDetails_EmployeeId { get; set; }
        [Display(Name = "Joining Date ")]
        [DataType(DataType.Date)]
        public string ExperienceDetails_JoiningDate { get; set; }
        [Display(Name = "Resign Date  ")]
        [DataType(DataType.Date)]
        public string ExperienceDetails_ResignDate { get; set; }
        [Display(Name = "Department ")]

        public int ExperienceDetails_Department { get; set; }
        [Display(Name = "Designation")]
        public int ExperienceDetails_Designation { get; set; }



        //Salary Details*******************************************
        [Display(Name = "EmployeeId ")]
        public int SalaryDetails_EmployeeId { get; set; }
        [Display(Name = "Allowance Deduction Id  ")]
        public int SalaryDetails_AllowanceDeductionId { get; set; }
        [Display(Name = "Amount ")]
        public int SalaryDetails_Amount { get; set; }



        //Common Fields*********************************************
        public string EntryDate { get; set; }

        public string EntryBy { get; set; }
        public string CompanyName { get; set; }
        public string PassedBy { get; set; }
        public string PassCompanyName { get; set; }
        public string LastEditedBy { get; set; }
        public string LastCompanyName { get; set; }
        public string LastEditedDate { get; set; }


        SqlConnection con = new SqlConnection();
        
        

        //public List<EmployeeBasicDetailsModel> GetAllNewEmployees()
        //{
        //    DataLayer.OpenConnection(ref con);
        //    List<EmployeeBasicDetailsModel> EmpList = new List<EmployeeBasicDetailsModel>();


        //    SqlCommand com = new SqlCommand("Select_NewEmployee", con);
        //    com.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter da = new SqlDataAdapter(com);
        //    DataTable dt = new DataTable();

        //    con.Open();
        //    da.Fill(dt);
        //    con.Close();
        //    //Bind EmpModel generic list using dataRow     
        //    foreach (DataRow dr in dt.Rows)
        //    {

        //        EmpList.Add(

        //            new EmployeeBasicDetailsModel
        //            {
        //                EmployeeId = Convert.ToInt32(dr["EmployeeId"]),

        //                FirstName = Convert.ToString(dr["FirstName"]),
        //                MiddleName = Convert.ToString(dr["MiddleName"]),
        //                LastName = Convert.ToString(dr["LastName"]),

        //                DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]),
        //                JoiningDate = Convert.ToDateTime(dr["JoiningDate"]),
        //                Id = Convert.ToInt32(dr["Department"]),
        //                DesignationName = Convert.ToString(dr["Designation"]),

        //                Gender = Convert.ToString(dr["Gender"]),
        //                Mobile = Convert.ToString(dr["Mobile"]),
        //                Email = Convert.ToString(dr["Email"])

        //            }
        //            );

        //    }


        //    return EmpList;
        //}
    }
}
