using CollectionAdmin_Entities;
using CollectionAdmin_Data.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAdmin_Factory
{
    public class ProductFactory
    {
        public static IProduct GetProducts()
        {
            return new ProductController();
        }
    }
}
