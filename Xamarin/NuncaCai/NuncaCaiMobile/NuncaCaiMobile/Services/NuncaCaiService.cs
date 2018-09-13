using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace NuncaCaiMobile.Services
{
    public class NuncaCaiService
    {
        private readonly HttpClient client;
        private readonly string urlApi;

        public NuncaCaiService()
        {
            client = new HttpClient { MaxResponseContentBufferSize = 256000 };
            urlApi = "localhost:24400";
        }



    }
}
