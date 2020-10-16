using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CollectionLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollectionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly Products cont = new Products();

        // GET: api/<ProductController>
        [HttpGet]
        public string Get()
        {
            return JsonSerializer.Serialize(cont.GetProducts());
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return JsonSerializer.Serialize(cont.GetProduct(id));
        }
    }
}
