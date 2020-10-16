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

    public class CharacterDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string species { get; set; }
        public string gender { get; set; }
    }

    public class ApiDTO
    {
        public List<CharacterDTO> results { get; set; }
    }

    public interface IProduct
    {
        Task<ApiDTO> ReadAsync(int? id = null);
        bool Create(ProductDTO item);
        bool Update(ProductDTO item);
        bool Delete(ProductDTO item);

    }
}
