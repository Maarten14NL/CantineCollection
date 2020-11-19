using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollectionApp.Hubs;
using CollectionLogic;
using CollectionLogic.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CollectionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IHubContext<NotificationHub> _notificationHubContext;
        private readonly IHubContext<NotificationUserHub> _notificationUserHubContext;
        private readonly IUserConnectionManager _userConnectionManager;

        public OrderController(IHubContext<NotificationHub> notificationHubContext, IHubContext<NotificationUserHub> notificationUserHubContext, IUserConnectionManager userConnectionManager)
        {
            _notificationHubContext = notificationHubContext;
            _notificationUserHubContext = notificationUserHubContext;
            _userConnectionManager = userConnectionManager;
            notificationController = new NotificationController(_notificationHubContext, _notificationUserHubContext, _userConnectionManager);
        }

        private readonly Order orderLogic = new Order();
        private readonly NotificationController notificationController;

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
        public async void Post([FromBody] OrderEntity order)
        {
            if(order.Id != null)
            {
               orderLogic.Update(order);
            }
            else
            {
                orderLogic.Create(order);
            }
            await notificationController.GetAsync("user", 1);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] OrderEntity order)
        {
            orderLogic.Update(order);
            await notificationController.GetAsync("user", 1);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            orderLogic.Delete(id);
        }
    }
}
