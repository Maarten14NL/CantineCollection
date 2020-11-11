using CollectionEntities;
using CollectionFactory;
using CollectionLogic.Entities;
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

        public List<ProductDTO> GetProducts()
        {
            return _ProductsDal.ReadAllAsync().Result;
        }

        public List<ProductEntity> ReadAll()
        {
            List<ProductEntity> products = new List<ProductEntity>();

            foreach (ProductDTO product in _ProductsDal.ReadAllAsync().Result)
            {
                products.Add(new ProductEntity().ProductDTOToProduct(product));
            }
            return products;
        }

        public ProductEntity ReadOne(int id)
        {
            return new ProductEntity().ProductDTOToProduct(_ProductsDal.ReadOneAsync(id).Result);
        }
    }
}
