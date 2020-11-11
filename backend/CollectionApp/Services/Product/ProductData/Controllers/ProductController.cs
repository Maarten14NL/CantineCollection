using ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductData.Controllers
{
    public class ProductController : IProduct
    {
        private readonly CollectionAdminContext db = new CollectionAdminContext();
        public bool Create(ProductDTO company)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ProductDTO company)
        {
            throw new NotImplementedException();
        }

        public List<ProductDTO> Read()
        {
            List<ProductDTO> products = db.Products.ToList();
            return products;
        }

        public ProductDTO Read(int id)
        {
            ProductDTO products = db.Products.Where(b => b.Id == 1).FirstOrDefault();
            return products;
        }

        public bool Update(ProductDTO company)
        {
            throw new NotImplementedException();
        }
    }
}
