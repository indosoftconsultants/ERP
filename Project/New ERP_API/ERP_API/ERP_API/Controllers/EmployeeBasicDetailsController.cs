using CustomerAPI.Models;
using ERP_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ERP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeBasicDetailsController : ControllerBase
    {
        // GET: api/<EmployeeBasicDetailsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EmployeeBasicDetailsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        //[HttpPost]
        //public PostResult Post([FromBody] EmployeeBasicDetailsModel value)
        //{
        //    try
        //    {
        //        if (value != null)
        //        {
        //            if (EmployeeBasicDetailsModel.Insert(value))
        //            {
        //                return new PostResult(true);
        //            }
        //            else
        //                return new PostResult(false);
        //        }
        //        return new PostResult(EmployeeBasicDetailsModel.errorMsg);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new PostResult("Error : " + ex.Message);
        //    }
        //}

        //[HttpPost]
        //public PostResult Post([FromBody] EmployeeBasicDetailsModel value)
        //{
        //    try
        //    {
        //        if (value != null)
        //        {
        //            var a = EmployeeBasicDetailsModel.InsertReturnId(value);

        //            if (a>0)
        //            {
        //                return new PostResult(true);
        //            }
        //            else
        //                return new PostResult(false);
        //        }
        //        return new PostResult(EmployeeBasicDetailsModel.errorMsg);
        //        }
        //    catch (Exception ex)
        //    {
        //        return new PostResult("Error : " + ex.Message);
        //    }
        //}

        [HttpPost]
        public int Post([FromBody] EmployeeBasicDetailsModel value)
        {
            try
            {
                if (value != null)
                {
                    var LastId = EmployeeBasicDetailsModel.InsertReturnId(value);

                    if (LastId > 0)
                    {

                        return LastId;
                    }
                    else
                        return 0;
                }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }



       
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
