using CustomerAPI.Models;
using ERP_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ERP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        // GET: api/<DepartmentController>
        [HttpGet]
        public List<DepartmentMasterModel> Get()
        {
            return DepartmentMasterModel.GetAllDepartment();
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public PostResult Post([FromBody] DepartmentMasterModel value)
        {
            try
            {
                if (value != null)
                {
                    if (DepartmentMasterModel.Insert(value))
                    {
                        return new PostResult(true);
                        // var messaGE=Request.Create
                    }
                    else
                        return new PostResult(false);
                }
                return new PostResult(DepartmentMasterModel.errorMsg);
            }
            catch (Exception ex)
            {
                return new PostResult("Error : " + ex.Message);
            }
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public PostResult Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    if (DepartmentMasterModel.DeleteDepartment(id))
                    {
                        return new PostResult(true);
                    }
                    else
                        return new PostResult(false);
                }
                return new PostResult(CountryModel.errorMsg);
            }
            catch (Exception ex)
            {
                return new PostResult("Error : " + ex.Message);
            }
        }
    }
}
