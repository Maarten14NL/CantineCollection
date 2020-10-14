using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAdmin_Entities
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
        List<ProductDTO> Read(int? id = null);
        bool Create(ProductDTO company);
        bool Update(ProductDTO company);
        bool Delete(ProductDTO company);
    }
}
