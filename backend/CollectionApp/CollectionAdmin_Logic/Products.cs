using CollectionAdmin_Entities;
using CollectionAdmin_Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAdmin_Logic
{
    public class Products
    {
        private readonly IProduct _ProductDal = ProductFactory.GetProducts();

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
