using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollectionLogic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CollectionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeatController : ControllerBase
    {
        private readonly Peat cont = new Peat();

        // GET: api/<PeatController>
        [HttpGet]
        public List<CollectionLogic.Entities.UserEntitiy> Get()
        {
            return cont.Read();
        }

        // GET api/<PeatController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PeatController>
        [HttpPost]
        public void Post([FromBody] CollectionLogic.Entities.OrderEntity value)
        {
            cont.updateOrder(value);
        }

        // PUT api/<PeatController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromForm] string value)
        {
            string test = value;
            //cont.updateOrder(value);
        }

        // DELETE api/<PeatController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
