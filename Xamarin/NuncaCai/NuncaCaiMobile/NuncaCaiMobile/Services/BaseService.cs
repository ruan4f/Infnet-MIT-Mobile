using System.Net.Http;

namespace NuncaCaiMobile.Services
{
    public class BaseService
    {
        protected readonly HttpClient client;
        protected readonly string urlApi;

        public BaseService()
        {
            client = new HttpClient { MaxResponseContentBufferSize = 256000 };
            urlApi = "http://localhost:21094/api";
        }               
    }
}
