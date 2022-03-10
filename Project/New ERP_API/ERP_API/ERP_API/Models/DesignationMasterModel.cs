using CustomerAPI.Models;
using ERP_API.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class DesignationMasterModel
    {
        public int Id { get; set; }

        public string DesignationName { get; set; }

        public int DepartmentId { get; set; }

        public DateTime EntryDate { get; set; }

        public string EntryBy { get; set; }

        public string CompanyName { get; set; }

        public string PassedBy { get; set; }

        public string PassCompanyName { get; set; }

        public string LastEditedBy { get; set; }

        public string LastCompanyName { get; set; }

        public DateTime LastEditedDate { get; set; }

        public static SqlConnection con = new SqlConnection();

        public static List<DesignationMasterModel> GetAllDesignation()
        {
            List<DesignationMasterModel> List = new List<DesignationMasterModel>();
            Connection.OpenConnection(ref con);
            SqlCommand com = new SqlCommand("Select * from DesignationMaster", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {
                List.Add(
                    new DesignationMasterModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        DesignationName = Convert.ToString(dr["DesignationName"]),
                        DepartmentId = Convert.ToInt32(dr["DepartmentId"])
                    }
                    );
            }
            Connection.CloseConnection(ref con);

            return List;
        }

        public static bool Insert(DesignationMasterModel Add)
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
                hash.Add("@DesignationName", Add.DesignationName);
                hash.Add("@DepartmentId", Add.DepartmentId);
                hash.Add("@EntryDate      ", Add.EntryDate);
                hash.Add("@EntryBy        ", Add.EntryBy);
                hash.Add("@CompanyName    ", Add.CompanyName);
                hash.Add("@PassedBy       ", Add.PassedBy);
                hash.Add("@PassCompanyName", Add.PassCompanyName);
                hash.Add("@LastEditedBy   ", Add.LastEditedBy);
                hash.Add("@LastCompanyName", Add.LastCompanyName);
                hash.Add("@LastEditedDate ", Add.LastEditedDate);

                DataLayer.ExecuteDMLQuery("InsUpd_DesignationMaster", hash);
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }

        }

        public static bool DeleteDesignation(int obj)
        {
            try
            {
                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("Delete DesignationMaster  where Id = '" + obj + "' ", con);

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
