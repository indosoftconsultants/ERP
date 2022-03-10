using CustomerAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_API.Models
{
    public class DepartmentMasterModel
    {

        public static bool errorMsg { get; set; }

        public int Id { get; set; }

        public string DepartmentName { get; set; }

        public DateTime EntryDate { get; set; }

        public string EntryBy { get; set; }

        public string CompanyName { get; set; }

        public string PassedBy { get; set; }

        public string PassCompanyName { get; set; }

        public string LastEditedBy { get; set; }

        public string LastCompanyName { get; set; }

        public DateTime LastEditedDate { get; set; }


       public static SqlConnection con = new SqlConnection();
        
        public static List<DepartmentMasterModel> GetAllDepartment()
        {
            List<DepartmentMasterModel> List = new List<DepartmentMasterModel>();

            Connection.OpenConnection(ref con);

            SqlCommand com = new SqlCommand("Select * from DepartmentMaster", con);

            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();


            da.Fill(dt);

            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                List.Add(

                    new DepartmentMasterModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        DepartmentName = Convert.ToString(dr["DepartmentName"])

                    }
                    );

            }
            Connection.CloseConnection(ref con);

            return List;
        }

        public static bool Insert(DepartmentMasterModel Add)
        {

            Add.EntryDate = DateTime.Today;
            Add.EntryBy = "a";
            Add.CompanyName = "a";
            Add.PassedBy = "a";
            Add.PassCompanyName = "a";
            Add.LastEditedBy = "a";
            Add.LastCompanyName = "a";
            Add.LastEditedDate = DateTime.Today;
            try
            {
                Hashtable hash = new Hashtable();
                hash.Add("@Id", Add.Id);
                hash.Add("@DepartmentName", Add.DepartmentName);
                hash.Add("@EntryDate      ", Add.EntryDate);
                hash.Add("@EntryBy        ", Add.EntryBy);
                hash.Add("@CompanyName    ", Add.CompanyName);
                hash.Add("@PassedBy       ", Add.PassedBy);
                hash.Add("@PassCompanyName", Add.PassCompanyName);
                hash.Add("@LastEditedBy   ", Add.LastEditedBy);
                hash.Add("@LastCompanyName", Add.LastCompanyName);
                hash.Add("@LastEditedDate ", Add.LastEditedDate);

                DataLayer.ExecuteDMLQuery("InsUpd_DepartmentMaster", hash);
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }

        }

        public static bool DeleteDepartment(int obj)
        {
            try
            {
                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("Delete DepartmentMaster  where Id = '" + obj + "' ", con);

                com.ExecuteNonQuery();

                Connection.CloseConnection(ref con);
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

    }
}

