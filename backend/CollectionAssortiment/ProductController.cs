using CollectionEntities;
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
        static HttpClient client = new HttpClient();
        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:64195/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
            public bool Create(ProductDTO item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ProductDTO item)
        {
            throw new NotImplementedException();
        }

        public string Read(int? id = null)
        {
            return ReadAsync(id).ToString();
        }

        public bool Update(ProductDTO item)
        {
            throw new NotImplementedException();
        }

        private async Task<string> ReadAsync(int? id)
        {
            string products = "";

            HttpResponseMessage response = await client.GetAsync("test");
            if (response.IsSuccessStatusCode)
            {
                products = await response.Content.ReadAsStringAsync();
            }
            return products;
        }
    }
}
