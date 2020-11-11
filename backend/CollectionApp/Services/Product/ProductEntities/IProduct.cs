using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductEntities
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
    }
    public interface IProduct
    {
        List<ProductDTO> Read();
        ProductDTO Read(int id);
        bool Create(ProductDTO company);
        bool Update(ProductDTO company);
        bool Delete(ProductDTO company);
    }
}
