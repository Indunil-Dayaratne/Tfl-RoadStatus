using System;
using System.Configuration;
using System.Net.Http;

namespace Tfl.RoadStatus.Core.ApplicationAccess
{
    public class HttpClientFactory
    {
        public HttpClient BuildClient()
        {
            var httpClient = new HttpClient
            {
                Timeout = TimeSpan.Parse(ConfigurationManager.AppSettings["HttpRequestTimeout"])
            };

            return httpClient;
        }
    }
}