using ERP_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ERP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        // GET: api/<CountryController>
        [HttpGet]
        public List<CountryModel> Get()
        {
            return CountryModel.GetAllCountries();
        }

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CountryController>
        [HttpPost]
        public PostResult Post([FromBody] CountryModel value)
        {
            try
            {
                if (value != null)
                {

                    // PostPassword.ResetPassword(dtPassData);
                    if (CountryModel.Insert(value))
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

        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public PostResult Delete(int id)
        {
            try
            {
                if (id > 0)
                {

                   
                    if (CountryModel.DeleteCountry(id))
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
