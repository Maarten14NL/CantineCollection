using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionEntities
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
        string Read(int? id = null);
        bool Create(ProductDTO item);
        bool Update(ProductDTO item);
        bool Delete(ProductDTO item);

    }
}
