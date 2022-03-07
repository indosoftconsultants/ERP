using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_API.Models
{
    public class EmployeeBasicDetailsModel
    {
        SqlConnection con = new SqlConnection();
        public int EmpId { get; set; }
        public int Prefix { get; set; }//
        public string C_PinCode { get; set; }   //
        public string C_City { get; set; }      //
        public string C_State { get; set; }     //
        public string P_PinCode { get; set; }   //
        public string P_City { get; set; }      //
        public string P_State { get; set; }     //
        public string Mobile { get; set; }//
        public string AltMobile { get; set; }//
        public string MaritialStatus { get; set; }  //
        public string PassportNo { get; set; }      //
        public string AdharNo { get; set; }         //
        public string DrivingLicense { get; set; }  //
        public string RefPerson1Contact { get; set; }//
        public string RefPerson2Contact { get; set; }//
        public int GirlChild { get; set; }//
        public int BoyChild { get; set; }//
        public int Children { get; set; }//
        public float Height { get; set; }//
        public float Weight { get; set; }//
        public string DateOfBirth { get; set; }//
        //public string JoiningDate { get; set; }//
        public string DrivingLiscense_ExpiryDate { get; set; }//
        public string FirstName { get; set; }//
        public string MiddleName { get; set; }//
        public string LastName { get; set; }//
        public string SpouseName { get; set; }//
        public string Email { get; set; }//
        public string Gender { get; set; }//
        public string CurrentAddress { get; set; }//
        public string PermanentAddress { get; set; }//
        public string PAN_No { get; set; }//
        public string MaxEducation { get; set; }//
        public string RefPerson1 { get; set; }//
        public string RefPerson2 { get; set; }//
        public string PF_No { get; set; }
        public int lastid { get; set; }


        public int Insert(Employee_Basic_Details Add)
        {
            clsSunDAL.OpenConnection(ref con);
            try
            {
                Hashtable hash = new Hashtable();
                hash.Add("@EmpId", Add.EmpId);
                hash.Add("@FirstName", Add.FirstName);
                hash.Add("@MiddleName", Add.MiddleName);
                hash.Add("@LastName", Add.LastName);
                hash.Add("@SpouseName", Add.SpouseName);
                hash.Add("@Email", Add.Email);
                hash.Add("@Gender", Add.Gender);
                hash.Add("@CurrentAddress", Add.CurrentAddress);
                hash.Add("@PermanentAddress", Add.PermanentAddress);
                hash.Add("@PANCardNo", Add.PAN_No);
                hash.Add("@MaxEducation", Add.MaxEducation);
                hash.Add("@RefPerson1", Add.RefPerson1);
                hash.Add("@RefPerson2", Add.RefPerson2);
                hash.Add("@Prefix", Add.Prefix);
                hash.Add("@C_PinCode", Add.C_PinCode);
                hash.Add("@C_City", Add.C_City);
                hash.Add("@C_State", Add.C_State);
                hash.Add("@P_PinCode", Add.P_PinCode);
                hash.Add("@P_City", Add.P_City);
                hash.Add("@P_State", Add.P_State);
                hash.Add("@Mobile", Add.Mobile);
                hash.Add("@AltMobile", Add.AltMobile);
                hash.Add("@MaritialStatus", Add.MaritialStatus);
                hash.Add("@PassportNo", Add.PassportNo);
                hash.Add("@AdharNo", Add.AdharNo);
                hash.Add("@DrivingLicense", Add.DrivingLicense);
                hash.Add("@RefPerson1Contact", Add.RefPerson1Contact);
                hash.Add("@RefPerson2Contact", Add.RefPerson2Contact);
                hash.Add("@BoyChild", Add.BoyChild);
                hash.Add("@GirlChild", Add.GirlChild);
                hash.Add("@Height", Add.Height);
                hash.Add("@Weight", Add.Weight);
                hash.Add("@DateOfBirth", Add.DateOfBirth);
                //hash.Add("@JoiningDate", Add.JoiningDate);
                hash.Add("@DrivingLiscense_ExpiryDate", Add.DrivingLiscense_ExpiryDate);
                hash.Add("@PF_No", Add.PF_No);

                //clsSunDAL.ExecuteDMLQuery("Ins_EmployeeBasicDetail", hash);
                DataTable id = clsSunDAL.FillDataTable("Ins_EmployeeBasicDetail", hash);
                lastid = int.Parse(id.Rows[0][0].ToString());

                return lastid;

            }
            catch (Exception Ex)
            {
                if (lastid != EmpId)
                {
                    return EmpId;
                }
                return 0;

            }
            clsSunDAL.CloseConnection(ref con);
        }
    }
}
