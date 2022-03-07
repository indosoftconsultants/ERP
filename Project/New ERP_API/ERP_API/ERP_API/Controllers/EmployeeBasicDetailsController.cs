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

        // POST api/<EmployeeBasicDetailsController>
        [HttpPost]
        public PostResult Post([FromBody] EmployeeBasicDetailsModel value)
        {
            try
            {
                if (value != null)
                {
                    if (EmployeeBasicDetailsModel.Insert(value))
                    {
                        return new PostResult(true);

                    }
                    else
                        return new PostResult(false);
                }
                return new PostResult(EmployeeBasicDetailsModel.errorMsg);
            }
            catch (Exception ex)
            {
                return new PostResult("Error : " + ex.Message);
            }
        }

        // PUT api/<EmployeeBasicDetailsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeBasicDetailsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
