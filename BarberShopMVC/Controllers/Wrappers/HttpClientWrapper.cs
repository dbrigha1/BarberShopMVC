using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace BarberShopMVC.Controllers
{
    
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private string BaseUrl = "http://localhost:1115/";
        private HttpClient client = new HttpClient();

        public async Task<HttpResponseMessage> CreateAsync(string uri, Object model)
        {
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.PostAsJsonAsync(uri, model);

            return response;
        }

        public async Task<HttpResponseMessage> GetAll (string uri)
        {
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(uri);

            return response;
        }

        public async Task<HttpResponseMessage> GetPicture(string uri, int id)
        {
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync($"{uri}/{id}");

            return response;
        }

        public async Task<HttpResponseMessage> Delete(string uri, int id)
        {
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.DeleteAsync($"{uri}/{id}");

            return response;
        }
    }
}