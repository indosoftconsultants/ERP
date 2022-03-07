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
    public class CountryModel
    {
        public int Id { get; set; }
        [Display(Name= "Country Name ")]
        [DataType(DataType.Text)]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Enter Valid Name")]
        [Required(ErrorMessage = "Enter Country Name")]
        public string CountryName { get; set; }
        public bool isSuccess { get; set;  }
        public bool IsBlock { get; set; }

        public DateTime EntryDate { get; set; }
        public string   EntryBy         { get; set; }
        public string   CompanyName     { get; set; }
        public string   PassedBy        { get; set; }
        public string   PassCompanyName { get; set; }
        public string   LastEditedBy    { get; set; }
        public string   LastCompanyName { get; set; }
        public DateTime LastEditedDate  { get; set; }

        SqlConnection con = new SqlConnection(@"Data Source=192.168.10.34;Initial Catalog=ERP;User ID=sa;Password=sa");
        //SqlConnection con = new SqlConnection(@"Data Source=192.168.1.34;Initial Catalog=ERP;User ID=sa;Password=sa");

        public bool Insert(CountryModel Add)
        {
            Add.IsBlock = false;
            Add.EntryDate       =  DateTime.Today ;
            Add.EntryBy         = "a";
            Add.CompanyName      = "a";
            Add.PassedBy        = "a";
            Add.PassCompanyName  = "a";
            Add.LastEditedBy     = "a";
            Add.LastCompanyName = "a";
            Add.LastEditedDate  =  DateTime.Today ;
            try
            {
                Hashtable hash = new Hashtable();
                hash.Add("@Id", Add.Id);
                hash.Add("@CountryName", Add.CountryName);
                hash.Add("@IsBlock", Add.IsBlock);
                hash.Add("@EntryDate      ", Add.EntryDate      );
                hash.Add("@EntryBy        ", Add.EntryBy        );
                hash.Add("@CompanyName    ", Add.CompanyName    );
                hash.Add("@PassedBy       ", Add.PassedBy       );
                hash.Add("@PassCompanyName", Add.PassCompanyName);
                hash.Add("@LastEditedBy   ", Add.LastEditedBy   );
                hash.Add("@LastCompanyName", Add.LastCompanyName);
                hash.Add("@LastEditedDate ", Add.LastEditedDate);

                DataLayer.ExecuteDMLQuery("InsUpd_Country", hash);
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }


        }

        public List<CountryModel> GetAllCountries()
        {


            List<CountryModel> List = new List<CountryModel>();

            
            SqlCommand com = new SqlCommand("Select * from CountryMaster", con);
            
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                List.Add(

                    new CountryModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        CountryName= Convert.ToString(dr["CountryName"])

                    }
                    );

            }


            return List;
        }

        public bool UpdateCountry(CountryModel obj)
        {
            try
            {
                SqlCommand com = new SqlCommand("Update CountryMaster set CountryName = '"+ CountryName  + "' where Id = '"+ Id + "' ", con);
               
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

        public bool DeleteCountry(CountryModel obj)
        {
            try
            {
                SqlCommand com = new SqlCommand("Delete CountryMaster  where Id = '" + Id + "' ", con);
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


        public void BlockCountry(CountryModel Add)
        {
            try
            {
                //con.Open();


                Hashtable hash = new Hashtable();
                hash.Add("@Id", Add.Id);


                DataLayer.ExecuteDMLQuery("BlockCountry", hash);


            }
            catch (Exception Ex)
            {

            }
            //con.Close();
        }

        public bool BlockCountryget(CountryModel Add)
        {
            try
            {
                bool status;
                
                //con.Open();
                SqlDataAdapter Sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                SqlCommand com = new SqlCommand("select IsBlock from CountryMaster  where Id = '" + Id + "' ", con);
                Sda = new SqlDataAdapter(com);
                Sda.Fill(dt);
                con.Open();
               var  a =  com.ExecuteNonQuery();
                if(a==1 || a==-1)
                {
                    if (dt.Columns.Count>0)
                    {
                       var IsBlock = (bool)dt.Rows[0]["IsBlock"];
                        
                        if (IsBlock == true)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        
                    }
                    
                }
                con.Close();

                return false;


            }
            catch (Exception Ex)
            {
                return false;
            }
            //con.Close();
        }


        public  List<CountryModel> List()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=192.168.10.34;Initial Catalog=ERP;User ID=sa;Password=sa");
            List<CountryModel> list = new List<CountryModel>();
            using (conn)
            {
                string query = "select Id,IsBlock from CountryMaster  where IsBlock = 1";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            list.Add(new CountryModel
                            {

                                Id = Convert.ToInt32(sdr["Id"])
                            });
                        }
                    }
                    conn.Close();
                }
            }
            return list;
            //try
            //{
            //    SqlCommand com = new SqlCommand(" select CountryId from CountryMaster  where IsBlock = 1", con);
            //    con.Open();
            //    com.ExecuteNonQuery();
            //    con.Close();
                
            //}

            //catch (Exception ex)
            //{
                
            //}
            //return list;
        }
    }
}
