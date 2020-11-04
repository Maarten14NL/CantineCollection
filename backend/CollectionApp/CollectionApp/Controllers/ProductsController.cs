using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CollectionLogic;
using CollectionLogic.Entities;
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
        public List<ProductEntity> Get()
        {
            return cont.ReadAll();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ProductEntity Get(int id)
        {
            return cont.ReadOne(id);
        }
    }
}
