
﻿using CustomerAPI.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

        SqlConnection con = new SqlConnection();

        public List<DesignationMasterModel> GetAllDesignation()
        {
            List<DesignationMasterModel> List = new List<DesignationMasterModel>();
            DataLayer.Open(ref con);
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

                    });
            }
            DataLayer.Close(ref con);
            return List;
        }
    }
}
