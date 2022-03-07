using ERP_API.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class CascadingModel
    {
       public static SqlConnection con = new SqlConnection();
        public static List<CountryModel> GetAllCountries()
        {
            Connection.OpenConnection(ref con);
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
                        CountryName = Convert.ToString(dr["CountryName"])

                    }
                    );
            }
            Connection.CloseConnection(ref con);
            return List;
        }


        public static DataSet GetAllStatesById(int id)
        {
            Connection.OpenConnection(ref con);
            SqlCommand com = new SqlCommand("Select * from StateMaster where CountryId = @Id", con);
            com.Parameters.AddWithValue("@Id", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Connection.CloseConnection(ref con);
            return ds;
        }


        public static List<CityModel> GetAllCityById( int id)
        {
            Connection.OpenConnection(ref con);
            List<CityModel> List = new List<CityModel>();
            CityModel s = new CityModel();
            SqlCommand com = new SqlCommand("Select * from CityMaster where StateId ='" + id + "' ", con);
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
    }
}
