using CustomerAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_API.Models
{
    public class EmployeeOtherDetailsModel
    {
        public static bool errorMsg { get; set; }

        public int    Id { get; set; }
        public int    OtherDetails_EmployeeId { get; set; }
        
        public string OtherDetails_JoiningDate { get; set; }
       
        public int    OtherDetails_Department { get; set; }

        public string OtherDetails_DepartmentName { get; set; }
       
        public int    OtherDetails_Designation { get; set; }

        public string OtherDetails_DesignationName { get; set; }
        
        public bool   OtherDetails_IsResign { get; set; }
        
       
        public string OtherDetails_ResignDate { get; set; }
       
        public int    OtherDetails_ShiftScheduleId { get; set; }
        
        public string OtherDetails_WeeklyOff { get; set; }


        public string EntryDate { get; set; }

        public string EntryBy { get; set; }
        public string CompanyName { get; set; }
        public string PassedBy { get; set; }
        public string PassCompanyName { get; set; }
        public string LastEditedBy { get; set; }
        public string LastCompanyName { get; set; }
        public string LastEditedDate { get; set; }


        public static bool Insert(EmployeeOtherDetailsModel Add)
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
                hash.Add("@EmployeeId", Add.OtherDetails_EmployeeId);
                hash.Add("@DateOfJoining", Add.OtherDetails_JoiningDate);
                hash.Add("@Department      ", Add.OtherDetails_Department);
                hash.Add("@Designation       ", Add.OtherDetails_Designation);
                hash.Add("@IsResign    ", Add.OtherDetails_IsResign);
                hash.Add("@ResignDate       ", Add.OtherDetails_ResignDate);
                hash.Add("@ShiftScheduleId", Add.OtherDetails_ShiftScheduleId);
                hash.Add("@WeeklyOff   ", Add.OtherDetails_WeeklyOff);
                hash.Add("@EntryDate                    ", Add.EntryDate);
                hash.Add("@EntryBy                      ", Add.EntryBy);
                hash.Add("@CompanyName                  ", Add.CompanyName);
                hash.Add("@PassedBy                     ", Add.PassedBy);
                hash.Add("@PassCompanyName              ", Add.PassCompanyName);
                hash.Add("@LastEditedBy                 ", Add.LastEditedBy);
                hash.Add("@LastCompanyName              ", Add.LastCompanyName);
                hash.Add("@LastEditedDate               ", Add.LastEditedDate);

                DataLayer.ExecuteDMLQuery("InsUpd_EmployeeOtherDetails", hash);
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }

        }

    }
}
