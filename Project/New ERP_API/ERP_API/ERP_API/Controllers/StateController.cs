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
    public class StateController : ControllerBase
    {
        // GET: api/<StateController>
        [HttpGet]
        public List<StateModel> Get()
        {
            return StateModel.GetAllState();
        }

        // GET api/<StateController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StateController>
        [HttpPost]
        public PostResult Post([FromBody] StateModel value)
        {
            try
            {
                if (value != null)
                {
                    if (StateModel.Insert(value))
                    {
                        return new PostResult(true);

                    }
                    else
                        return new PostResult(false);
                }
                return new PostResult(StateModel.errorMsg);
            }
            catch (Exception ex)
            {
                return new PostResult("Error : " + ex.Message);
            }
        }

        // PUT api/<StateController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StateController>/5
        [HttpDelete("{id}")]
        public PostResult Delete(int id)
        {
            try
            {
                if (id > 0)
                {


                    if (StateModel.DeleteState(id))
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
