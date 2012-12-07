using System;
using System.Net;
using System.Net.NetworkInformation;

namespace ZlowZebra.Clients
{
    public class HttpClient : IDisposable
    {
        

        public HttpClient()
        {
            httpClient = new System.Net.Http.HttpClient();
        }

        public Uri BaseUrl
        {
            get { return httpClient.BaseAddress; }
            set { httpClient.BaseAddress = value; }
        }



        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}