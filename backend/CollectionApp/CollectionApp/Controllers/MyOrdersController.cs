using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CollectionLogic;
using System.Text.Json;

namespace CollectionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyOrdersController : ControllerBase
    {
        private readonly Order cont = new Order();
        [HttpGet]
        public string Get()
        {
            //return "test";

            return JsonSerializer.Serialize(cont.Read(1));
        }
    }
}
