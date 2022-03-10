using CustomerAPI.Models;
using ERP.Models;
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
    public class DesignationController : ControllerBase
    {
        // GET: api/<DesignationController>
        [HttpGet]
        public List<DesignationMasterModel> Get()
        {
            return DesignationMasterModel.GetAllDesignation();
        }

        // GET api/<DesignationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DesignationController>
        [HttpPost]
        public PostResult Post([FromBody] DesignationMasterModel value)
        {

            try
            {
                if (value != null)
                {

                    // PostPassword.ResetPassword(dtPassData);
                    if (DesignationMasterModel.Insert(value))
                    {
                        return new PostResult(true);
                        // var messaGE=Request.Create
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

        // PUT api/<DesignationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DesignationController>/5
        [HttpDelete("{id}")]
        public PostResult Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    if (DesignationMasterModel.DeleteDesignation(id))
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
