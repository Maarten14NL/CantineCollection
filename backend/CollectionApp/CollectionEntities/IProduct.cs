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

    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public int temperatureC { get; set; }
        public int temperatureF { get; set; }
        public string summary { get; set; }
    }

    public interface IProduct
    {
        Task<List<ProductDTO>> ReadAllAsync();
        Task<ProductDTO> ReadOneAsync(int id);
    }
}
