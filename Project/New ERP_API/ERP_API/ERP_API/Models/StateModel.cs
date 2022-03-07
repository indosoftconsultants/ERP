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
    public class StateModel
    {
        public static bool errorMsg { get; set; }
        public int Id { get; set; }

        public string StateName { get; set; }

     
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public bool isSuccess { get; set; }
        public bool IsBlock { get; set; }

        public DateTime EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string CompanyName { get; set; }
        public string PassedBy { get; set; }
        public string PassCompanyName { get; set; }
        public string LastEditedBy { get; set; }
        public string LastCompanyName { get; set; }
        public DateTime LastEditedDate { get; set; }

       public static SqlConnection con = new SqlConnection();

        public static bool Insert(StateModel Add)
        {
            Add.IsBlock = false;
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
                hash.Add("@StateName", Add.StateName);
                hash.Add("@CountryId", Add.CountryId);
                hash.Add("@IsBlock", Add.IsBlock);
                hash.Add("@EntryDate      ", Add.EntryDate);
                hash.Add("@EntryBy        ", Add.EntryBy);
                hash.Add("@CompanyName    ", Add.CompanyName);
                hash.Add("@PassedBy       ", Add.PassedBy);
                hash.Add("@PassCompanyName", Add.PassCompanyName);
                hash.Add("@LastEditedBy   ", Add.LastEditedBy);
                hash.Add("@LastCompanyName", Add.LastCompanyName);
                hash.Add("@LastEditedDate ", Add.LastEditedDate);

                DataLayer.ExecuteDMLQuery("InsUpd_State", hash);
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }


        }

        public static List<StateModel> GetAllState()
        {
            Connection.OpenConnection(ref con);
            List<StateModel> List = new List<StateModel>();
            StateModel s = new StateModel();
            SqlCommand com = new SqlCommand("Select * from StateMaster", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            
            da.Fill(dt);
            
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {
                List.Add(
                    new StateModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        StateName = Convert.ToString(dr["StateName"]),
                        CountryId = Convert.ToInt32(dr["CountryId"])

                    }
                    );
            }
            Connection.CloseConnection(ref con);
            return List;
        }

        public static bool DeleteState(int obj)
        {
            try
            {
                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("Delete StateMaster  where Id = '" + obj + "' ", con);
                
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
