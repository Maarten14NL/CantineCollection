using CollectionEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAssortiment
{
    public class ProductController : IProduct
    {
        private const string RequestUri = "https://rickandmortyapi.com/api/character/";
        private static readonly HttpClient client = new HttpClient();

        public bool Create(ProductDTO item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ProductDTO item)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiDTO> ReadAsync(int? id = null)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );

            var stringTask = client.GetStringAsync("https://rickandmortyapi.com/api/character/");

            HttpResponseMessage response = await client.GetAsync(RequestUri);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            //List<ProductDTO> product = await response.Content.ReadAsAsync<List<ProductDTO>>();

            return response.Content.ReadAsAsync<ApiDTO>().Result;

            //return myQuotes;
        }

        public bool Update(ProductDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
