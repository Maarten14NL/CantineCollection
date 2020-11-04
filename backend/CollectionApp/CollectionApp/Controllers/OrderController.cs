using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollectionLogic;
using CollectionLogic.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CollectionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly Order orderLogic = new Order();

        // GET: api/<OrderController>
        [HttpGet]
        public List<OrderEntity> Get()
        {
            return orderLogic.ReadAll();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public OrderEntity Get(int id)
        {
            return orderLogic.ReadOne(id);
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] OrderEntity order)
        {
            if(order.Id != null)
            {
               orderLogic.Update(order);
            }
            else
            {
                orderLogic.Create(order);
            }
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OrderEntity order)
        {
            orderLogic.Update(order);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            orderLogic.Delete(id);
        }
    }
}
