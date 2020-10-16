using CollectionEntities;
using CollectionFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionLogic
{
    public class Products
    {
        private readonly IProduct _ProductsDal = ProductFactory.GetAssortiment();
        public ProductDTO GetProduct(int id)
        {
            return new ProductDTO();
        }

        public ApiDTO GetProducts()
        {
            return _ProductsDal.ReadAsync().Result;
        }
    }
}
