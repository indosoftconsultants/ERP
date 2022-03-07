using CustomerAPI.Models;
using ERP_API.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class CityModel
    {

       

        [Key]
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 3, ErrorMessage = "Enter Valid Name")]
        [Required(ErrorMessage ="Enter City Name")]
        public string CityName { get; set; }

        public int StateId { get; set; }

        public int CountryId { get; set; }

        public bool IsBlock { get;  set; }
        public DateTime EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string CompanyName { get; set; }
        public string PassedBy { get; set; }
        public string PassCompanyName { get; set; }
        public string LastEditedBy { get; set; }
        public string LastCompanyName { get; set; }
        public DateTime LastEditedDate { get; set; }


        


        SqlConnection con = new SqlConnection();

        public bool Insert(CityModel Add)
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
                hash.Add("@CityName", Add.CityName);
                hash.Add("@StateId", Add.StateId);
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
                DataLayer.ExecuteDMLQuery("InsUpd_City", hash);
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }


        public List<CityModel> GetAllCity()
        {
            Connection.OpenConnection(ref con);
            List<CityModel> List = new List<CityModel>();
            CityModel s = new CityModel();
            SqlCommand com = new SqlCommand("Select * from CityMaster", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            
            da.Fill(dt);
            
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {
                List.Add(
                    new CityModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        CityName = Convert.ToString(dr["CityName"]),
                        StateId = Convert.ToInt32(dr["StateId"]),
                        CountryId = Convert.ToInt32(dr["CountryId"])
                    }
                    );
            }
            Connection.CloseConnection(ref con);
            return List;
           
        }



        public List<CityModel> GetAllStatesById( int id)
        {
            Connection.OpenConnection(ref con);
            List<CityModel> List = new List<CityModel>();
            CityModel s = new CityModel();
            SqlCommand com = new SqlCommand("Select * from StateMaster where CountryId ='" + id + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            da.Fill(dt);

            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {
                List.Add(
                    new CityModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        CityName = Convert.ToString(dr["StateName"]),
                        StateId = Convert.ToInt32(dr["StateId"]),
                        CountryId = Convert.ToInt32(dr["CountryId"])
                    }
                    );
            }
            Connection.CloseConnection(ref con);
            return List;
        }

        public bool DeleteCountry(CityModel obj)
        {
            try
            {
                SqlCommand com = new SqlCommand("Delete CityMaster  where Id = '" + Id + "' ", con);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
