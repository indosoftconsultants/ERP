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
    public class EmployeeExperienceDetailsController : ControllerBase
    {
        // GET: api/<EmployeeExperienceDetailsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EmployeeExperienceDetailsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeeExperienceDetailsController>
        [HttpPost]
        public PostResult Post([FromBody] EmployeeExperienceDetailsModel value)
        {
            try
            {
                if (value != null)
                {
                    if (EmployeeExperienceDetailsModel.Insert(value))
                    {
                        return new PostResult(true);
                        // var messaGE=Request.Create
                    }
                    else
                        return new PostResult(false);
                }
                return new PostResult(EmployeeExperienceDetailsModel.errorMsg);
            }
            catch (Exception ex)
            {
                return new PostResult("Error : " + ex.Message);
            }
        }

        // PUT api/<EmployeeExperienceDetailsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeExperienceDetailsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
