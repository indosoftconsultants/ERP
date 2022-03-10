using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ERP.Models;
using CustomerAPI.Models;
using System.Data;

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
        [Required(ErrorMessage = "Select Education")]
        public int NamePrefix { get; set; }//
        [Display(Name = "Current PinCode")]
        public string CurrentPinCode { get; set; }   //
        [Display(Name = "Current City")]
        [Required(ErrorMessage = "Select City")]
        public int CurrentCityId { get; set; }      //
        [Display(Name = "Current State")]
        [Required(ErrorMessage = "Select State")]
        public int CurrentStateId { get; set; }     //
        [Display(Name = "Permanent PinCode")]
        public string PermanentPinCode { get; set; }   //
        [Display(Name = "Permanent City")]
        [Required(ErrorMessage = "Select City")]
        public int PermanentCityId { get; set; }      //
        [Display(Name = "Permanent State")]
        public int PermanentStateId { get; set; }
        [Required(ErrorMessage = "Mobile Number")]//
        public string MobileNumber { get; set; }//
        [Display(Name = "AlternateMobileNumber")]
        public string AlternateMobileNumber { get; set; }//
        [Required(ErrorMessage ="Select Maritial Status ")]
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
        [Required(ErrorMessage = "Enter Your Email")]
        public string Email { get; set; }//
        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Select Gender")]
        public int GenderId { get; set; }//
        [Display(Name = "Current Address")]
        public string CurrentAddress { get; set; }//
        [Display(Name = "Permanent Address")]
        public string PermanentAddress { get; set; }//
        public string PANCardNumber { get; set; }//
        [Required(ErrorMessage ="Select Education")]
        [Display(Name = "Education")]
        
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
