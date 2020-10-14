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

        public List<ProductDTO> Read(int? id = null)
        {
            List<ProductDTO> productList = _ProductDal.Read(id);
            return productList;
        }
    }
}
