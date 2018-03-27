using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BarberShopMVC.Controllers
{
    public interface IHttpClientWrapper
    {
        Task<HttpResponseMessage> GetAll(string uri);
        Task<HttpResponseMessage> GetPicture(string uri, int id);
        Task<HttpResponseMessage> CreateAsync(string uri, Object model);
        Task<HttpResponseMessage> Delete(string uri, int id);
    }
}
