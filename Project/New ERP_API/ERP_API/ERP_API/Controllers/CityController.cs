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
    public class CityController : ControllerBase
    {
        // GET: api/<CityController>
        [HttpGet]
        public List<CityModel> Get()
        {
            return CityModel.GetAllCity();
        }

        // GET api/<CityController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CityController>
        [HttpPost]
        public PostResult Post([FromBody] CityModel value)
        {

            try
            {
                if (value != null)
                {
                    if (CityModel.Insert(value))
                    {
                        return new PostResult(true);

                    }
                    else
                        return new PostResult(false);
                }
                return new PostResult(CityModel.errorMsg);
            }
            catch (Exception ex)
            {
                return new PostResult("Error : " + ex.Message);
            }
        }

        // PUT api/<CityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public PostResult Delete(int id)
        {
            try
            {
                if (id > 0)
                {


                    if (CityModel.DeleteCity(id))
                    {

                        return new PostResult(true);

                    }
                    else
                        return new PostResult(false);


                }
                return new PostResult(CityModel.errorMsg);
            }
            catch (Exception ex)
            {
                return new PostResult("Error : " + ex.Message);
            }
        }
    }
}
