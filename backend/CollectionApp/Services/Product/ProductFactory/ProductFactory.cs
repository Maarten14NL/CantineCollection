
using ProductData.Controllers;
using ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductFactory
{
    public class ProductFactory
    {
        public static IProduct GetProducts()
        {
            return new ProductController();
        }
    }
}
