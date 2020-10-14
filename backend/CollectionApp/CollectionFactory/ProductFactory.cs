using CollectionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionData.Controllers;
using CollectionAssortiment;

namespace CollectionFactory
{
    public class ProductFactory
    {
        public static IProduct GetAssortiment()
        {
            return new ProductController();
        }
    }
}
