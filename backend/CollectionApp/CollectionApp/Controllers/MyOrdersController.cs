using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CollectionLogic;
using System.Text.Json;
using CollectionLogic.Entities;

namespace CollectionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyOrdersController : ControllerBase
    {
        private readonly LoggedInUser cont = new LoggedInUser();
        [HttpGet]
        public List<OrderListEntity> Get()
        {
            return cont.GetLoggedInUserOrders();

            //return JsonSerializer.Serialize();
        }
    }
}
