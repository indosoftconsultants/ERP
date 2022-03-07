using CustomerAPI.Models;
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
    public class StateModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "State Name ")]
        [DataType(DataType.Text)]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Enter Valid Name")]
        [Required(ErrorMessage = "Enter State Name")]
        public string StateName { get; set; }

        [Display(Name = "Country ")]
        [Required(ErrorMessage ="Select Country")]
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

        SqlConnection con = new SqlConnection(@"Data Source=192.168.10.34;Initial Catalog=ERP;User ID=sa;Password=sa");

        public bool Insert(StateModel Add)
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
                hash.Add("@StateId", Add.Id);
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

        public List<StateModel> GetAllState()
        {
            List<StateModel> List = new List<StateModel>();
            StateModel s = new StateModel();
            SqlCommand com = new SqlCommand("Select * from StateMaster", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
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
            return List;
        }

        //public StateModel GetStateById(int id)
        //{
        //    StateModel Customer = new StateModel();
        //    SqlCommand cmd = new SqlCommand("Select StateId where S", con);

        //}



           


            #region Currently not in use 
            public bool UpdateCountry(CountryModel obj)
        {
            try
            {
                SqlCommand com = new SqlCommand("Update CountryMaster set CountryName = '" + StateName + "' where StateId = '" + Id + "' ", con);

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
        #endregion

        public bool DeleteCountry(StateModel obj)
        {
            try
            {
                SqlCommand com = new SqlCommand("Delete StateMaster  where Id = '" + Id + "' ", con);
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


        //public void BlockCountry(StateModel Add)
        //{
        //    try
        //    {
        //        //con.Open();


        //        Hashtable hash = new Hashtable();
        //        hash.Add("@Id", Add.Id);


        //        DataLayer.ExecuteDMLQuery("BlockCountry", hash);


        //    }
        //    catch (Exception Ex)
        //    {

        //    }
        //    //con.Close();
    }

        //public bool BlockCountryget(StateModel Add)
        //{
        //    try
        //    {
        //        bool status;

        //        //con.Open();
        //        SqlDataAdapter Sda = new SqlDataAdapter();
        //        DataTable dt = new DataTable();
        //        SqlCommand com = new SqlCommand("select IsBlock from CountryMaster  where CountryId = '" + Id + "' ", con);
        //        Sda = new SqlDataAdapter(com);
        //        Sda.Fill(dt);
        //        con.Open();
        //        var a = com.ExecuteNonQuery();
        //        if (a == 1 || a == -1)
        //        {
        //            if (dt.Columns.Count > 0)
        //            {
        //                var IsBlock = (bool)dt.Rows[0]["IsBlock"];

        //                if (IsBlock == true)
        //                {
        //                    return true;
        //                }
        //                else
        //                {
        //                    return false;
        //                }

        //            }

        //        }
        //        con.Close();

        //        return false;


        //    }
        //    catch (Exception Ex)
        //    {
        //        return false;
        //    }
        //    //con.Close();
        //}


        //public List<StateModel> List()
        //{
        //    SqlConnection conn = new SqlConnection(@"Data Source=192.168.10.34;Initial Catalog=ERP;User ID=sa;Password=sa");
        //    List<StateModel> list = new List<StateModel>();
        //    using (conn)
        //    {
        //        string query = "select CountryId,IsBlock from CountryMaster  where IsBlock = 1";
        //        using (SqlCommand cmd = new SqlCommand(query))
        //        {
        //            cmd.Connection = conn;
        //            conn.Open();
        //            using (SqlDataReader sdr = cmd.ExecuteReader())
        //            {
        //                while (sdr.Read())
        //                {
        //                    list.Add(new StateModel
        //                    {

        //                        Id = Convert.ToInt32(sdr["CountryId"])
        //                    });
        //                }
        //            }
        //            conn.Close();
        //        }
        //    }
        //    return list;
            
        //}
    
}
