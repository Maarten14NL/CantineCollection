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
    public class OrderListController : ControllerBase
    {
        private readonly OrderList orderListLogic = new OrderList();

        // GET: api/<OrderListController>
        [HttpGet]
        public List<OrderListEntity> Get()
        {
            return orderListLogic.ReadAll();
        }

        // GET api/<OrderListController>/5
        [HttpGet("{id}")]
        public OrderListEntity Get(int id)
        {
            return orderListLogic.ReadOne(id);
        }

        // POST api/<OrderListController>
        [HttpPost]
        public void Post([FromBody] OrderListEntity orderList)
        {
            if (orderList.Id != null)
            {
                orderListLogic.Update(orderList);
            }
            else
            {
                orderListLogic.Create(orderList);
            }
        }

        // PUT api/<OrderListController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OrderListEntity orderList)
        {
            orderListLogic.Update(orderList);
        }

        // DELETE api/<OrderListController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            orderListLogic.Delete(id);
        }
    }
}
