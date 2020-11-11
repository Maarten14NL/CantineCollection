using ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLogic
{
    public class Product
    {
        private readonly IProduct _ProductDal = ProductFactory.ProductFactory.GetProducts();

        public List<ProductDTO> Read()
        {
            List<ProductDTO> productList = _ProductDal.Read();
            return productList;
        }
        public ProductDTO Read(int id)
        {
            return _ProductDal.Read(id);
        }
    }
}
